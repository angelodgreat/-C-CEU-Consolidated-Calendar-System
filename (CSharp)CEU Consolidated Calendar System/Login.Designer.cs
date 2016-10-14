namespace _CSharp_CEU_Consolidated_Calendar_System
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.log_btn_bypass = new Telerik.WinControls.UI.RadButton();
            this.log_lbl_status = new Telerik.WinControls.UI.RadLabel();
            this.log_btn_login = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.log_tb_password = new Telerik.WinControls.UI.RadTextBox();
            this.log_tb_username = new Telerik.WinControls.UI.RadTextBox();
            this.log_timer = new System.Windows.Forms.Timer(this.components);
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.log_btn_connection = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_btn_bypass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_lbl_status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_btn_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_tb_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_tb_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_btn_connection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.log_btn_bypass);
            this.radGroupBox1.Controls.Add(this.log_lbl_status);
            this.radGroupBox1.Controls.Add(this.log_btn_login);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.log_tb_password);
            this.radGroupBox1.Controls.Add(this.log_tb_username);
            this.radGroupBox1.HeaderText = "Login";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 82);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(341, 176);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Login";
            this.radGroupBox1.ThemeName = "VisualStudio2012Dark";
            // 
            // log_btn_bypass
            // 
            this.log_btn_bypass.Location = new System.Drawing.Point(118, 119);
            this.log_btn_bypass.Name = "log_btn_bypass";
            this.log_btn_bypass.Size = new System.Drawing.Size(97, 26);
            this.log_btn_bypass.TabIndex = 6;
            this.log_btn_bypass.Text = "Bypass Login";
            this.log_btn_bypass.ThemeName = "VisualStudio2012Dark";
            this.log_btn_bypass.Click += new System.EventHandler(this.log_btn_bypass_Click);
            // 
            // log_lbl_status
            // 
            this.log_lbl_status.Location = new System.Drawing.Point(299, 21);
            this.log_lbl_status.Name = "log_lbl_status";
            this.log_lbl_status.Size = new System.Drawing.Size(37, 18);
            this.log_lbl_status.TabIndex = 5;
            this.log_lbl_status.Text = "Status";
            this.log_lbl_status.ThemeName = "VisualStudio2012Dark";
            // 
            // log_btn_login
            // 
            this.log_btn_login.Location = new System.Drawing.Point(221, 119);
            this.log_btn_login.Name = "log_btn_login";
            this.log_btn_login.Size = new System.Drawing.Size(97, 26);
            this.log_btn_login.TabIndex = 4;
            this.log_btn_login.Text = "Login";
            this.log_btn_login.ThemeName = "VisualStudio2012Dark";
            this.log_btn_login.Click += new System.EventHandler(this.log_btn_login_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(21, 95);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(56, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Password:";
            this.radLabel2.ThemeName = "VisualStudio2012Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(18, 65);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Username:";
            this.radLabel1.ThemeName = "VisualStudio2012Dark";
            // 
            // log_tb_password
            // 
            this.log_tb_password.Location = new System.Drawing.Point(83, 89);
            this.log_tb_password.MinimumSize = new System.Drawing.Size(0, 24);
            this.log_tb_password.Name = "log_tb_password";
            this.log_tb_password.PasswordChar = '*';
            // 
            // 
            // 
            this.log_tb_password.RootElement.MinSize = new System.Drawing.Size(0, 24);
            this.log_tb_password.Size = new System.Drawing.Size(235, 24);
            this.log_tb_password.TabIndex = 2;
            this.log_tb_password.ThemeName = "VisualStudio2012Dark";
            // 
            // log_tb_username
            // 
            this.log_tb_username.Location = new System.Drawing.Point(83, 59);
            this.log_tb_username.MinimumSize = new System.Drawing.Size(0, 24);
            this.log_tb_username.Name = "log_tb_username";
            // 
            // 
            // 
            this.log_tb_username.RootElement.MinSize = new System.Drawing.Size(0, 24);
            this.log_tb_username.Size = new System.Drawing.Size(235, 24);
            this.log_tb_username.TabIndex = 0;
            this.log_tb_username.ThemeName = "VisualStudio2012Dark";
            // 
            // log_btn_connection
            // 
            this.log_btn_connection.Image = global::_CSharp_CEU_Consolidated_Calendar_System.Properties.Resources.settings;
            this.log_btn_connection.Location = new System.Drawing.Point(284, 12);
            this.log_btn_connection.Name = "log_btn_connection";
            this.log_btn_connection.Size = new System.Drawing.Size(64, 64);
            this.log_btn_connection.TabIndex = 0;
            this.log_btn_connection.TabStop = false;
            this.log_btn_connection.Click += new System.EventHandler(this.log_btn_connection_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 265);
            this.Controls.Add(this.log_btn_connection);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ThemeName = "VisualStudio2012Dark";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.log_btn_bypass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_lbl_status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_btn_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_tb_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_tb_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.log_btn_connection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadButton log_btn_login;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox log_tb_password;
        private Telerik.WinControls.UI.RadTextBox log_tb_username;
        private System.Windows.Forms.Timer log_timer;
        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadLabel log_lbl_status;
        private Telerik.WinControls.UI.RadButton log_btn_bypass;
        private System.Windows.Forms.PictureBox log_btn_connection;
    }
}
