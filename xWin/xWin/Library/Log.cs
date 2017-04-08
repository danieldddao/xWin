using System;
using System.Runtime.CompilerServices;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace xWin.Library
{
    public class Log
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }

        // Clear and remove all log files
        public static void ClearLogs()
        {
            try
            {
                // stop logging process
                log4net.Appender.RollingFileAppender rollingFileAppender = (log4net.Appender.RollingFileAppender)LogManager.GetRepository().GetAppenders()[0];
                rollingFileAppender.ImmediateFlush = true;
                rollingFileAppender.LockingModel = new log4net.Appender.FileAppender.MinimalLock();
                rollingFileAppender.ActivateOptions();
                // get all files in log files' directory
                string[] allFiles = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(rollingFileAppender.File));
                foreach (string file in allFiles)
                {
                    if (file.Contains("xWinLog"))
                    {
                        System.IO.File.Delete(file); // remove log file
                    }
                }
                GetLogger().Warn("Cleared all logs!");
            }
            catch (Exception e)
            {
                GetLogger().Error("Error when clearing logs: ", e);
            }

        }

        public static void EnableDebugMode()
        {
            ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
            ((Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            GetLogger().Info("Enabled Debug Mode");
        }

        public static void DisableDebugMode()
        {
            ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Warn;
            ((Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            GetLogger().Info("Disabled Debug Mode");
        }
    }

}
