using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net.Repository.Hierarchy;
using log4net;
using log4net.Core;

namespace MSTest.Library
{
    [TestClass]
    public class LogTest
    {
        protected static readonly ILog log = xWin.Library.Log.GetLogger();

        [TestInitialize]
        public void SetUp()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod]
        public void TestClearLogs()
        {
            log4net.Appender.RollingFileAppender rollingFileAppender = (log4net.Appender.RollingFileAppender)LogManager.GetRepository().GetAppenders()[0];
            var myFile  = File.Create(System.IO.Path.GetDirectoryName(rollingFileAppender.File) + "\\xWinLogTest.txt");
            myFile.Close();
            xWin.Library.Log.ClearLogs();
            string[] allFiles = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(rollingFileAppender.File));
            foreach (string file in allFiles)
            { Assert.IsFalse(file.Contains("xWinLogTest.txt")); }
        }

        [TestMethod]
        public void TestEnableDebug()
        {
            xWin.Library.Log.EnableDebugMode();
            Assert.AreEqual(((Hierarchy)LogManager.GetRepository()).Root.Level, Level.Debug);
        }

        [TestMethod]
        public void TestDisableDebug()
        {
            xWin.Library.Log.DisableDebugMode();
            Assert.AreNotEqual(((Hierarchy)LogManager.GetRepository()).Root.Level, Level.Debug);
        }
    }
}
