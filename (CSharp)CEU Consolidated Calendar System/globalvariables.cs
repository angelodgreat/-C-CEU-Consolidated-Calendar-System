using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;


namespace _CSharp_CEU_Consolidated_Calendar_System
{
    class globalvariables
    {
    
      


    }
    public static class Globals
    {
        public static MySqlConnection MySqlConnection;
        //public static string connstring = "SERVER=localhost;PORT=3306;USERNAME=root;PASSWORD=root;DATABASE=ceutltdscheduler";

        public static string connstring = "SERVER=" + Properties.Settings.Default.server + ";PORT=" + Properties.Settings.Default.port + ";USERNAME=" + Actions.Decrypt(Properties.Settings.Default.username) + ";PASSWORD=" + Actions.Decrypt(Properties.Settings.Default.password) + ";DATABASE=" + Properties.Settings.Default.database + ";";

        public static MySqlCommand command;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;

        public static void applyconstringImmediately() {
            string connstring = "SERVER=" + Properties.Settings.Default.server + ";PORT=" + Properties.Settings.Default.port + ";USERNAME=" + Actions.Decrypt(Properties.Settings.Default.username) + ";PASSWORD=" + Actions.Decrypt(Properties.Settings.Default.password) + ";DATABASE=" + Properties.Settings.Default.database + ";";
        }

    }

    



}
