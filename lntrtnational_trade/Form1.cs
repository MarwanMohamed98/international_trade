using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
//using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace lntrtnational_trade
{
    public partial class Form1 : Form
    {
        public static string client_id = string.Empty;


        DataTable dt = new DataTable();
        SqlConnection conn;
        string ConnectionString = @"Data Source=DESKTOP-FEQ9S89; Initial Catalog=InternationalTrade; Integrated Security=True";
        public void Fillgrids()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();



            SqlDataAdapter adp = new SqlDataAdapter("select * from clients  ", conn);
            dt.Rows.Clear();
            dt.Columns.Clear();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Form1()
        {
            InitializeComponent();
            Fillgrids();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection(ConnectionString);

            conn.Open();
            string cat = comboBox1.GetItemText(comboBox1.SelectedItem);
           // MessageBox.Show("Connection Open  !");
            SqlDataAdapter adp = new SqlDataAdapter("select * from clients  where contract_type ='"+cat+"'", conn);
            dt.Rows.Clear();
            dt.Columns.Clear();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            client_id = textBox1.Text.Trim();
            //conn.Close();
            this.Hide();
            var startup = new Form2();
            startup.Show();


        }
    }
}