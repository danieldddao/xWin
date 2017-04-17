using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using System.IO;
using System.Data.SQLite;

namespace MSTest.Library
{
    [TestClass]
    public class AutoCompleteDBTest
    {
        private string dbFile = "AutoCompleteTest.db";
        private string[] commonlyUsedWords = { "this", "that", "these" } ;
        AutoCompleteDB a;

        [TestInitialize]
        public void Setup()
        {
            a = new AutoCompleteDB(dbFile, commonlyUsedWords);
        }

        [TestCleanup]
        public void Cleanup()
        {
            System.IO.File.Delete(dbFile);
        }

        [TestMethod]
        public void TestCreateDB()
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
            {
                string query = "Select * FROM Dictionary;";
                dbConnection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        Assert.IsTrue(reader.Read());
                    }
                }
            }
        }

        [TestMethod]
        public void TestGetTopThreeWords_MatchWord()
        {
            System.Collections.Generic.List<string> list = a.GetTopThreeWords("t");
            Assert.AreEqual(list.Count, 3);
        }
        [TestMethod]
        public void TestGetTopThreeWords_UnmatchWord()
        {
            System.Collections.Generic.List<string> list = a.GetTopThreeWords("\0");
            Assert.AreEqual(list.Count, 0);
        }

        [TestMethod]
        public void TestUpdateOrInsertWord_Update()
        {
            a.UpdateOrInsertWord("this");
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
            {
                string query = "Select typed_count FROM Dictionary WHERE word = 'this';";
                dbConnection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        Assert.IsTrue(reader.Read());
                        Assert.IsTrue((int) reader["typed_count"] == 2);
                    }
                }
            }
        }

        [TestMethod]
        public void TestUpdateOrInsertWord_Insert()
        {
            a.UpdateOrInsertWord("new word");
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;"))
            {
                string query = "Select typed_count FROM Dictionary WHERE word = 'new word';";
                dbConnection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, dbConnection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        Assert.IsTrue(reader.Read());
                        Assert.IsTrue((int)reader["typed_count"] == 1);
                    }
                }
            }
        }

    }
}
