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


namespace _CSharp_CEU_Consolidated_Calendar_System {
    public partial class Main : Telerik.WinControls.UI.RadForm {
        MySqlConnection conn;

        string connstring = Globals.connstring;
        string query;


        DialogResult addYN;
        DialogResult delYN;
        DialogResult updateYN;
        DialogResult reserveYN;
        DialogResult closeYN;

        public string identifier_reservationno;
        public System.Random random = new System.Random();
       
      
        

        MySqlCommand command = Globals.command;
        MySqlDataReader reader = Globals.reader;

        public Main() {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e) {
            //Accounts
            acc_load_existing_accounts();
            acc_btn_delete.Hide();
            acc_btn_update.Hide();

            //Events
            auto_generate_eventid();
            evt_load_datafromgrid();
            evt_dtp_date.Value = System.DateTime.Now;
            evt_tb_eventno.Enabled = false;
            addalllocsrange();

            //Home
            home_load_datafromgrid();
            home_dtp_startdate.Value = System.DateTime.Now;
            home_dtp_enddate.Value = System.DateTime.Now;
        }

        //Account Management Code loading all existing accounts in Listbox

        public void acc_load_existing_accounts() {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }

            try {
                conn.Open();
                query = "SELECT username from accounts";
                command = new MySqlCommand(query, conn);
                reader = command.ExecuteReader();

                acc_rlv_accounts.Items.Clear();
                while(reader.Read()) {
                    acc_rlv_accounts.Items.Add(reader["username"] + "");

                }
                conn.Close();

            }
            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally {
                conn.Dispose();

            }
        }

        //Account Management Code button to save account

        private void acc_btn_save_Click(object sender, EventArgs e) {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }
            if((string.IsNullOrEmpty(acc_tb_id.Text)) | (string.IsNullOrEmpty(acc_tb_fname.Text)) | (string.IsNullOrEmpty(acc_tb_lname.Text)) | (string.IsNullOrEmpty(acc_cb_schoolorg.Text)) | (string.IsNullOrEmpty(acc_cb_usertype.Text)) | (string.IsNullOrEmpty(acc_tb_username.Text)) | (string.IsNullOrEmpty(acc_tb_password.Text)) | (string.IsNullOrEmpty(acc_tb_retypepassword.Text))) {
                RadMessageBox.Show(this, "Please complete the fields to register!", "TLTD Scheduling Management", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            else {

                addYN = RadMessageBox.Show(this, "Are you sure you want to register this user?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if(addYN == DialogResult.Yes) {
                    if(acc_tb_password.Text != acc_tb_retypepassword.Text) {
                        RadMessageBox.Show(this, "Password do not match!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else {
                        try {
                            //Code Here
                            conn.Open();
                            query = "SELECT * FROM accounts WHERE (id=@acc_id) or (username=@acc_username)";
                            command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("acc_id", acc_tb_id.Text);
                            command.Parameters.AddWithValue("acc_username", acc_tb_username.Text);

                            reader = command.ExecuteReader();

                            int count = 0;

                            while(reader.Read()) {
                                count += 1;
                            }

                            if(count == 1) {
                                RadMessageBox.Show(this, "Account " + acc_tb_id.Text + " " + acc_tb_username.Text + " is already registered!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            else {
                                conn.Close();
                                conn.Open();

                                addYN = RadMessageBox.Show(this, "Are you sure you want to save?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);

                                if(addYN == DialogResult.Yes) {
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
                        catch(Exception ex) {
                            RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        finally {
                            conn.Dispose();
                            acc_load_existing_accounts();
                        }
                    }
                }
            }

        }


        //Pending because of lack of knowledge

        private void acc_btn_update_Click(object sender, EventArgs e) {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }

            updateYN = RadMessageBox.Show(this, "Are you sure you want to update this user?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if(updateYN == DialogResult.Yes) {

                if((string.IsNullOrEmpty(acc_tb_fname.Text)) | (string.IsNullOrEmpty(acc_tb_lname.Text)) | (string.IsNullOrEmpty(acc_cb_schoolorg.Text)) | (string.IsNullOrEmpty(acc_cb_usertype.Text)) | (string.IsNullOrEmpty(acc_tb_username.Text)) | (string.IsNullOrEmpty(acc_tb_password.Text)) | (string.IsNullOrEmpty(acc_tb_retypepassword.Text))) {
                    RadMessageBox.Show(this, "Please fill all fields!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else {
                    try {
                        conn.Open();
                        query = "UPDATE accounts SET password=@acc_password,schoolorg=@acc_schoolorg,fname=@acc_fname,lname=@acc_lname,usertype=@acc_usertype";
                        command = new MySqlCommand(query, conn);
                        command.Parameters.AddWithValue("acc_password", acc_tb_password.Text);
                        command.Parameters.AddWithValue("acc_schoolorg", acc_cb_schoolorg.Text);
                        command.Parameters.AddWithValue("acc_fname", acc_tb_fname.Text);
                        command.Parameters.AddWithValue("acc_lname", acc_tb_lname.Text);
                        command.Parameters.AddWithValue("acc_usertype", acc_cb_usertype.Text);

                        if(acc_tb_password.Text != acc_tb_retypepassword.Text) {
                            RadMessageBox.Show(this, "Password do not match!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        else {
                            reader = command.ExecuteReader();
                            RadMessageBox.Show(this, "Update Complete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);
                        }

                    }
                    catch(Exception ex) {
                        RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    finally {
                        conn.Dispose();
                        acc_load_existing_accounts();
                    }


                }


            }
        }

        //Account Management Code Deleting account
        private void acc_btn_delete_Click(object sender, EventArgs e) {
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstring;
                MySqlDataReader reader = default(MySqlDataReader);

                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }

                delYN = RadMessageBox.Show(this, "Are you sure you want to delete this user?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if(delYN == DialogResult.Yes) {

                    if((string.IsNullOrEmpty(acc_tb_id.Text)) | (string.IsNullOrEmpty(acc_tb_username.Text))) {
                        RadMessageBox.Show(this, "Please select user to delete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else {
                        try {
                            conn.Open();
                            query = "DELETE FROM accounts where id=@acc_id and username=@acc_username";
                            command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("acc_id", acc_tb_id.Text);
                            command.Parameters.AddWithValue("acc_username", acc_tb_username.Text);

                            reader = command.ExecuteReader();

                            RadMessageBox.Show(this, "Deletion Complete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);


                        }
                        catch(Exception ex) {
                            RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        finally {
                            conn.Dispose();
                            acc_clearall_fields();
                            acc_load_existing_accounts();
                        }
                    }
                }
            }
        }


        //Account Management Code Clearing all fields
        private void acc_btn_clear_Click(object sender, EventArgs e) {
            acc_clearall_fields();
            acc_load_existing_accounts();
        }

        //Account Management Code Clearing all fields main code
        public void acc_clearall_fields() {
            acc_tb_id.Enabled = true;
            acc_tb_username.Enabled = true;
            acc_btn_delete.Hide();
            acc_btn_update.Hide();
            acc_tb_id.Text = "";
            acc_tb_lname.Text = "";
            acc_tb_fname.Text = "";
            acc_tb_username.Text = "";
            acc_tb_password.Text = "";
            acc_tb_retypepassword.Text = "";
            acc_cb_usertype.Text = "";
            acc_cb_schoolorg.Text = "";
          
        }


        //Account Management Code selected index change
        private void acc_rlv_accounts_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            command = new MySqlCommand();
            MySqlDataReader reader = default(MySqlDataReader);

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }

            try {
                conn.Open();
                query = "SELECT * from accounts where username=@acc_username";
                command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("acc_username", acc_rlv_accounts.SelectedItem);
                reader = command.ExecuteReader();

                while(reader.Read()) {
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

            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally {
                conn.Dispose();
                acc_btn_update.Show();
                acc_btn_delete.Show();


            }
        }

        //EVENTS

        public void auto_generate_eventid() {
            identifier_reservationno = DateTime.Today.ToString("MMddyyyy" + "-");
            identifier_reservationno = identifier_reservationno + random.Next(1, 1000000).ToString();
            evt_tb_eventno.Text = identifier_reservationno;
        }

        private void evt_btn_eventid_Click(object sender, EventArgs e) {
            auto_generate_eventid();
        }

        public void addalllocsrange() {

           string[] locationlist = new string [] { "CARMEN DE LUNA (CDL)",
            "Multimedia Instructional Room (MIR)",
            "LIBRADA AVELINO HALL (LAH)",
            "Chapel/Adoration Chapel",
            "Executive Meeting Room (EMR)",
            "LAH Seminar Room #1",
            "LAH Seminar Room #2",
            "LAH Seminar Room #3",
            "GENEROSA DE LEON SCIENCE CENTER (GDLSC)",
            "Bulwagang Maestra Osang (BMO)",
            "SOFIA DE VEYRA HALL (SDVH)",
            "SDV Conference Room (SDVCR)",
            "SDV Lanai",
            "FELISA FRANCISCO HALL (FFH)",
            "Assembly Hall (3rd Flr)",
            "MARIA VILLACERAN HALL (MVH)",
            "LA Auditorium",
            "MVH Lanai",
            "DIONISIO C. TIONGCO (DCT)",
            "Student Activity Center (Ground flr)",
            "Student Activity Center (Second flr)",
            "PILAR HIDALGO LIM HALL (PHL)",
            "PHL Lanai",
            "TECHNOLOGY CENTER",
            "TechCenter Gym",
            "TechCenter Lanai with Lights",
            "FGH DENTRISTRY",
            "FGH Lanai",
            "INFORMATION SCIENCE CENTER",
            "Friends Cafe",
            "ISC Mezzanine #1",
            "ISC Mezzanine #2",
            "DentScience Lanai",
            "GYM (Classroom)",
            "North Quadrangle",
            "South Quadrangle" };

            evt_cb_venue.Items.AddRange(locationlist);
            

           
        }


        public void evt_load_datafromgrid() {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);
            DataTable dbdataset = new DataTable();
            BindingSource bsource = new BindingSource();
            MySqlDataAdapter sda = new MySqlDataAdapter();

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }

            try {
                conn.Open();
                query = "SELECT eventid as 'Event ID',  DATE_FORMAT(date,'%M %d %Y') as 'Date', events as 'Events', location as 'Venue', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', school as 'School',kpi as 'KPI',noa as 'NOA',remarks as 'Remarks' from events";
                command = new MySqlCommand(query, conn);
                sda.SelectCommand = command;
                sda.Fill(dbdataset);
                bsource.DataSource = dbdataset;
                evt_rgv_events.DataSource = bsource;
                sda.Update(dbdataset);


                conn.Close();

            }
            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally {
                conn.Dispose();

            }
        }


        private void evt_rgv_events_CellDoubleClick(object sender, GridViewCellEventArgs e) {
            if(e.RowIndex >= 0) {
                Telerik.WinControls.UI.GridViewRowInfo row = this.evt_rgv_events.Rows[e.RowIndex];
                row = this.evt_rgv_events.Rows[e.RowIndex];
                evt_cb_kpi.Text = row.Cells["KPI"].Value.ToString();
                evt_cb_noa.Text = row.Cells["NOA"].Value.ToString();
                evt_cb_remarks.Text = row.Cells["Remarks"].Value.ToString();
                evt_cb_schoolorg.Text = row.Cells["School"].Value.ToString();
                evt_cb_venue.Text = row.Cells["Venue"].Value.ToString();
                evt_dtp_date.Text = row.Cells["Date"].Value.ToString();
                evt_dtp_starttime.Text = row.Cells["Start Time"].Value.ToString();
                evt_dtp_endtime.Text = row.Cells["End Time"].Value.ToString();
                evt_rtb_event.Text = row.Cells["Events"].Value.ToString();
                evt_tb_eventno.Text = row.Cells["Event ID"].Value.ToString();



            }
        }
        private void evt_btn_clear_Click(object sender, EventArgs e) {
            auto_generate_eventid();
            evt_cb_kpi.Text = "";
            evt_cb_noa.Text = "";
            evt_cb_remarks.Text = "";
            evt_cb_schoolorg.Text = "";
            evt_cb_venue.Text = "";
            evt_dtp_date.Value = System.DateTime.Now;
            evt_dtp_starttime.Text = "";
            evt_dtp_endtime.Text = "";
            evt_rtb_event.Text = "";

        }

        private void evt_btn_save_Click(object sender, EventArgs e) {

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }



            reserveYN = RadMessageBox.Show(this, "Are you sure you want to reserve?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if(reserveYN == DialogResult.Yes) {
                conn.ConnectionString = connstring;

                if((string.IsNullOrEmpty(evt_cb_kpi.Text)) | (string.IsNullOrEmpty(evt_cb_noa.Text)) | (string.IsNullOrEmpty(evt_cb_venue.Text)) | (string.IsNullOrEmpty(evt_cb_schoolorg.Text)) | (string.IsNullOrEmpty(evt_rtb_event.Text)) | (string.IsNullOrEmpty(evt_dtp_endtime.Text)) | (string.IsNullOrEmpty(evt_dtp_starttime.Text))) {
                    RadMessageBox.Show(this, "Please fill all fields!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else {

                    String st = (evt_dtp_date.Value.ToString("yyyy/MM/dd") + " " + evt_dtp_starttime.Text);
                    String et = (evt_dtp_date.Value.ToString("yyyy/MM/dd") + " " + evt_dtp_endtime.Text);

                    DateTime startTime = DateTime.Parse(st);
                    DateTime endTime = DateTime.Parse(et);

                    TimeSpan elapsedTime = endTime - startTime;

                    if(elapsedTime.CompareTo(TimeSpan.Zero) <= 0) {
                        RadMessageBox.Show(this, "The Starting Time can't be the same or later on the Ending Time.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else {

                        try {
                            conn.Open();


                            query = "SELECT * FROM events WHERE location=@location AND ((((@a) BETWEEN CONCAT(date,' ',starttime) AND CONCAT(date,' ',endtime)) OR (@b BETWEEN CONCAT(date,' ',starttime) AND CONCAT(date,' ',endtime))) OR ((DATE_FORMAT(@a,'%Y-%m-%d %H:%i:%s') <= CONCAT(date,' ',starttime)) AND (DATE_FORMAT(@b,'%Y-%m-%d %H:%i:%s') >= CONCAT(date,' ',endtime)) AND CONCAT(date,' ',endtime) >= DATE_FORMAT(@a,'%Y-%m-%d %H:%i:%s')))";

                            //RAW
                            ////query = "SELECT * FROM events WHERE location='" + evt_cb_venue.Text + "' AND (((('" + evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + evt_dtp_starttime.Value.ToString("HH:mm:01") + "') BETWEEN CONCAT(date,' ',starttime) AND CONCAT(date,' ',endtime)) OR ('" + evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + evt_dtp_endtime.Value.ToString("HH:mm:01") + "' BETWEEN CONCAT(date,' ',starttime) AND CONCAT(date,' ',endtime))) OR ((DATE_FORMAT('" + evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + evt_dtp_starttime.Value.ToString("HH:mm:01") + "','%Y-%m-%d %H:%i:%s') <= CONCAT(date,' ',starttime)) AND (DATE_FORMAT('" + evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + evt_dtp_endtime.Value.ToString("HH:mm:01") + "','%Y-%m-%d %H:%i:%s') >= CONCAT(date,' ',endtime)) AND CONCAT(date,' ',endtime) >= DATE_FORMAT('" + evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + evt_dtp_starttime.Value.ToString("HH:mm:01") + "','%Y-%m-%d %H:%i:%s')))";

                            command = new MySqlCommand(query, conn);
                            var sta = DateTime.Parse(evt_dtp_starttime.Text);
                            string stam = sta.ToString("HH:mm:01");

                            var eta = DateTime.Parse(evt_dtp_endtime.Text);
                            string etam = eta.ToString("HH:mm:01");



                            command.Parameters.AddWithValue("a", evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + stam);
                            command.Parameters.AddWithValue("b", evt_dtp_date.Value.ToString("yyyy-MM-dd") + " " + etam);
                            command.Parameters.AddWithValue("location", evt_cb_venue.Text);


                            reader = command.ExecuteReader();

                            int count = 0;

                            while(reader.Read()) {
                                count += 1;

                            }
                            if(count > 0) {
                                RadMessageBox.Show(this, "This is already taken", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                            }
                            else {

                                conn.Close();
                                conn.Open();

                                query = "INSERT INTO `events` VALUES (@eventid,@date,@location,@events,@starttime,@endtime,@school,@kpi,@noa,@remarks)";
                                command = new MySqlCommand(query, conn);
                                command.Parameters.AddWithValue("eventid", evt_tb_eventno.Text);
                                command.Parameters.AddWithValue("date", evt_dtp_date.Value.ToString("yyyy-MM-dd"));
                                command.Parameters.AddWithValue("location", evt_cb_venue.Text);
                                command.Parameters.AddWithValue("events", evt_rtb_event.Text);
                                command.Parameters.AddWithValue("starttime", evt_dtp_starttime.Text);
                                command.Parameters.AddWithValue("endtime", evt_dtp_endtime.Text);
                                command.Parameters.AddWithValue("school", evt_cb_schoolorg.Text);
                                command.Parameters.AddWithValue("kpi", evt_cb_kpi.Text);
                                command.Parameters.AddWithValue("noa", evt_cb_noa.Text);
                                command.Parameters.AddWithValue("remarks", evt_cb_remarks.Text);

                                RadMessageBox.Show(this, "Successfully Reserved", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);

                                reader = command.ExecuteReader();
                                conn.Close();
                            }
                        }


                        catch(Exception ex) {
                            RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        finally {
                            conn.Dispose();
                            evt_load_datafromgrid();
                            home_load_datafromgrid();
                            auto_generate_eventid();
                        }
                    }
                }
            }
        }


        private void evt_btn_update_Click(object sender, EventArgs e) {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }

            updateYN = RadMessageBox.Show(this, "Are you sure you want to update this event?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if(updateYN == DialogResult.Yes) {

                if((string.IsNullOrEmpty(evt_cb_kpi.Text)) | (string.IsNullOrEmpty(evt_cb_noa.Text)) | (string.IsNullOrEmpty(evt_cb_venue.Text)) | (string.IsNullOrEmpty(evt_cb_schoolorg.Text)) | (string.IsNullOrEmpty(evt_rtb_event.Text)) | (string.IsNullOrEmpty(evt_dtp_endtime.Text)) | (string.IsNullOrEmpty(evt_dtp_starttime.Text))) {

                    RadMessageBox.Show(this, "Please fill all fields!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
                else {
                    String st = (evt_dtp_date.Value.ToString("yyyy/MM/dd") + " " + evt_dtp_starttime.Text);
                    String et = (evt_dtp_date.Value.ToString("yyyy/MM/dd") + " " + evt_dtp_endtime.Text);

                    DateTime startTime = DateTime.Parse(st);
                    DateTime endTime = DateTime.Parse(et);

                    TimeSpan elapsedTime = endTime - startTime;

                    if(elapsedTime.CompareTo(TimeSpan.Zero) <= 0) {
                        RadMessageBox.Show(this, "The Starting Time can't be the same or later on the Ending Time.", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Error);
                    }
                    else {
                        try {
                            conn.Open();
                            query = "UPDATE events SET kpi=@evt_kpi, noa=@evt_noa, school=@evt_college, events=@evt_events, starttime=@evt_st, location=@evt_location, endtime=@evt_et WHERE (eventid=@evt_eventid) AND (location=@evt_location)";
                            command = new MySqlCommand(query, conn);
                            command.Parameters.AddWithValue("evt_eventid", evt_tb_eventno.Text);
                            command.Parameters.AddWithValue("evt_location", evt_cb_venue.Text);
                            command.Parameters.AddWithValue("evt_kpi", evt_cb_kpi.Text);
                            command.Parameters.AddWithValue("evt_noa", evt_cb_noa.Text);
                            command.Parameters.AddWithValue("evt_college", evt_cb_schoolorg.Text);
                            command.Parameters.AddWithValue("evt_events", evt_rtb_event.Text);
                            command.Parameters.AddWithValue("evt_st", evt_dtp_starttime.Text);
                            command.Parameters.AddWithValue("evt_et", evt_dtp_endtime.Text);

                            reader = command.ExecuteReader();

                            RadMessageBox.Show(this, "Update Complete!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Info);
                            conn.Close();
                        }
                        catch(Exception ex) {
                            RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                        finally {
                            conn.Dispose();
                            evt_load_datafromgrid();
                            home_load_datafromgrid();
                        }
                    }
                }
            }
        }

        private void evt_btn_delete_Click(object sender, EventArgs e) {
            try {
                conn = new MySqlConnection();
                conn.ConnectionString = connstring;

                if(conn.State == ConnectionState.Open) {
                    conn.Close();
                }

                delYN = RadMessageBox.Show(this, "Are you sure you want to delete?", "CEU TLTD Reservation System", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if(delYN == DialogResult.Yes) {
                    if((string.IsNullOrEmpty(evt_cb_kpi.Text)) | (string.IsNullOrEmpty(evt_cb_noa.Text)) | (string.IsNullOrEmpty(evt_cb_venue.Text)) | (string.IsNullOrEmpty(evt_cb_schoolorg.Text)) | (string.IsNullOrEmpty(evt_rtb_event.Text)) | (string.IsNullOrEmpty(evt_dtp_endtime.Text)) | (string.IsNullOrEmpty(evt_dtp_starttime.Text))) {
                        RadMessageBox.Show(this, "Please fill all fields!", "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);

                    }
                    else {

                        conn.Open();
                        query = "DELETE FROM events WHERE (eventid=@evt_id) AND (location=@evt_location)";
                        command = new MySqlCommand(query, conn);
                        command.Parameters.AddWithValue("evt_id", evt_tb_eventno.Text);
                        command.Parameters.AddWithValue("evt_location", evt_cb_venue.Text);
                        reader = command.ExecuteReader();

                        RadMessageBox.Show(this, "Successfully Deleted!", "CEU TLTD Reservation System", MessageBoxButtons.OK, RadMessageIcon.Info);
                        conn.Close();
                    }
                }
            }

            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally {
                conn.Dispose();
               
                auto_generate_eventid();
                evt_cb_kpi.Text = "";
                evt_cb_noa.Text = "";
                evt_cb_remarks.Text = "";
                evt_cb_schoolorg.Text = "";
                evt_cb_venue.Text = "";
                evt_dtp_date.Value = System.DateTime.Now;
                evt_dtp_starttime.Text = "";
                evt_dtp_endtime.Text = "";
                evt_rtb_event.Text = "";

                //Refreshing Data
                evt_load_datafromgrid();
                home_load_datafromgrid();

            }
        }


        //STARTING HERE IS Home Codes
        public void home_load_datafromgrid() {
            conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            MySqlDataReader reader = default(MySqlDataReader);
            DataTable dbdataset = new DataTable();
            BindingSource bsource = new BindingSource();
            MySqlDataAdapter sda = new MySqlDataAdapter();

            if(conn.State == ConnectionState.Open) {
                conn.Close();
            }

            try {
                conn.Open();
                query = "SELECT eventid as 'Event ID',  DATE_FORMAT(date,'%M %d %Y') as 'Date', events as 'Events', location as 'Venue', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', school as 'School',kpi as 'KPI',noa as 'NOA',remarks as 'Remarks' from events";
                command = new MySqlCommand(query, conn);
                sda.SelectCommand = command;
                sda.Fill(dbdataset);
                bsource.DataSource = dbdataset;
                home_rgv_eventdata.DataSource = bsource;
                sda.Update(dbdataset);


                conn.Close();

            }
            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally {
                conn.Dispose();

            }
        }

        private void home_lu_venue_TextChanged(object sender, EventArgs e) {
            //Future addition is the delay time

            conn.ConnectionString = connstring;
            MySqlDataAdapter sda = new MySqlDataAdapter();
            DataTable dbdataset = new DataTable();
            BindingSource bsource = new BindingSource();

            try {
                conn.Open();
                query = "SELECT eventid as 'Event ID',  DATE_FORMAT(date,'%M %d %Y') as 'Date', events as 'Events', location as 'Venue', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', school as 'School',kpi as 'KPI',noa as 'NOA',remarks as 'Remarks' from events";
                command = new MySqlCommand(query, conn);
                sda.SelectCommand = command;
                sda.Fill(dbdataset);
                bsource.DataSource = dbdataset;
                home_rgv_eventdata.DataSource = bsource;
                sda.Update(dbdataset);
                conn.Close();

            }

            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

            finally {
                conn.Dispose();
            }


            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("Venue Like'%{0}%'", home_lu_venue.Text);
            home_rgv_eventdata.DataSource = DV;
        }

        private void home_lu_searchbydate_Click(object sender, EventArgs e) {
            conn.ConnectionString = connstring;
            MySqlDataAdapter sda = new MySqlDataAdapter();
            DataTable dbdataset = new DataTable();
            BindingSource bsource = new BindingSource();

            try {
                conn.Open();
                query = "SELECT eventid as 'Event ID',  DATE_FORMAT(date,'%M %d %Y') as 'Date', events as 'Events', location as 'Venue', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', school as 'School',kpi as 'KPI',noa as 'NOA',remarks as 'Remarks' from events WHERE date BETWEEN @startdate AND @enddate";
                command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("startdate", home_dtp_startdate.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("enddate", home_dtp_enddate.Value.ToString("yyyy-MM-dd"));
                sda.SelectCommand = command;
                sda.Fill(dbdataset);
                bsource.DataSource = dbdataset;
                home_rgv_eventdata.DataSource = bsource;
                sda.Update(dbdataset);
                conn.Close();

            }

            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

            finally {
                conn.Dispose();
            }
        }

        private void home_lu_school_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) {
            conn.ConnectionString = connstring;
            MySqlDataAdapter sda = new MySqlDataAdapter();
            DataTable dbdataset = new DataTable();
            BindingSource bsource = new BindingSource();

            try {
                conn.Open();
                query = "SELECT eventid as 'Event ID',  DATE_FORMAT(date,'%M %d %Y') as 'Date', events as 'Events', location as 'Venue', TIME_FORMAT(starttime, '%H:%i') as 'Start Time', TIME_FORMAT(endtime, '%H:%i') as 'End Time', school as 'School',kpi as 'KPI',noa as 'NOA',remarks as 'Remarks' from events";
                command = new MySqlCommand(query, conn);
                sda.SelectCommand = command;
                sda.Fill(dbdataset);
                bsource.DataSource = dbdataset;
                home_rgv_eventdata.DataSource = bsource;
                sda.Update(dbdataset);
                conn.Close();

            }

            catch(Exception ex) {
                RadMessageBox.Show(this, ex.Message, "CEU Consolidated Calendar", MessageBoxButtons.OK, RadMessageIcon.Error);
            }

            finally {
                conn.Dispose();
            }


            DataView DV = new DataView(dbdataset);
            DV.RowFilter = string.Format("School Like'%{0}%'", home_lu_school.Text);
            home_rgv_eventdata.DataSource = DV;
        }

        private void home_btn_refreshgrid_Click(object sender, EventArgs e) {
            home_load_datafromgrid();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            Login login = new Login();

            closeYN = RadMessageBox.Show(this, "Are you sure you want to Log-Out?", "CEU Consolidated Calendar", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation);
            if(closeYN == DialogResult.Yes) {
                this.Dispose();
                login.Show();
            }
            else {
                e.Cancel = true;
            }

        }










        //ENDING HERE
    }
}

              

