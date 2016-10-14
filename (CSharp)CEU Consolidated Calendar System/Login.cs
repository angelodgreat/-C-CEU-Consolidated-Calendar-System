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
       
        globalvariables gb = new globalvariables();
        
       
        string query;
        bool a;

       
       

        DialogResult closeYN;



        public Login() {
            InitializeComponent();
         
        }

        private void Login_Load(object sender, EventArgs e) {
            timerandstatus(false);
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

        public void timerandstatus(Boolean retry) {
            log_timer.Enabled = true;

            a = new bool();
            a = false;
            conn = new MySqlConnection();
            conn.ConnectionString = gb.connstring;

            
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
            MySqlCommand command = gb.command;
            MySqlDataReader reader = gb.reader;

            try {
                int looper = 0;
                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }


                if((string.IsNullOrEmpty(log_tb_username.Text) | (string.IsNullOrEmpty(log_tb_password.Text)))) {
                    RadMessageBox.Show(this, "Please enter username and password.", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else {




                    conn.ConnectionString = gb.connstring;
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
                        this.Hide();
                        main.ShowDialog();
                       
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


            this.Hide();
            main.ShowDialog();
            
        }

      
        private void log_btn_connection_Click(object sender, EventArgs e) {
            DBConnection dbcon = new DBConnection();
            this.Hide();
            dbcon.ShowDialog();
           

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }
    }
}
