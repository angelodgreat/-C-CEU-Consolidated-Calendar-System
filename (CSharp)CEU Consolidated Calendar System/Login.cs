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

namespace _CSharp_CEU_Consolidated_Calendar_System
{
    public partial class Login : Telerik.WinControls.UI.RadForm {
        MySqlConnection conn;
        int db_is_deadCount = 0;
        string connstring = Globals.connstring;
        string query;
        bool a;
        MySqlCommand command = Globals.command;
        MySqlDataReader reader = Globals.reader;

        DialogResult closeYN;



        public Login() {
            InitializeComponent();
         
        }

        private void Login_Load(object sender, EventArgs e) {
            timerandstatus();
            ThemeResolutionService.ApplicationThemeName = "VisualStudio2012Dark";
           
        }

        // private void btn_testconnection_Click(object sender, EventArgs e)
        // {
        //     try
        //     {
        //         conn = new MySqlConnection();
        //         conn.ConnectionString = connstring;
        //         conn.Open();
        //         MessageBox.Show("Connection Success");

        //         query = "SELECT * FROM saouserinfo";
        //         command = new MySqlCommand(query, conn);
        //         reader = command.ExecuteReader();

        //         while (reader.Read())
        //         {
        //             lbl_test.Text = (reader["id"] + "");
        //         }
        //         conn.Close();


        //     }
        //     catch (Exception ex)
        //     {
        //         MessageBox.Show(ex.Message);
        //     }
        //     finally
        //     {
        //         conn.Dispose();
        //     }

        //}

        public void timerandstatus() {
            log_timer.Enabled = true;

            a = new bool();
            a = false;
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;

            try {
                conn.Open();
                a = true;
                conn.Close();
            }
            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

            finally {
                conn.Dispose();
                if(a == true) {
                    log_lbl_status.Text = "Online";
                    log_lbl_status.ForeColor = Color.Green;

                }
                else {
                    log_lbl_status.Text = "Offline";
                    log_lbl_status.ForeColor = Color.Red;
                }
            }

        }

        private void log_btn_login_Click(object sender, EventArgs e) {
            Main main = new Main();

            try {
                int looper = 0;
                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }


                if((string.IsNullOrEmpty(log_tb_username.Text) | (string.IsNullOrEmpty(log_tb_password.Text)))) {
                    RadMessageBox.Show(this, "Please enter username and password.", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else {




                    conn.ConnectionString = connstring;
                    conn.Open();

                    query = "SELECT * from accounts WHERE username=@username AND password=@password";
                    command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("username", log_tb_username.Text);
                    command.Parameters.AddWithValue("password", log_tb_password.Text);
                    reader = command.ExecuteReader();

                    while(reader.Read()) {
                        looper += 1;
                        log_tb_username.Text = reader.GetString("username");
                        log_tb_password.Text = reader.GetString("password");
                    }

                    conn.Close();
                    log_tb_username.Text = string.Empty;
                    log_tb_password.Text = string.Empty;
                    log_tb_username.Select();

                    if(looper == 1) {
                        main.Show();
                        this.Hide();
                    }
                    else {
                        RadMessageBox.Show(this, "Incorrect Username or Password.", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }

                }
            }
            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally {
                conn.Dispose();
            }
        }

        private void log_btn_bypass_Click(object sender, EventArgs e) {
            Main main = new Main();

            main.Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e) {
            closeYN = RadMessageBox.Show(this, "Are you sure you want to quit?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);
            if(closeYN == DialogResult.Yes) {
                this.Dispose();
            }
            else {
                e.Cancel = true;
            }
        }
    }
}
