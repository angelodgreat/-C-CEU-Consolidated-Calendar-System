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
    public partial class Login : Telerik.WinControls.UI.RadForm
    {
        MySqlConnection conn;

        string connstring = Globals.connstring;
        string query;
        bool a;
        MySqlCommand command = Globals.command;
        MySqlDataReader reader = Globals.reader;

        Main main = new Main();
       

        public Login()
        {
            InitializeComponent();
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
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

        public void timerandstatus()
        {
            log_timer.Enabled = true;

            a = new bool();
            a = false;
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;

            try
            {
                conn.Open();
                a = true;
                conn.Close();
            }
            catch (Exception ex)
            {

            }

            finally
            {
                conn.Dispose();
                if (a == true) {
                    log_lbl_status.Text = "Online";
                    log_lbl_status.ForeColor = Color.Green;

                }
                else
                {
                    log_lbl_status.Text = "Offline";
                    log_lbl_status.ForeColor = Color.Red;
                }
            }
            
        }

        private void log_btn_login_Click(object sender, EventArgs e)
        {

          
            main.Show();
            this.Hide();


            try
            {
                //Codes Here
                conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();


            }
            catch
            {
                //Codes Here
            }
            finally
            {
                //Codes Here
            }
        }

      
    }
}
