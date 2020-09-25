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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PauseButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
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
            this.FilepathField.Location = new System.Drawing.Point(80, 27);
            this.FilepathField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FilepathField.Name = "FilepathField";
            this.FilepathField.Size = new System.Drawing.Size(212, 20);
            this.FilepathField.TabIndex = 0;
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(80, 50);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '•';
            this.PasswordField.Size = new System.Drawing.Size(212, 20);
            this.PasswordField.TabIndex = 4;
            this.PasswordField.TextChanged += new System.EventHandler(this.PasswordField_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ConfirmButton.FlatAppearance.BorderSize = 2;
            this.ConfirmButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(255)))));
            this.ConfirmButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConfirmButton.Location = new System.Drawing.Point(12, 122);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(300, 42);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Path to file";
            // 
            // EncryptRadio
            // 
            this.EncryptRadio.AutoSize = true;
            this.EncryptRadio.Location = new System.Drawing.Point(80, 6);
            this.EncryptRadio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EncryptRadio.Name = "EncryptRadio";
            this.EncryptRadio.Size = new System.Drawing.Size(61, 17);
            this.EncryptRadio.TabIndex = 7;
            this.EncryptRadio.Text = "Encrypt";
            this.EncryptRadio.UseVisualStyleBackColor = true;
            this.EncryptRadio.Click += new System.EventHandler(this.ActionRadio_CheckedChanged);
            // 
            // DecryptRadio
            // 
            this.DecryptRadio.AutoSize = true;
            this.DecryptRadio.Location = new System.Drawing.Point(192, 6);
            this.DecryptRadio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DecryptRadio.Name = "DecryptRadio";
            this.DecryptRadio.Size = new System.Drawing.Size(62, 17);
            this.DecryptRadio.TabIndex = 8;
            this.DecryptRadio.Text = "Decrypt";
            this.DecryptRadio.UseVisualStyleBackColor = true;
            this.DecryptRadio.Click += new System.EventHandler(this.ActionRadio_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Operation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ProgressBar.ForeColor = System.Drawing.Color.Lime;
            this.ProgressBar.Location = new System.Drawing.Point(12, 167);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProgressBar.MarqueeAnimationSpeed = 500;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(299, 19);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(10, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Created by Jan Štěch in August 2020.\r\n\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 202);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Application created for www.ict.social summer competition 2020";
            // 
            // TogglePasswordButton
            // 
            this.TogglePasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.TogglePasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TogglePasswordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(255)))));
            this.TogglePasswordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TogglePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TogglePasswordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.TogglePasswordButton.Location = new System.Drawing.Point(292, 50);
            this.TogglePasswordButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TogglePasswordButton.Name = "TogglePasswordButton";
            this.TogglePasswordButton.Size = new System.Drawing.Size(20, 20);
            this.TogglePasswordButton.TabIndex = 16;
            this.TogglePasswordButton.Text = "👁";
            this.TogglePasswordButton.UseVisualStyleBackColor = false;
            this.TogglePasswordButton.Click += new System.EventHandler(this.TogglePasswordButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 76);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Performance";
            // 
            // performanceSlider
            // 
            this.performanceSlider.Location = new System.Drawing.Point(81, 72);
            this.performanceSlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.performanceSlider.Maximum = 500000;
            this.performanceSlider.Minimum = 1;
            this.performanceSlider.Name = "performanceSlider";
            this.performanceSlider.Size = new System.Drawing.Size(211, 45);
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
            this.label7.Location = new System.Drawing.Point(79, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Slow";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
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
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PauseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PauseButton.FlatAppearance.BorderSize = 2;
            this.PauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.PauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.PauseButton.Location = new System.Drawing.Point(12, 122);
            this.PauseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(146, 42);
            this.PauseButton.TabIndex = 21;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Visible = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CancelButton.FlatAppearance.BorderSize = 2;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.CancelButton.Location = new System.Drawing.Point(165, 122);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(146, 42);
            this.CancelButton.TabIndex = 22;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ResumeButton
            // 
            this.ResumeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ResumeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ResumeButton.FlatAppearance.BorderSize = 2;
            this.ResumeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
            this.ResumeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ResumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.ResumeButton.Location = new System.Drawing.Point(12, 122);
            this.ResumeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(146, 42);
            this.ResumeButton.TabIndex = 23;
            this.ResumeButton.Text = "Resume";
            this.ResumeButton.UseVisualStyleBackColor = false;
            this.ResumeButton.Visible = false;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BrowseButton.Enabled = false;
            this.BrowseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(255)))));
            this.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrowseButton.Location = new System.Drawing.Point(292, 27);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(20, 20);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "📂";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 222);
            this.Controls.Add(this.ResumeButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PauseButton);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button BrowseButton;
    }
}

