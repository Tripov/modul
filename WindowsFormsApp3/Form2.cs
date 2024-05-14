using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable data = db.select("SELECT * FROM `book`");
            dataGridView1.DataSource = data;





        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Заполните ВСЕ поля");
            }
            else
            {
                DataTable data = db.select(@"INSERT INTO book (`namebook`, `author`,`price`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "');");
                data = db.select(@"SELECT * FROM book");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dataGridView1.DataSource = data;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataTable data = db.select(@" DELETE FROM book WHERE idbook=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = db.select(@"SELECT * FROM book");
            dataGridView1.DataSource = data;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите колонку поиска");
            }
            else
            {
                DataTable data = db.select(@"SELECT * FROM book WHERE " + comboBox1.Text + " LIKE '" + "%" + textBox4.Text + "%" + "';");
                dataGridView1.DataSource = data;
            }
        }


        }
    }

