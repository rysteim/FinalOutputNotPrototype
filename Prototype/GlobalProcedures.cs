using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Prototype
{
    internal class GlobalProcedures
    {
        public string servername;
        public string databasename;
        public string username;
        public string password;
        public string port;

        public MySqlConnection conHotel;
        public MySqlCommand sqlCommand;
        public string strConnection;

        public MySqlDataAdapter sqlHotelAdapter;
        public DataTable datHotel;

        public bool fncConnectToDatabase()
        {
            try
            {
                servername = "localhost";
                databasename = "hotelmgn";
                username = "root";
                password = "";
                port = "3306";

                //implement connection
                strConnection = "Server=" + servername + ";" +
                       "Database=" + databasename + ";" +
                       "User=" + username + ";" +
                       "Password=" + password + ";" +
                       "Port=" + port + ";" +
                       "Convert Zero Datetime = true";

                conHotel = new MySqlConnection(strConnection);
                sqlCommand = new MySqlCommand(strConnection, conHotel);

                if (conHotel.State == System.Data.ConnectionState.Closed)
                {
                    sqlCommand.Connection = conHotel;
                    conHotel.Open();
                    return true;
                }
                else
                {
                    conHotel.Close();
                    return false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error Message: \n" + err.Message);
            }
            return false;
        }

        public void fncDatabaseConnection()
        {
            if (fncConnectToDatabase().Equals("False"))
            {
                conHotel.Open();
            }
            else
            {
            }
        }
    }
}
