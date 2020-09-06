using System;
using System.ComponentModel;
using System.IO;
using System.Text;

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

        public static void Initialize(string filePath, bool encrypting, BackgroundWorker backgroundWorker)
        {
            fStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            bReader = new BinaryReader(fStream);
            bWriter = new BinaryWriter(fStream);
            Encryptor.encrypting = encrypting;
            Encryptor.backgroundWorker = backgroundWorker;
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
            long onePercentByteCount = Convert.ToInt32(Math.Round(Convert.ToDouble(fileByteLength / 100)));

            for (long i = 0; fStream.Position < fStream.Length;)
            {
                int byteCountToRead = bytesToReadAtOnce;
                byte[] bs = bReader.ReadBytes(byteCountToRead);
                int loadedBytes = bs.Length;
                if (encrypting)
                {
                    for (int j = 0; j < loadedBytes; j++)
                    {
                        bs[j] += bytePassword[i % passwordLength];
                        i++;
                    }
                }
                else
                {
                    for (int j = 0; j < loadedBytes; j++)
                    {
                        bs[j] -= bytePassword[i % passwordLength];
                        i++;
                    }
                }
                fStream.Position -= loadedBytes;
                bWriter.Write(bs);

                if (fStream.Position / onePercentByteCount > currentProgress)
                {
                    int newValue = (int)(fStream.Position / onePercentByteCount) % 100;
                    backgroundWorker.ReportProgress(newValue);
                }
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
        }
    }
}
