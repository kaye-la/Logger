using System;
using System.Collections.Generic;
using System.IO;

namespace Logger
{
    public class Logger : ILog
    {
        private List<string> uniqueWarnings;
        private List<string> uniqueErrors;

        public Logger()
        {
            uniqueWarnings = new List<string>();
            uniqueErrors = new List<string>();
        }

        private void WriteLog(string msg, string logType)
        {
            string path = $"Logs/{DateTime.Now:yyyy-MM-dd}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            string msgFormat = $"{DateTime.Now} ({logType.ToUpper()}): {msg}\n";

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                uniqueWarnings.Clear();
                uniqueErrors.Clear();
            }
            File.AppendAllText($"{path}/{logType.ToLower()}.log", msgFormat);
        }

        private void WriteLog(string msg, string logType, Exception e)
        {
            string path = $"Logs/{DateTime.Now:yyyy-MM-dd}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            string msgFormat = $"{DateTime.Now} ({logType.ToUpper()}): {msg}, Exception: {e.Message}, StackTrace: {e.StackTrace}\n";

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                uniqueWarnings.Clear();
                uniqueErrors.Clear();
            }
            File.AppendAllText($"{path}/{logType.ToLower()}.log", msgFormat);
        }

        private void WriteLog(string msg, string logType, params object[] args)
        {
            string path = $"Logs/{DateTime.Now:yyyy-MM-dd}";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            string msgFormat = $"{DateTime.Now} ({logType.ToUpper()}): {msg}; Params: ${String.Join(",", args)}\n";

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                uniqueWarnings.Clear();
                uniqueErrors.Clear();
            }
            File.AppendAllText($"{path}/{logType.ToLower()}.log", msgFormat);
        }

        public void Debug(string message)
        {
            WriteLog(message, "debug");
        }

        public void Debug(string message, Exception e)
        {
            WriteLog(message, "debug", e);
        }

        public void DebugFormat(string message, params object[] args)
        {
            WriteLog(message, "debug", args);
        }

        public void Error(string message)
        {
            WriteLog(message, "error");
        }

        public void Error(string message, Exception e)
        {
            WriteLog(message, "error", e);
        }

        public void Error(Exception ex)
        {
            WriteLog(ex.Message, "error", ex);
        }

        public void ErrorUnique(string message, Exception e)
        {
            if (!uniqueErrors.Contains(message))
            {
                WriteLog(message, "error_unique", e);
                uniqueErrors.Add(message);
            }
        }

        public void Fatal(string message)
        {
            WriteLog(message, "fatal");
        }

        public void Fatal(string message, Exception e)
        {
            WriteLog(message, "fatal", e);
        }

        public void Info(string message)
        {
            WriteLog(message, "info");
        }

        public void Info(string message, Exception e)
        {
            WriteLog(message, "info", e);
        }

        public void Info(string message, params object[] args)
        {
            WriteLog(message, "info", args);
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            WriteLog(message, "sys_info", properties);
        }

        public void Warning(string message)
        {
            WriteLog(message, "warning");
        }

        public void Warning(string message, Exception e)
        {
            WriteLog(message, "warning", e);
        }

        public void WarningUnique(string message)
        {
            if (!uniqueWarnings.Contains(message))
            {
                WriteLog(message, "warning_unique");
                uniqueWarnings.Add(message);
            }
        }
    }
}
