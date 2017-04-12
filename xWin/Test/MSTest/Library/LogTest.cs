using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net.Repository.Hierarchy;
using log4net;
using log4net.Core;
using System.Text;

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
            string filename = System.IO.Path.GetDirectoryName(rollingFileAppender.File) + "\\xWinLogTest.txt";
            if (!File.Exists(filename))
            {
                var myFile = File.Create(filename);
                myFile.Close();
            }
            xWin.Library.Log.ClearLogs();
            string[] allFiles = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(rollingFileAppender.File));
            foreach (string file in allFiles)
            {
                if (file.Contains("xWinLogTest.txt"))
                {
                    string[] lines = File.ReadAllLines(file, Encoding.UTF8);
                    Assert.AreEqual(lines.Length, 1);
                    Assert.IsTrue(lines[0].Contains("Cleared all logs!"));
                }
            }
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
