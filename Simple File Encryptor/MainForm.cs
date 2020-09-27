using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleFileEncryptor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Constructor initialazing the main form and setting values for background worker and Encryptor class
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            Encryptor.bytesToReadAtOnce = performanceSlider.Value;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(StartOperation);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OperationFinished);
        }

        /// <summary>
        /// Method updating progress bar, when new 1 % of progress is made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Method called after selecting an action to perform on a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionRadio_CheckedChanged(object sender, EventArgs e)
        {
            BrowseButton.Enabled = true;

            openFileDialog.Filter = (EncryptRadio.Checked == true) ? "Unencrypted files|*" : "Encrypted files|*.ecp";
            FilepathField.Text = "";

            this.CheckConfirmRequirements();
        }

        /// <summary>
        /// Method called after clicking the button for choosing a file to encrypt / decrypt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        /// <summary>
        /// Method called after selecting a file to encrypt / decrypt from the open file dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    e.Cancel = true;
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
                    e.Cancel = true;
                    return;
                }
            }
            FilepathField.Text = selectedFilePath;
            this.CheckConfirmRequirements();
        }

        /// <summary>
        /// Method called after writing anything in the password field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordField_TextChanged(object sender, EventArgs e)
        {
            this.CheckConfirmRequirements();
        }

        /// <summary>
        /// Method called after clicking the eye button for displaying or hiding the password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogglePasswordButton_Click(object sender, EventArgs e)
        {
            char passwordChar = PasswordField.PasswordChar;
            if (passwordChar == '•')
            {
                //Revealing password
                PasswordField.PasswordChar = '\0';
            }
            else
            {
                //Hiding password
                PasswordField.PasswordChar = '•';
            }
        }

        /// <summary>
        /// Method called after changing the value on the performance TrackBar control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PerformanceSlider_Change(object sender, EventArgs e)
        {
            Encryptor.bytesToReadAtOnce = (performanceSlider.Value * 1024); //Values in the TrackBar are meant to be kB
        }

        /// <summary>
        /// Method called after typing anything in the password field or selecting a file
        /// </summary>
        private void CheckConfirmRequirements()
        {
            if (FilepathField.TextLength > 0 && PasswordField.TextLength >= 4)
            {
                ConfirmButton.Enabled = true;
                ConfirmButton.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                ConfirmButton.Enabled = false;
                ConfirmButton.FlatStyle = FlatStyle.System;
            }
        }

        /// <summary>
        /// Method called when the backround worker is launched (after clicking the "Confirm button" and passing validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartOperation(object sender, DoWorkEventArgs e)
        {
            Encryptor.CryptFile(PasswordField.Text);
        }

        /// <summary>
        /// Method called after clicking the confirm button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (PasswordField.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex re = new Regex("(?=.*[a-záčďěéňřšťůúýž])|(?=.*[A-ZÁČĎĚÉŇŘŠŤŮÚÝŽ])");
            if (!re.IsMatch(PasswordField.Text))
            {
                MessageBox.Show("Password must contain at least one letter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure you want to execute this operation?\nThere will be no way to recover the file into its initial state without the password you entered!\nIf you choose to decrypt unencrypted file or encrypt an encrypted file, you will have problems recovering them!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            //Disable input fields
            BrowseButton.Enabled = false;
            EncryptRadio.Enabled = false;
            DecryptRadio.Enabled = false;
            PasswordField.Enabled = false;
            PasswordField.ReadOnly = true;

            //Toggle buttons
            ConfirmButton.Visible = false;
            PauseButton.Visible = true;
            CancelButton.Visible = true;

            //Reset progress bar
            ProgressBar.Value = 0;
            ProgressBar.Enabled = true;

            string filePath = FilepathField.Text;
            bool encrypting = (EncryptRadio.Checked == true) ? true : false;

            Encryptor.Initialize(filePath, encrypting, backgroundWorker);
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Method called after clicking the resume button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResumeButton_Click(object sender, EventArgs e)
        {
            Encryptor.Resume();
            ResumeButton.Visible = false;
            PauseButton.Visible = true;
        }

        /// <summary>
        /// Method called after clicking the pause button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseButton_Click(object sender, EventArgs e)
        {
            Encryptor.Pause();
            PauseButton.Visible = false;
            ResumeButton.Visible = true;
        }

        /// <summary>
        /// Method called after clicking the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Encryptor.Cancel();
        }

        /// <summary>
        /// Callback method called when backround worker finishes its work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetForm((EncryptRadio.Checked == true) ? true : false);
        }

        /// <summary>
        /// Method reenabling controls on the form after finishing the operation
        /// </summary>
        /// <param name="encrypting">true in case that the operation finished was encryption, false if decryption</param>
        public void ResetForm(bool encrypting)
        {
            if (Encryptor.wasCanceled == false)
            {
                //Display success message
                if (encrypting) { MessageBox.Show("File encrypted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("File decrypted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                //Clear the field with path to file (it was renamed anyway)
                FilepathField.Text = "";
                ConfirmButton.Enabled = false;
                ConfirmButton.FlatStyle = FlatStyle.System;
            }

            //Reset progress bar
            ProgressBar.Value = 0;
            ProgressBar.Enabled = false;
            
            //Reenable input fields
            BrowseButton.Enabled = true;
            EncryptRadio.Enabled = true;
            DecryptRadio.Enabled = true;
            PasswordField.Enabled = true;
            PasswordField.ReadOnly = false;

            //Toggle buttons
            ConfirmButton.Visible = true;
            PauseButton.Visible = false;
            ResumeButton.Visible = false;
            CancelButton.Visible = false;
        }
    }
}
