namespace File_encoder
{
    partial class MainForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FilepathField = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EncryptRadio = new System.Windows.Forms.RadioButton();
            this.DecryptRadio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressCheckbox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TogglePasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "All files|*.*";
            this.openFileDialog.InitialDirectory = "C:";
            this.openFileDialog.Title = "Choose the file to encrypt or decrypt";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // FilepathField
            // 
            this.FilepathField.Location = new System.Drawing.Point(94, 12);
            this.FilepathField.Name = "FilepathField";
            this.FilepathField.Size = new System.Drawing.Size(242, 22);
            this.FilepathField.TabIndex = 0;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(342, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(94, 71);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '•';
            this.PasswordField.Size = new System.Drawing.Size(213, 22);
            this.PasswordField.TabIndex = 4;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(342, 71);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path to file";
            // 
            // EncryptRadio
            // 
            this.EncryptRadio.AutoSize = true;
            this.EncryptRadio.Location = new System.Drawing.Point(94, 44);
            this.EncryptRadio.Name = "EncryptRadio";
            this.EncryptRadio.Size = new System.Drawing.Size(77, 21);
            this.EncryptRadio.TabIndex = 7;
            this.EncryptRadio.Text = "Encrypt";
            this.EncryptRadio.UseVisualStyleBackColor = true;
            // 
            // DecryptRadio
            // 
            this.DecryptRadio.AutoSize = true;
            this.DecryptRadio.Location = new System.Drawing.Point(218, 44);
            this.DecryptRadio.Name = "DecryptRadio";
            this.DecryptRadio.Size = new System.Drawing.Size(78, 21);
            this.DecryptRadio.TabIndex = 8;
            this.DecryptRadio.Text = "Decrypt";
            this.DecryptRadio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Operation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ProgressBar.Location = new System.Drawing.Point(16, 126);
            this.ProgressBar.MarqueeAnimationSpeed = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(401, 23);
            this.ProgressBar.TabIndex = 11;
            // 
            // progressCheckbox
            // 
            this.progressCheckbox.AutoSize = true;
            this.progressCheckbox.Location = new System.Drawing.Point(16, 99);
            this.progressCheckbox.Name = "progressCheckbox";
            this.progressCheckbox.Size = new System.Drawing.Size(340, 21);
            this.progressCheckbox.TabIndex = 12;
            this.progressCheckbox.Text = "Display progress in a progress bar (big files only)";
            this.progressCheckbox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(13, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 34);
            this.label4.TabIndex = 13;
            this.label4.Text = "Created by Jan Štěch in August 2020.\r\n\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(405, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Application created for www.ict.social summer competition 2020";
            // 
            // TogglePasswordButton
            // 
            this.TogglePasswordButton.Location = new System.Drawing.Point(313, 71);
            this.TogglePasswordButton.Name = "TogglePasswordButton";
            this.TogglePasswordButton.Size = new System.Drawing.Size(23, 23);
            this.TogglePasswordButton.TabIndex = 16;
            this.TogglePasswordButton.Text = "👓";
            this.TogglePasswordButton.UseVisualStyleBackColor = true;
            this.TogglePasswordButton.Click += new System.EventHandler(this.TogglePasswordButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 194);
            this.Controls.Add(this.TogglePasswordButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressCheckbox);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DecryptRadio);
            this.Controls.Add(this.EncryptRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.FilepathField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Simple File Encryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox FilepathField;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton EncryptRadio;
        private System.Windows.Forms.RadioButton DecryptRadio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.CheckBox progressCheckbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button TogglePasswordButton;
    }
}

