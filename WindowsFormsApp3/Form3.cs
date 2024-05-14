using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
            textBox1.Text = Properties.Settings.Default.Host;
            numericUpDown1.Maximum = 10000;
            numericUpDown1.Value = Properties.Settings.Default.Port;
            textBox2.Text = Properties.Settings.Default.DBName;
            textBox3.Text = Properties.Settings.Default.DBUser;
            textBox4.Text = Properties.Settings.Default.DBPass;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = Properties.Settings.Default.Host;
                builder.Port = Convert.ToUInt32(numericUpDown1.Value);
                builder.Database = Properties.Settings.Default.DBName;
                builder.UserID = Properties.Settings.Default.DBUser;
                builder.Password = Properties.Settings.Default.DBPass;
                MySqlConnection connect = new MySqlConnection(builder.ConnectionString);

                MySqlConnection connection = new MySqlConnection(builder.ToString());
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    MessageBox.Show("Подключение прошло успешно!");
                }
                else
                {
                    MessageBox.Show("Не удалось открыть соединение");
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии соединения" + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Host = textBox1.Text;
            Properties.Settings.Default.Port = Convert.ToUInt32(numericUpDown1.Value);
            Properties.Settings.Default.DBName = textBox2.Text;
            Properties.Settings.Default.DBUser = textBox3.Text;
            Properties.Settings.Default.DBPass = textBox4.Text;

            Properties.Settings.Default.Save();

            Hide();
        }
    }
}
