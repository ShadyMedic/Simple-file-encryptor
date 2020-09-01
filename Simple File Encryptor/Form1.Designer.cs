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
            this.components = new System.ComponentModel.Container();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TogglePasswordButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.performanceSlider = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.performanceWarning = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.performanceSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "All files|*.*";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Choose the file to encrypt or decrypt";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // FilepathField
            // 
            this.FilepathField.Enabled = false;
            this.FilepathField.Location = new System.Drawing.Point(107, 33);
            this.FilepathField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FilepathField.Name = "FilepathField";
            this.FilepathField.Size = new System.Drawing.Size(227, 22);
            this.FilepathField.TabIndex = 0;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Enabled = false;
            this.BrowseButton.Location = new System.Drawing.Point(341, 33);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 25);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(107, 62);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '•';
            this.PasswordField.Size = new System.Drawing.Size(227, 22);
            this.PasswordField.TabIndex = 4;
            this.PasswordField.TextChanged += new System.EventHandler(this.PasswordField_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConfirmButton.Location = new System.Drawing.Point(16, 150);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(400, 52);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path to file";
            // 
            // EncryptRadio
            // 
            this.EncryptRadio.AutoSize = true;
            this.EncryptRadio.Location = new System.Drawing.Point(107, 8);
            this.EncryptRadio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EncryptRadio.Name = "EncryptRadio";
            this.EncryptRadio.Size = new System.Drawing.Size(77, 21);
            this.EncryptRadio.TabIndex = 7;
            this.EncryptRadio.Text = "Encrypt";
            this.EncryptRadio.UseVisualStyleBackColor = true;
            this.EncryptRadio.Click += new System.EventHandler(this.ActionRadio_CheckedChanged);
            // 
            // DecryptRadio
            // 
            this.DecryptRadio.AutoSize = true;
            this.DecryptRadio.Location = new System.Drawing.Point(256, 7);
            this.DecryptRadio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DecryptRadio.Name = "DecryptRadio";
            this.DecryptRadio.Size = new System.Drawing.Size(78, 21);
            this.DecryptRadio.TabIndex = 8;
            this.DecryptRadio.Text = "Decrypt";
            this.DecryptRadio.UseVisualStyleBackColor = true;
            this.DecryptRadio.Click += new System.EventHandler(this.ActionRadio_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Operation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ProgressBar.Location = new System.Drawing.Point(16, 206);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgressBar.MarqueeAnimationSpeed = 0;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(399, 23);
            this.ProgressBar.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(13, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 34);
            this.label4.TabIndex = 13;
            this.label4.Text = "Created by Jan Štěch in August 2020.\r\n\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(405, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Application created for www.ict.social summer competition 2020";
            // 
            // TogglePasswordButton
            // 
            this.TogglePasswordButton.Location = new System.Drawing.Point(341, 60);
            this.TogglePasswordButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TogglePasswordButton.Name = "TogglePasswordButton";
            this.TogglePasswordButton.Size = new System.Drawing.Size(75, 26);
            this.TogglePasswordButton.TabIndex = 16;
            this.TogglePasswordButton.Text = "👓";
            this.TogglePasswordButton.UseVisualStyleBackColor = true;
            this.TogglePasswordButton.Click += new System.EventHandler(this.TogglePasswordButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Performance";
            // 
            // performanceSlider
            // 
            this.performanceSlider.Location = new System.Drawing.Point(108, 89);
            this.performanceSlider.Maximum = 500000;
            this.performanceSlider.Minimum = 1;
            this.performanceSlider.Name = "performanceSlider";
            this.performanceSlider.Size = new System.Drawing.Size(226, 56);
            this.performanceSlider.TabIndex = 18;
            this.performanceSlider.TickFrequency = 50000;
            this.performanceWarning.SetToolTip(this.performanceSlider, "Higher speed might slightly slow down your device, since more RAM will be used fo" +
        "r encryption or decryption.");
            this.performanceSlider.Value = 100000;
            this.performanceSlider.ValueChanged += new System.EventHandler(this.PerformanceSlider_Change);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Slow";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Fast";
            // 
            // performanceWarning
            // 
            this.performanceWarning.AutomaticDelay = 50;
            this.performanceWarning.AutoPopDelay = 0;
            this.performanceWarning.InitialDelay = 50;
            this.performanceWarning.ReshowDelay = 10;
            this.performanceWarning.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // MainForm
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 273);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.performanceSlider);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TogglePasswordButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Simple File Encryptor";
            ((System.ComponentModel.ISupportInitialize)(this.performanceSlider)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button TogglePasswordButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar performanceSlider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip performanceWarning;
    }
}

