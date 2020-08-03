using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace File_encoder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        /**
         * Method called after clicking the button for choosing a file to encrypt / decrypt
         */
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        /**
         * Method called after selecting a valid file to encrypt / decrypt from the open file dialog
         */
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FilepathField.Text = openFileDialog.FileName;
        }

        /**
         * Method called after clicking the eye button for displaying or hiding the password
         */
        private void TogglePasswordButton_Click(object sender, EventArgs e)
        {
            char passwordChar = PasswordField.PasswordChar;
            if (passwordChar == '•')
            {
                //Revealing password
                PasswordField.PasswordChar = '\0';
                TogglePasswordButton.Text = "🕶";
            }
            else
            {
                //Hiding password
                PasswordField.PasswordChar = '•';
                TogglePasswordButton.Text = "👓";
            }
        }

        /**
         * Method called after clicking the confirm button
         */
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //Check if all fields are properly filled
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

            //Disable input fields
            FilepathField.Enabled = false;
            BrowseButton.Enabled = false;
            EncryptRadio.Enabled = false;
            DecryptRadio.Enabled = false;
            PasswordField.Enabled = false;
            ConfirmButton.Enabled = false;

            //Reset progress bar
            ProgressBar.Value = 0;
            ProgressBar.Enabled = true;

            string filePath = FilepathField.Text;
            string password = PasswordField.Text;
            bool encrypting = (EncryptRadio.Checked == true) ? true : false;
            bool updateProgressBar = (progressCheckbox.Checked == true) ? true : false;

            Encryptor encryptor = new Encryptor(new FileStream(filePath, FileMode.Open));
            if (encrypting) { encryptor.Encrypt(password, updateProgressBar, ProgressBar); }
            else { encryptor.Decrypt(password, updateProgressBar, ProgressBar); }

            //Reset progress bar
            ProgressBar.Value = 0;
            ProgressBar.Enabled = false;

            //Reenable input fields
            FilepathField.Enabled = true;
            BrowseButton.Enabled = true;
            EncryptRadio.Enabled = true;
            DecryptRadio.Enabled = true;
            PasswordField.Enabled = true;
            ConfirmButton.Enabled = true;

            if (encrypting) { MessageBox.Show("File encrypted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { MessageBox.Show("File decrypted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
