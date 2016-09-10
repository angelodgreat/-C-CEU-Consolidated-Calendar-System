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

        MySqlCommand command = Globals.command;
        MySqlDataReader reader = Globals.reader;
        


        public Login()
        {
            InitializeComponent();
        }

        private void btn_testconnection_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                conn.Open();
                MessageBox.Show("Connection Success");

                query = "SELECT * FROM saouserinfo";
                command = new MySqlCommand(query, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lbl_test.Text = (reader["id"] + "");
                }
                conn.Close();


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Dispose();
            }
                   
       }

        private void log_btn_login_Click(object sender, EventArgs e)
        {

        }
    }
}
