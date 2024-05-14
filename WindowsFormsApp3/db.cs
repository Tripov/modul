using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    internal class db
    {
        public static DataTable select(string sql)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Properties.Settings.Default.Host;
            builder.Port = (uint)Properties.Settings.Default.Port;    
            builder.Database = Properties.Settings.Default.DBName;
            builder.UserID = Properties.Settings.Default.DBUser;
            builder.Password = Properties.Settings.Default.DBPass;
            MySqlConnection connect = new MySqlConnection(builder.ConnectionString);
            try
            {
                connect.Open();
                MySqlCommand command = new MySqlCommand(sql, connect);
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table;

            }
            catch (Exception e)
            {
                MessageBox.Show("При выполнении запроса произошла ошибка! " + e.Message);
                return null;
            }
        }
    }
}
