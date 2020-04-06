using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_encoder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FilepathField.Text = openFileDialog.FileName;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FilepathField.Text))
            {
                MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(EncryptRadio.Checked || DecryptRadio.Checked))
            {
                MessageBox.Show("Select the operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PasswordField.Text == String.Empty)
            {
                MessageBox.Show("Enter a password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure you want to execute this operation?\nThere will be no way to recover the file into its initial state without the password you entered!\nIf you choose to decrypt unencrypted file or encrypt an encrypted file, you will have problems recovering them!\n\nIMPORTANT! This works only on files stored as raw text (usually .txt and source files - .html, .css, .js, .php,...). Other file types will be corrupted and lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            ProgressBar.Value = 0;
            ProgressBar.Enabled = true;

            bool encrypting = (EncryptRadio.Checked == true) ? true : false;

            char[] fileContent = File.ReadAllText(FilepathField.Text).ToCharArray();
            int fileLength = fileContent.Length;
            char[] processedContent = new char[fileLength];

            char[] password = PasswordField.Text.ToCharArray();
            int passwordLength = password.Length;

            ProgressBar.Maximum = fileLength;

            for (int i = 0; i < fileLength; i++)
            {
                char ch = fileContent[i];
                char passCh = password[i % passwordLength];

                if (encrypting)
                {
                    ch = (char)(Convert.ToInt32(ch) + Convert.ToInt32(passCh));
                }
                else
                {
                    ch = (char)(Convert.ToInt32(ch) - Convert.ToInt32(passCh));
                }

                processedContent[i] = ch;
                if (progressCheckbox.Checked){ ProgressBar.Value = i; }
            }

            File.WriteAllText(FilepathField.Text, new string(processedContent));

            ProgressBar.Value = 0;
            ProgressBar.Enabled = false;
            if (encrypting) { MessageBox.Show("File encrypted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { MessageBox.Show("File decrypted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
