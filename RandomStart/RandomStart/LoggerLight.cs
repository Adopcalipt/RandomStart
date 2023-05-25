using System;
using System.IO;

namespace RandomStart
{
    public class LoggerLight
    {
        public static void Loggers(string sLog)
        {
            using (StreamWriter tEx = File.AppendText(DataStore.sBeeLogs))
                tEx.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {"--" + sLog}");
        }
        public static void LoggersLoad()
        {
            using (StreamWriter tEx = File.CreateText(DataStore.sBeeLogs))
                tEx.WriteLine(DateTime.Now.ToLongDateString());
        }
        public static void SendRequest(string sLog, string sFile, bool Overwrite)
        {
            if (Overwrite)
            {
                using (StreamWriter tEx = File.CreateText(sFile))
                    tEx.WriteLine(sLog);
            }
            else
            {
                using (StreamWriter tEx = File.AppendText(sFile))
                    tEx.WriteLine(sLog);
            }
        }
    }
}
