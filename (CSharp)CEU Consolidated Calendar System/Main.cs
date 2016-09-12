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
    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        MySqlConnection conn;

        string connstring = Globals.connstring;
        string query;
       

        DialogResult addyn;

        MySqlCommand command = Globals.command;
        MySqlDataReader reader = Globals.reader;

        public Main()
        {
            InitializeComponent();
        }

        private void acc_btn_save_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            if ((string.IsNullOrEmpty(acc_tb_id.Text)) | (string.IsNullOrEmpty(acc_tb_fname.Text)) | (string.IsNullOrEmpty(acc_tb_lname.Text)) | (string.IsNullOrEmpty(acc_cb_schoolorg.Text)) | (string.IsNullOrEmpty(acc_cb_usertype.Text)) | (string.IsNullOrEmpty(acc_tb_username.Text)) | (string.IsNullOrEmpty(acc_tb_password.Text)) | (string.IsNullOrEmpty(acc_tb_retypepassword.Text)))
            {
                RadMessageBox.Show(this, "Please complete the fields to update!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error);
            }else
            {
                try
                {
                    //Code Here
                    conn.Open();
                    query = "SELECT * FROM accounts WHERE (id=@acc_id)";
                    command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("acc_id", acc_tb_id.Text);

                    reader = command.ExecuteReader();

                    int count = 0;

                    while (reader.Read())
                    {
                        count += 1;
                    }

                    if (count == 1)
                    {
                        RadMessageBox.Show(this, "Account " + acc_tb_id.Text + " is already registered!","CEU Consolidated Calendar",MessageBoxButtons.OK,RadMessageIcon.Error);
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();

                        addyn = RadMessageBox.Show(this, "Are you sure you want to save?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                        if (addyn== DialogResult.Yes)
                        {
                            query = "INSERT INTO `accounts` VALUES (@acc_id,@acc_fname,@acc_lname,@acc_schoolorg,@acc_usertype,@acc_username,@acc_password)";
                            command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("acc_id", acc_tb_id.Text);
                            command.Parameters.AddWithValue("acc_fname", acc_tb_fname.Text);
                            command.Parameters.AddWithValue("acc_lname", acc_tb_lname.Text);
                            command.Parameters.AddWithValue("acc_schoolorg", acc_cb_schoolorg.Text);
                            command.Parameters.AddWithValue("acc_usertype", acc_cb_usertype.Text);
                            command.Parameters.AddWithValue("acc_username", acc_tb_username.Text);
                            command.Parameters.AddWithValue("acc_password", acc_tb_password.Text);

                            reader = command.ExecuteReader();

                            RadMessageBox.Show(this, "Account Registered!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);
                            conn.Close();
                        }
                        
                    }
                    
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                finally
                {
                    conn.Dispose();
                }
            }



            }
    }
}
