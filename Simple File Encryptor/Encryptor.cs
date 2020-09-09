using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;

namespace File_encoder
{
    class Encryptor
    {
        private static bool encrypting;
        private static FileStream fStream;
        private static BinaryReader bReader;
        private static BinaryWriter bWriter;
        private static BackgroundWorker backgroundWorker;

        public static int currentProgress = 0;
        public static int bytesToReadAtOnce;
        private static int onePercentByteCount;
        private static bool paused = false;
        private static bool canceled = false;
        public static bool wasCanceled = false;

        public static void Initialize(string filePath, bool encrypting, BackgroundWorker backgroundWorker)
        {
            fStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            bReader = new BinaryReader(fStream);
            bWriter = new BinaryWriter(fStream);
            onePercentByteCount = (int)(fStream.Length / 100);
            Encryptor.encrypting = encrypting;
            Encryptor.backgroundWorker = backgroundWorker;
            currentProgress = 0;
            paused = false;
            canceled = false;
            wasCanceled = false;
        }

        public static void Resume()
        {
            paused = false;
        }

        public static void Pause()
        {
            paused = true;
        }

        public static void Cancel()
        {
            canceled = true;
            wasCanceled = true;
        }

        private static void PauseLoop()
        {
            if (!paused) { return; }
            if (canceled) { return; }   //Thread will be terminated, because after calling PauseLoop, canceled variable is checked
            Thread.Sleep(100);  //Wait for a while
        }

        private static void CheckProgress(long bytesDone, long onePercentByteCount)
        {
            if ((currentProgress + 1) * onePercentByteCount <= bytesDone)
            {
                int newValue = (int)(bytesDone / onePercentByteCount) % 100;
                backgroundWorker.ReportProgress(newValue);
                currentProgress = newValue;
            }
        }

        private static string EncryptPassword(string password)
        {
            return password;
            //TODO

            int passwordLength = password.Length;

            //Get the current time to calculate shift for caesar cipher

            return "";
        }

        public static void CryptFile(string password)
        {
            password = EncryptPassword(password);
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            int passwordLength = bytePassword.Length;
            long fileByteLength = fStream.Length;

            for (long i = 0; fStream.Position < fStream.Length;)
            {
                DebugLogger.log("Read " + bytesToReadAtOnce + "bytes.");
                byte[] bs = bReader.ReadBytes(bytesToReadAtOnce);
                int loadedBytes = bs.Length;
                if (encrypting)
                {
                    for (int j = 0; j < loadedBytes; j++)
                    {
                        if (paused) { PauseLoop(); }
                        if (canceled) { return; }

                        bs[j] += bytePassword[i % passwordLength];
                        i++;

                        if ((fStream.Position - loadedBytes + j) % 1000000 == 0) { CheckProgress(fStream.Position - loadedBytes + j, onePercentByteCount); }    //Update the progress bar once for 1 MB at most, so the form isn't blocked by constant updates
                    }
                }
                else
                {
                    for (int j = 0; j < loadedBytes; j++)
                    {
                        if (paused) { PauseLoop(); }
                        if (canceled) { return; }

                        bs[j] -= bytePassword[i % passwordLength];
                        i++;

                        if ((fStream.Position - loadedBytes + j) % 1000000 == 0) { CheckProgress(fStream.Position - loadedBytes + j, onePercentByteCount); }    //Update the progress bar once for 1 MB at most, so the form isn't blocked by constant updates
                    }
                }
                fStream.Position -= loadedBytes;
                bWriter.Write(bs);
            }
            CommitChanges();
        }

        private static void CommitChanges()
        {
            bWriter.Flush();
            bWriter.Close();

            if (encrypting)
            {
                //Append the .ecp extension to the encrypted file
                File.Move(fStream.Name, fStream.Name + ".ecp");
            }
            else
            {
                //Remove the .ecp extension from the encrypted file
                File.Move(fStream.Name, fStream.Name.Substring(0, fStream.Name.LastIndexOf(".ecp")));
            }

            //Set progressBar to 100 %
            backgroundWorker.ReportProgress(100);
            currentProgress = 100;
        }
    }
}
