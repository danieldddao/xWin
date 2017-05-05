using System;
using System.Runtime.CompilerServices;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using System.Linq;

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
                log4net.Appender.RollingFileAppender rollingFileAppender = (log4net.Appender.RollingFileAppender)LogManager.GetRepository().GetAppenders()[0];
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
            //Logger currentLogger = (Logger)GetLogger().Logger;
            //currentLogger.Level = Level.Debug;
            GetLogger().Debug("Debug Mode");
            GetLogger().Info("Debug Mode enabled");
        }

        public static void DisableDebugMode()
        {
            ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Info;
            ((Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            //Logger currentLogger = (Logger)GetLogger().Logger;
            //currentLogger.Level = Level.Info;
            GetLogger().Debug("Debug Mode");
            GetLogger().Info("Debug Mode disabled");
        }

        public static void OpenLogFile()
        {
            try
            {
                var rollingFileAppender = ((log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository()).Root.Appenders.OfType<log4net.Appender.RollingFileAppender>().FirstOrDefault();
                string file = rollingFileAppender != null ? rollingFileAppender.File : string.Empty;
                GetLogger().Info("Log file is " + file);
                System.Diagnostics.Process.Start(file);
                GetLogger().Info("Log file opened!");
            }
            catch (Exception ex)
            {
                GetLogger().Error("Error when opening log file: ", ex);
            }
        }
    }

}
