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
         * Method called after selecting an action to perform on a file
         */
        private void ActionRadio_CheckedChanged(object sender, EventArgs e)
        {
            BrowseButton.Enabled = true;

            openFileDialog.Filter = (EncryptRadio.Checked == true) ? "Unencrypted files|*" : "Encrypted files|*.ecp";
            FilepathField.Text = "";

            this.CheckConfirmRequirements();
        }

        /**
         * Method called after clicking the button for choosing a file to encrypt / decrypt
         */
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        /**
         * Method called after selecting a file to encrypt / decrypt from the open file dialog
         */
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string selectedFilePath = openFileDialog.FileName;
            
            //Check if the file isn't already encrypted, if the action selected is encrypting
            if (selectedFilePath.EndsWith(".ecp") && EncryptRadio.Checked)
            {
                DialogResult decryptInstead = MessageBox.Show("It looks like this file is already encrypted. Would you like to decrypt it?", "File already encrypted", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (decryptInstead == DialogResult.Yes)
                {
                    //Set action to decrypting and allow the selected file
                    EncryptRadio.Checked = false;
                    DecryptRadio.Checked = true;
                    openFileDialog.Filter = "Encrypted files|*.ecp";
                }
                else
                {
                    //Ask the user to select a different file
                    openFileDialog.ShowDialog();
                    return;
                }
            }

            //Check if the file is encrypted, if the action selected is decrypting
            if (!selectedFilePath.EndsWith(".ecp") && DecryptRadio.Checked)
            {
                DialogResult encryptInstead = MessageBox.Show("It looks like this file isn\'t encrypted or wasn\'t encrypted by Simple File Encryptor.\nFiles encrypted by Simple File Encryptor have the \".ecp\" extension.\nWould you like encrypt it?", "File not encrypted", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (encryptInstead == DialogResult.Yes)
                {
                    //Set action to encrypting and allow the selected file
                    DecryptRadio.Checked = false;
                    EncryptRadio.Checked = true;
                    openFileDialog.Filter = "Unencrypted files|*";
                }
                else
                {
                    //Ask the user to select a different file
                    openFileDialog.ShowDialog();
                    return;
                }
            }
            FilepathField.Text = selectedFilePath;
            this.CheckConfirmRequirements();
        }

        /**
         * Method called after writing anything in the password field
         */
        private void PasswordField_TextChanged(object sender, EventArgs e)
        {
            this.CheckConfirmRequirements();
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
         * Method called after typing anything in the password field or selecting a file
         */
        private void CheckConfirmRequirements()
        {
            if (FilepathField.TextLength > 0 && PasswordField.TextLength > 0)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
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

            Encryptor encryptor = new Encryptor(filePath);
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
