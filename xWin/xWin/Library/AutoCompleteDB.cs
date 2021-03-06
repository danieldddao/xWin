﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xWin.Wrapper;

namespace xWin.Library
{
    public class AutoCompleteDB
    {
        ISystemWrapper systemWrapper; // for testing Exceptions

        private string[] commonlyUsedWords = {
                                               "the", "be", "to", "of", "and", "a", "in", "that", "have",
                                               "I", "it", "for", "not", "on", "with", "he", "as", "you",
                                               "do", "at", "this", "but", "his", "by", "from", "they",
                                               "we", "say", "her", "she", "or", "an", "will", "my", "one",
                                               "all", "would", "there", "their", "what", "so", "up", "out", "if",
                                               "about", "who", "get", "which", "go", "me", "when", "make", "can",
                                               "like", "time", "no", "just", "him", "know", "take", "people", "into",
                                               "year", "your", "good", "some", "could", "them", "see", "other", "than",
                                               "then", "now", "look", "only", "come", "its", "over", "think", "also",
                                               "back", "after", "use", "two", "how", "our", "work", "first", "well", "way", "even", "new",
                                               "want", "because", "any", "these", "give", "day", "most", "us"
                                             };
        private string dbFile = "AutoComplete.db";

        public AutoCompleteDB() 
        {
            systemWrapper = new SystemWrapper();
            CreateDB();
        }

        public AutoCompleteDB(string db, string[] words, ISystemWrapper systemWrapper)
        {
            dbFile = db;
            commonlyUsedWords = words;
            this.systemWrapper = systemWrapper;
            CreateDB();
        }

        public void CreateDB() 
        {
            try
            {
                systemWrapper.ThrowException();

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
                {
                    string query = "CREATE TABLE IF NOT EXISTS Dictionary (" +
                             "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                             "word VARCHAR(200) NOT NULL UNIQUE, " +
                             "typed_count INT DEFAULT 1" +
                             ");";
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                    {
                        int status = cmd.ExecuteNonQuery();
                        Log.GetLogger().Debug("Create Table's status= " + status);

                        if (status == 0)
                        {
                            // Create index
                            query = "CREATE INDEX IF NOT EXISTS dictionary_index ON Dictionary(word, typed_count);";
                            using (SQLiteCommand cmdi = new SQLiteCommand(query, dbConnection))
                            {
                                status = cmdi.ExecuteNonQuery();
                                if (status == 0)
                                { Log.GetLogger().Debug("Successfully created index into Dictionary table"); }
                                else
                                { Log.GetLogger().Debug("Failed to created index into Dictionary table"); }
                            }

                            // Insert commonly used words into the newly created database
                            foreach (string word in commonlyUsedWords)
                            {
                                query = "INSERT INTO Dictionary(word) values('" + word.ToLower() + "');";
                                using (SQLiteCommand cmdi = new SQLiteCommand(query, dbConnection))
                                {
                                    status = cmdi.ExecuteNonQuery();
                                    if (status == 1)
                                    { Log.GetLogger().Debug("Successfully inserted word '" + word + "' into Dictionary table"); }
                                    else
                                    { Log.GetLogger().Debug("Failed to insert word '" + word + "' into Dictionary table"); }
                                }
                            }
                        }
                    }

                }
                Log.GetLogger().Debug("Finished initialized AutoCompleteDB Object");
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
            }
        }

        // Get top three words in Dictionary table where those 3 words start with subword
        public List<string> GetTopThreeWords(string subword) 
        {
            List<string> topThree = new List<string>();
            try 
            {
                systemWrapper.ThrowException();
                if (subword != "")
                {
                    using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
                    {
                        string query = "SELECT word FROM Dictionary WHERE word LIKE \"" + subword.ToLower() + "%\" ORDER BY typed_count DESC LIMIT 3;";
                        dbConnection.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                        {
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                { topThree.Add((string)reader["word"]); }
                                if (topThree.Count == 0)
                                { Log.GetLogger().Debug("Couldn't find " + subword + " in the database"); }
                            }
                        }
                    }

                }

                return topThree;
            }
            catch (Exception e ) 
            {
                Log.GetLogger().Debug(e);
                return topThree;
            }
        }

        public void UpdateOrInsertWord(string inputWord)
        {
            try
            {
                systemWrapper.ThrowException();
                string word = inputWord.Replace("'", "''");

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
                {
                    string query = "SELECT word FROM Dictionary WHERE word='" + word.ToLower() + "';";
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            // If word exists in database, update its typed_count
                            if (reader.Read())
                            {
                                Log.GetLogger().Debug("Word '" + word + "' exists in database, Updating typed_count...");
                                query = "UPDATE Dictionary SET typed_count = typed_count + 1 WHERE word = '" + word.ToLower() + "';";
                                using (SQLiteCommand cmdu = new SQLiteCommand(query, dbConnection))
                                {
                                    int status = cmdu.ExecuteNonQuery();
                                    if (status == 1)
                                    { Log.GetLogger().Info("Successfully updated word: '" + word + "' in Dictionary table"); }
                                    else
                                    { Log.GetLogger().Error("Failed to update word: '" + word + "' in Dictionary table"); }
                                }
                            }
                            // If word is not empty and doesn't exist in database, insert it into Dictionary table
                            else if (word != "")
                            {
                                Log.GetLogger().Debug("Word '" + word + "' doesn't exist in database, Inserting it to database...");
                                query = "INSERT INTO Dictionary (word) values ('" + word.ToLower() + "');";
                                using (SQLiteCommand cmdi = new SQLiteCommand(query, dbConnection))
                                {
                                    int status = cmdi.ExecuteNonQuery();
                                    if (status == 1)
                                    { Log.GetLogger().Info("Successfully inserted word: '" + word + "' to Dictionary table"); }
                                    else
                                    { Log.GetLogger().Error("Failed to insert word: '" + word + "' to Dictionary table"); }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Debug(e);
            }
        }

        public List<string> GetAllWords()
        {
            List<string> allWords = new List<string>();
            try
            {
                systemWrapper.ThrowException();

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
                {
                    string query = "SELECT word FROM Dictionary;";
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            { allWords.Add((string)reader["word"]); }
                            if (allWords.Count == 0)
                            { Log.GetLogger().Debug("Database is empty"); }
                        }
                    }
                }
                return allWords;
            }
            catch (Exception e)
            {
                Log.GetLogger().Error(e);
                return allWords;
            }
        }

        public bool RemoveWord(string word)
        {
            List<string> allWords = new List<string>();
            bool status = false;
            try
            {
                systemWrapper.ThrowException();

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
                {
                    string query = "DELETE FROM Dictionary WHERE word='" + word + "';";
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                    {
                        int s = cmd.ExecuteNonQuery();
                        if (s == 1) { status = true; }
                    }
                }
                return status;
            }
            catch (Exception e)
            {
                Log.GetLogger().Debug(e);
                return status;
            }
        }

        public void ClearDictionary()
        {
            try
            {
                systemWrapper.ThrowException();

                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
                {
                    string query = "DELETE FROM Dictionary;";
                    dbConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Log.GetLogger().Debug(e);
            }
        }
    }
}
