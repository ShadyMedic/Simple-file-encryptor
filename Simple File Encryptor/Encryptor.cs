using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace File_encoder
{
    class Encryptor
    {
        private string filePath;

        public Encryptor(string filePath)
        {
            this.filePath = filePath;
        }

        public void Encrypt(string password, TrackBar performanceSlider, bool updateProgressBar, ProgressBar progressBar)
        {
            password = this.EncryptPassword(password);
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            this.CryptFile(true, new FileStream(this.filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite), bytePassword, performanceSlider, updateProgressBar, progressBar);

            //Append the .ecp extension to the encrypted file
            File.Move(this.filePath, this.filePath + ".ecp");
        }

        public void Decrypt(string password, TrackBar performanceSlider, bool updateProgressBar, ProgressBar progressBar)
        {
            password = this.EncryptPassword(password);
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            this.CryptFile(false, new FileStream(this.filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite), bytePassword, performanceSlider, updateProgressBar, progressBar);

            //Remove the .exp extension from the encrypted file
            File.Move(this.filePath, this.filePath.Substring(0, filePath.LastIndexOf(".ecp")));
        }

        private string EncryptPassword(string password)
        {
            return password;
            //TODO

            int passwordLength = password.Length;

            //Get the current time to calculate shift for caesar cipher

            return "";
        }
        private void CryptFile(bool encrypt, FileStream fStream, byte[] bytePassword, TrackBar performanceSlider, bool updateProgressBar, ProgressBar progressBar)
        {
            BinaryReader bReader = new BinaryReader(fStream);
            BinaryWriter bWriter = new BinaryWriter(fStream);

            int passwordLength = bytePassword.Length;
            long fileByteLength = fStream.Length;
            long onePercentByteCount = Convert.ToInt32(Math.Round(Convert.ToDouble(fileByteLength / 100)));

            for (long i = 0; fStream.Position < fStream.Length;)
            {
                int byteCountToRead = performanceSlider.Value;
                byte[] bs = bReader.ReadBytes(byteCountToRead);
                int loadedBytes = bs.Length;
                if (encrypt)
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

                if (updateProgressBar && fStream.Position / onePercentByteCount > progressBar.Value)
                {
                    progressBar.Value = (progressBar.Value + 1) % 100;
                }
            }
            bWriter.Flush();
            bWriter.Close();
        }
    }
}
