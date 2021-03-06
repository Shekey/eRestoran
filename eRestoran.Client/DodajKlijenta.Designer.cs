﻿namespace eRestoran.Client
{
    partial class DodajKlijenta
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodajKlijenta));
            this.NaslovLabel = new System.Windows.Forms.Label();
            this.snimiKorbtn = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernamaTextBox = new System.Windows.Forms.TextBox();
            this.prezimeTextBox = new System.Windows.Forms.TextBox();
            this.imeTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PrezimeLabel = new System.Windows.Forms.Label();
            this.ImeLabel = new System.Windows.Forms.Label();
            this.telefonTextBox = new System.Windows.Forms.TextBox();
            this.telefonLabel = new System.Windows.Forms.Label();
            this.backButton1 = new eRestoran.Client.BackButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NaslovLabel
            // 
            this.NaslovLabel.AutoSize = true;
            this.NaslovLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NaslovLabel.Location = new System.Drawing.Point(193, 29);
            this.NaslovLabel.Name = "NaslovLabel";
            this.NaslovLabel.Size = new System.Drawing.Size(228, 29);
            this.NaslovLabel.TabIndex = 75;
            this.NaslovLabel.Text = "Dodavanje klijenta";
            // 
            // snimiKorbtn
            // 
            this.snimiKorbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.snimiKorbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.snimiKorbtn.ForeColor = System.Drawing.Color.White;
            this.snimiKorbtn.Location = new System.Drawing.Point(221, 334);
            this.snimiKorbtn.Name = "snimiKorbtn";
            this.snimiKorbtn.Size = new System.Drawing.Size(187, 35);
            this.snimiKorbtn.TabIndex = 74;
            this.snimiKorbtn.Text = "Snimi ";
            this.snimiKorbtn.UseVisualStyleBackColor = false;
            this.snimiKorbtn.Click += new System.EventHandler(this.snimiKorbtn_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(208, 240);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(220, 20);
            this.emailTextBox.TabIndex = 71;
            this.emailTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.emailTextBox_Validating);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(208, 203);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(220, 20);
            this.passwordTextBox.TabIndex = 70;
            this.passwordTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.passwordTextBox_Validating);
            // 
            // usernamaTextBox
            // 
            this.usernamaTextBox.Location = new System.Drawing.Point(208, 169);
            this.usernamaTextBox.Name = "usernamaTextBox";
            this.usernamaTextBox.Size = new System.Drawing.Size(220, 20);
            this.usernamaTextBox.TabIndex = 69;
            this.usernamaTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.usernamaTextBox_Validating);
            // 
            // prezimeTextBox
            // 
            this.prezimeTextBox.Location = new System.Drawing.Point(208, 133);
            this.prezimeTextBox.Name = "prezimeTextBox";
            this.prezimeTextBox.Size = new System.Drawing.Size(220, 20);
            this.prezimeTextBox.TabIndex = 68;
            this.prezimeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.prezimeTextBox_Validating);
            // 
            // imeTextBox
            // 
            this.imeTextBox.Location = new System.Drawing.Point(208, 94);
            this.imeTextBox.Name = "imeTextBox";
            this.imeTextBox.Size = new System.Drawing.Size(220, 20);
            this.imeTextBox.TabIndex = 67;
            this.imeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.imeTextBox_Validating);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.EmailLabel.Location = new System.Drawing.Point(102, 239);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(46, 18);
            this.EmailLabel.TabIndex = 66;
            this.EmailLabel.Text = "Email";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.PasswordLabel.Location = new System.Drawing.Point(100, 205);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(77, 18);
            this.PasswordLabel.TabIndex = 63;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.UsernameLabel.Location = new System.Drawing.Point(100, 171);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(80, 18);
            this.UsernameLabel.TabIndex = 62;
            this.UsernameLabel.Text = "Username";
            // 
            // PrezimeLabel
            // 
            this.PrezimeLabel.AutoSize = true;
            this.PrezimeLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.PrezimeLabel.Location = new System.Drawing.Point(100, 135);
            this.PrezimeLabel.Name = "PrezimeLabel";
            this.PrezimeLabel.Size = new System.Drawing.Size(66, 18);
            this.PrezimeLabel.TabIndex = 61;
            this.PrezimeLabel.Text = "Prezime";
            // 
            // ImeLabel
            // 
            this.ImeLabel.AutoSize = true;
            this.ImeLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.ImeLabel.Location = new System.Drawing.Point(100, 96);
            this.ImeLabel.Name = "ImeLabel";
            this.ImeLabel.Size = new System.Drawing.Size(33, 18);
            this.ImeLabel.TabIndex = 60;
            this.ImeLabel.Text = "Ime";
            // 
            // telefonTextBox
            // 
            this.telefonTextBox.Location = new System.Drawing.Point(208, 277);
            this.telefonTextBox.Name = "telefonTextBox";
            this.telefonTextBox.Size = new System.Drawing.Size(220, 20);
            this.telefonTextBox.TabIndex = 78;
            this.telefonTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.telefonTextBox_Validating);
            // 
            // telefonLabel
            // 
            this.telefonLabel.AutoSize = true;
            this.telefonLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.telefonLabel.Location = new System.Drawing.Point(100, 279);
            this.telefonLabel.Name = "telefonLabel";
            this.telefonLabel.Size = new System.Drawing.Size(62, 18);
            this.telefonLabel.TabIndex = 77;
            this.telefonLabel.Text = "Telefon";
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(103, 29);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(62, 29);
            this.backButton1.TabIndex = 76;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(513, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // DodajKlijenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.telefonTextBox);
            this.Controls.Add(this.telefonLabel);
            this.Controls.Add(this.backButton1);
            this.Controls.Add(this.NaslovLabel);
            this.Controls.Add(this.snimiKorbtn);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernamaTextBox);
            this.Controls.Add(this.prezimeTextBox);
            this.Controls.Add(this.imeTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PrezimeLabel);
            this.Controls.Add(this.ImeLabel);
            this.Name = "DodajKlijenta";
            this.Size = new System.Drawing.Size(794, 447);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BackButton backButton1;
        private System.Windows.Forms.Label NaslovLabel;
        private System.Windows.Forms.Button snimiKorbtn;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernamaTextBox;
        private System.Windows.Forms.TextBox prezimeTextBox;
        private System.Windows.Forms.TextBox imeTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PrezimeLabel;
        private System.Windows.Forms.Label ImeLabel;
        private System.Windows.Forms.TextBox telefonTextBox;
        private System.Windows.Forms.Label telefonLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
