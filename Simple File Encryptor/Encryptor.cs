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

        public void Encrypt(string password, bool updateProgressBar, ProgressBar progressBar)
        {
            password = this.EncryptPassword(password);
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            this.CryptFile(true, new FileStream(this.filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite), bytePassword, updateProgressBar, progressBar);

            //Append the .ecp extension to the encrypted file
            File.Move(this.filePath, this.filePath + ".ecp");
        }

        public void Decrypt(string password, bool updateProgressBar, ProgressBar progressBar)
        {
            password = this.EncryptPassword(password);
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);

            this.CryptFile(false, new FileStream(this.filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite), bytePassword, updateProgressBar, progressBar);

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
        private void CryptFile(bool encrypt, FileStream fStream, byte[] bytePassword, bool updateProgressBar, ProgressBar progressBar)
        {
            StreamReader reader = new StreamReader(fStream);
            StreamWriter writer = new StreamWriter(fStream);

            BinaryReader bReader = new BinaryReader(fStream);
            BinaryWriter bWriter = new BinaryWriter(fStream);

            int passwordLength = bytePassword.Length;
            long fileByteLength = fStream.Length;
            long onePercentByteCount = Convert.ToInt32(Math.Round(Convert.ToDouble(fileByteLength / 100)));

            try
            {
                for (int i = 0; true; i++)
                {
                    byte b = bReader.ReadByte();
                    if (encrypt) { b += bytePassword[i % passwordLength]; }
                    else         { b -= bytePassword[i % passwordLength]; }
                    fStream.Position--;
                    bWriter.Write(b);

                    if (updateProgressBar && i % onePercentByteCount == 0)
                    {
                        progressBar.Value = (progressBar.Value + 1) % 100;
                    }
                }
            }
            catch (EndOfStreamException)
            {
                /*End of file was reached - exit the for loop*/
                bWriter.Flush();
                bWriter.Close();
            }
        }
    }
}
