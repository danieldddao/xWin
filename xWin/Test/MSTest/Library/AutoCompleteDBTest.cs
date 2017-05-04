using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xWin.Library;
using System.IO;
using System.Data.SQLite;
using xWin.Wrapper;
using Moq;

namespace MSTest.Library
{
    [TestClass]
    public class AutoCompleteDBTest
    {
        private string dbFile = "AutoCompleteTest.db";
        private string[] commonlyUsedWords = { "this", "that", "these" } ;
        AutoCompleteDB a;
        Mock<ISystemWrapper> mockSystemWrapper;

        [TestInitialize]
        public void Setup()
        {
            mockSystemWrapper = new Mock<ISystemWrapper>();
            a = new AutoCompleteDB(dbFile, commonlyUsedWords, mockSystemWrapper.Object);
            a.CreateDB();
        }

        [TestCleanup]
        public void Cleanup()
        {
            System.IO.File.Delete(dbFile);
        }

        [TestMethod]
        public void TestCreateDB()
        {
            a.CreateDB();
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
        public void TestCreateDB_Exception()
        {
            mockSystemWrapper.Setup(x => x.ThrowException()).Throws(new Exception());
            a.CreateDB();
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
        public void TestGetTopThreeWords_Exception()
        {
            mockSystemWrapper.Setup(x => x.ThrowException()).Throws(new Exception());
            System.Collections.Generic.List<string> list = a.GetTopThreeWords("t");
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
        [TestMethod]
        public void TestUpdateOrInsertWord_Exception()
        {
            mockSystemWrapper.Setup(x => x.ThrowException()).Throws(new Exception());
            a.UpdateOrInsertWord("new word");
        }

        [TestMethod]
        public void TestGetAllWords()
        {
            System.Collections.Generic.List<string> allWords = a.GetAllWords();
            Assert.AreEqual(allWords.Count, 3);
        }
        [TestMethod]
        public void TestGetAllWords_Exception()
        {
            mockSystemWrapper.Setup(x => x.ThrowException()).Throws(new Exception());
            System.Collections.Generic.List<string> allWords = a.GetAllWords();
            Assert.AreEqual(allWords.Count, 0);
        }

        [TestMethod]
        public void TestRemoveWord_NonExistingWord()
        {
            bool status = a.RemoveWord("noword");
            Assert.IsFalse(status);
        }
        [TestMethod]
        public void TestRemoveWord_ExistingWord()
        {
            bool status = a.RemoveWord("this");
            Assert.IsTrue(status);
        }
        [TestMethod]
        public void TestRemoveWord_Exception()
        {
            mockSystemWrapper.Setup(x => x.ThrowException()).Throws(new Exception());
            bool status = a.RemoveWord("this");
            Assert.IsFalse(status);
        }

        [TestMethod]
        public void TestClearDictionary()
        {
            a.ClearDictionary();
            Assert.AreEqual(a.GetAllWords().Count, 0);
        }
        [TestMethod]
        public void TestClearDictionary_Exception()
        {
            mockSystemWrapper.Setup(x => x.ThrowException()).Throws(new Exception());
            a.ClearDictionary();
        }
    }
}
