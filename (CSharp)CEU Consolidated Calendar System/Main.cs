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


        DialogResult addYN;
        DialogResult delYN;
        DialogResult updateYN;




        MySqlDataAdapter sda = Globals.adapter;
        MySqlCommand command = Globals.command;
        MySqlDataReader reader = Globals.reader;

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            load_existing_accounts();
        }

        public void load_existing_accounts()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                query = "SELECT username from accounts";
                command = new MySqlCommand(query, conn);
                reader = command.ExecuteReader();

                acc_rlv_accounts.Items.Clear();
                while (reader.Read())
                {
                    acc_rlv_accounts.Items.Add(reader["username"]+"");
                    
                }
                conn.Close();
                
            }
            catch(Exception ex)
            {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                conn.Dispose();

            }
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
                RadMessageBox.Show(this, "Please complete the fields to register!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            else
            {

            addYN = RadMessageBox.Show(this, "Are you sure you want to register this user?","CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (addYN == DialogResult.Yes)
                {
                    if (acc_tb_password.Text != acc_tb_retypepassword.Text)
                    {
                      RadMessageBox.Show(this, "Password do not match!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            //Code Here
                            conn.Open();
                            query = "SELECT * FROM accounts WHERE (id=@acc_id) or (username=@acc_username)";
                            command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("acc_id", acc_tb_id.Text);
                            command.Parameters.AddWithValue("acc_username", acc_tb_username.Text);

                            reader = command.ExecuteReader();

                            int count = 0;

                            while (reader.Read())
                            {
                                count += 1;
                            }

                            if (count == 1)
                            {
                                RadMessageBox.Show(this, "Account " + acc_tb_id.Text + " " + acc_tb_username.Text + " is already registered!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            else
                            {
                                conn.Close();
                                conn.Open();

                                addYN = RadMessageBox.Show(this, "Are you sure you want to save?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                                if (addYN == DialogResult.Yes)
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
                            load_existing_accounts();
                        }
                    }             
                }
            }
           
        }


        //Pending because of lack of knowledge

        private void acc_btn_update_Click(object sender, EventArgs e)
        {
            //conn = new MySqlConnection();
            //conn.ConnectionString = connstring;
            //MySqlDataReader reader = default(MySqlDataReader);

            //if (conn.State == ConnectionState.Open)
            //{
            //    conn.Close();
            //}

            //updateYN = RadMessageBox.Show(this, "Are you sure you want to update this user?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            //if (updateYN == DialogResult.Yes)
            //{

            //    if ((string.IsNullOrEmpty(acc_tb_fname.Text)) | (string.IsNullOrEmpty(acc_tb_lname.Text)) | (string.IsNullOrEmpty(acc_cb_schoolorg.Text)) | (string.IsNullOrEmpty(acc_cb_usertype.Text)) | (string.IsNullOrEmpty(acc_tb_username.Text)) | (string.IsNullOrEmpty(acc_tb_password.Text)) | (string.IsNullOrEmpty(acc_tb_retypepassword.Text)))
            //    {
            //        RadMessageBox.Show(this, "Please fill all fields!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            //    }
                
            //        try
            //        {
            //            conn.Open();
            //            query = "UPDATE accounts SET password=@acc_password,schoolorg=@acc_schoolorg,fname=@acc_fname,lname=@acc_lname,usertype=@acc_usertype";
            //            command = new MySqlCommand(query, conn);
            //            command.Parameters.AddWithValue("acc_password", acc_tb_password.Text);
            //            command.Parameters.AddWithValue("acc_schoolorg", acc_cb_schoolorg.Text);
            //            command.Parameters.AddWithValue("acc_fname", acc_tb_fname.Text);
            //            command.Parameters.AddWithValue("acc_lname", acc_tb_lname.Text);
            //            command.Parameters.AddWithValue("acc_usertype", acc_cb_usertype.Text);

            //            reader = command.ExecuteReader();

            //            RadMessageBox.Show(this, "Update Complete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);

            //        }
            //        catch (Exception ex)
            //        {
            //            RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            //        }
            //        finally
            //        {
            //            conn.Dispose();
            //            acc_tb_id.Text = "";
            //            acc_tb_username.Text = "";
            //            load_accounts_table();
            //        }
            //}
}

        private void acc_btn_delete_Click(object sender, EventArgs e)
        {
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                MySqlDataReader reader = default(MySqlDataReader);

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                delYN = RadMessageBox.Show(this, "Are you sure you want to delete this user?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (delYN == DialogResult.Yes)
                {

                    if ((string.IsNullOrEmpty(acc_tb_id.Text)) | (string.IsNullOrEmpty(acc_tb_username.Text)))
                    {
                        RadMessageBox.Show(this, "Please select user to delete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            conn.Open();
                            query = "DELETE FROM accounts where id=@acc_id and username=@acc_username";
                            command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("acc_id", acc_tb_id.Text);
                            command.Parameters.AddWithValue("acc_username", acc_tb_username.Text);

                            reader = command.ExecuteReader();

                            RadMessageBox.Show(this, "Deletion Complete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);


                        }
                        catch (Exception ex)
                        {
                            RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        finally
                        {
                            conn.Dispose();
                            acc_clearall_fields();
                            load_existing_accounts();
                        }
                    }
                }
            }
        }

     
        private void acc_btn_clear_Click(object sender, EventArgs e)
        {
            acc_clearall_fields();
        }
        public void acc_clearall_fields()
        {
            acc_tb_id.Text = "";
            acc_tb_lname.Text = "";
            acc_tb_fname.Text = "";
            acc_tb_username.Text = "";
            acc_tb_password.Text = "";
            acc_tb_retypepassword.Text = "";
            acc_cb_usertype.Text = "";
            acc_cb_schoolorg.Text = "";
            acc_tb_id.Enabled = true;
            acc_tb_username.Enabled = true;
        }

        private void acc_rlv_accounts_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            command = new MySqlCommand();
            MySqlDataReader reader = default(MySqlDataReader);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                query = "SELECT * from accounts where username=@acc_username";
                command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("acc_username", acc_rlv_accounts.SelectedItem);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    acc_tb_id.Enabled = false;
                    acc_tb_id.Text = reader.GetString("id");
                    acc_cb_usertype.Text = reader.GetString("usertype");
                    acc_tb_fname.Text = reader.GetString("fname");
                    acc_tb_lname.Text = reader.GetString("lname");
                    acc_cb_schoolorg.Text = reader.GetString("schoolorg");
                    acc_tb_username.Enabled = false;
                    acc_tb_username.Text = reader.GetString("username");
                   
                }
                conn.Close();
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
