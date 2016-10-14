using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MySql.Data.MySqlClient;
using Telerik.WinControls.UI;
using System.Security.AccessControl;
using System.Diagnostics;

namespace _CSharp_CEU_Consolidated_Calendar_System
{
    public partial class DBConnection : Telerik.WinControls.UI.RadForm
    {

        globalvariables gb = new globalvariables();

        MySqlConnection conn;
     
      
       

        DialogResult DBSettingChange;

        public DBConnection()
        {
            InitializeComponent();

        }

        private void DBConnection_Load(object sender, EventArgs e) {
            db_tb_server.Text = Properties.Settings.Default.server;
            db_tb_port.Text = Properties.Settings.Default.port;
            db_tb_database.Text = Properties.Settings.Default.database;
        }

        private void db_btn_save_Click(object sender, EventArgs e) {
            Login login = new Login();
          
            

            DBSettingChange = RadMessageBox.Show(this, "Are you sure you want to apply the new settings?" + Environment.NewLine + Environment.NewLine + "If you are not the network administrator it is advisable to choose "+"No"+"","Database Settings", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);

            

            if(DBSettingChange == DialogResult.Yes) {
                Properties.Settings.Default.server = db_tb_server.Text;
                Properties.Settings.Default.port = db_tb_port.Text;
                Properties.Settings.Default.database = db_tb_database.Text;
               

                if ((string.IsNullOrEmpty(db_tb_username.Text) | (string.IsNullOrEmpty(db_tb_password.Text)))){
                    
                } else {
                    Properties.Settings.Default.username = Actions.Encrypt(db_tb_username.Text);
                    Properties.Settings.Default.password = Actions.Encrypt(db_tb_password.Text);
                    Properties.Settings.Default.Save();
                }
                Properties.Settings.Default.Save();

           
                login.timerandstatus(false);
                Process.Start(Application.ExecutablePath);
                System.Environment.Exit(1);




            } else {
                login.Show();
                this.Dispose();





            }
        }

        private void DBConnection_FormClosing(object sender, FormClosingEventArgs e) {

            Login login = new Login();
            login.Show();
            this.Dispose();




        }
    }
}
