using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;

namespace SimpleFileEncryptor
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
            sbyte coefficient = -1;
            StringBuilder builder = new StringBuilder();

            //Action 1
            //Move rearrange characters in style last - first - second to last - second ...
            for (int i = 0; builder.Length < password.Length; i++, coefficient *= -1)
            {
                if (coefficient == -1)
                {
                    builder.Append(password[password.Length - 1 - i]);
                }
                else
                {
                    builder.Append(password[--i]);
                }
            }
            password = builder.ToString();
            builder.Clear();

            //Action 2
            //Copy the password, but swap the letters' case
            builder.Append(password);
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password[i])) { builder.Append(password[i].ToString().ToLower()); }
                else { builder.Append(password[i].ToString().ToUpper()); }
            }
            password = builder.ToString();
            builder.Clear();

            //Action 3
            //Swap case in every second character
            for (int i = 0; i < password.Length; i++)
            {
                if (i % 2 == 0) { builder.Append(password[i]); }
                else if (Char.IsUpper(password[i])) { builder.Append(password[i].ToString().ToLower()); }
                else { builder.Append(password[i].ToString().ToUpper()); }
            }
            password = builder.ToString();
            builder.Clear();

            //Action 4
            //Perform string rotation operation and connect all results together
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < password.Length; j++)
                {
                    builder.Append(password[(i + j) % password.Length]);
                }
            }
            password = builder.ToString();
            builder.Clear();

            //Action 5
            //Convert characters into byte array
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            //Action 6
            //Add the position of each byte to it
            for (int i = 0; i < bytePassword.Length; i++)
            {
                bytePassword[i] += (byte)i;
            }

            //Action 7
            //Add, subtract or multiply each byte by sum of its neighbours
            coefficient = 1;
            byte[] bytePasswordCopy = new byte[bytePassword.Length];
            bytePassword.CopyTo(bytePasswordCopy, 0);
            for (int i = 0; i < bytePassword.Length; i++)
            {
                int prevIndex = (i - 1 < 0) ? bytePassword.Length - 1 : i - 1;
                int nextIndex = (i + 1 == bytePassword.Length) ? 0 : i + 1;
                bytePassword[i] = (byte)(bytePasswordCopy[i] + coefficient * (bytePasswordCopy[prevIndex] + bytePasswordCopy[nextIndex]));
                coefficient *= -1;
            }

            return Encoding.Default.GetString(bytePassword);
        }

        public static void CryptFile(string password)
        {
            password = EncryptPassword(password);
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            int passwordLength = bytePassword.Length;

            for (long i = 0; fStream.Position < fStream.Length;)
            {
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
