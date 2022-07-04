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
    }
}
