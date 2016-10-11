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
        public static string connstring = "SERVER=localhost;port=3306;userid=root;password=root;database=saoinfo";
        public static MySqlCommand command;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
       
    }
   

}
