using System;
using System.IO;
using System.Windows.Forms;

namespace File_encoder
{
    class Encryptor
    {
        private FileStream file;

        public Encryptor(FileStream file)
        {
            this.file = file;
        }

        public void Encrypt(string password, bool updateProgressBar, ProgressBar progressBar)
        {
            //TODO
        }
    }
}
