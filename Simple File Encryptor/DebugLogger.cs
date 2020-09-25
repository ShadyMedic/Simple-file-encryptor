using System.IO;

namespace SimpleFileEncryptor
{
    class DebugLogger
    {
        private const string logFilePath = "C:\\Users\\honza\\OneDrive\\Online Programování\\C#\\Simple File Encryptor\\debug.log";
        private static StreamWriter logFileStream = new StreamWriter(DebugLogger.logFilePath);

        public static void log(string text)
        {
            DebugLogger.logFileStream.WriteLine(text);
            DebugLogger.logFileStream.Flush();
        }
    }
}
