using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lntrtnational_trade
{
    public partial class Form2 : Form
    {

       

            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
        SqlConnection conn;
        string ConnectionString = @"Data Source=DESKTOP-FEQ9S89; Initial Catalog=InternationalTrade; Integrated Security=True";
        public void Fillgrids()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
           
           
            SqlDataAdapter adp = new SqlDataAdapter("select distinct printer_model from client_profile  where cleint_id ='" + Form1.client_id + "' ", conn);
            dt.Rows.Clear();
            dt.Columns.Clear();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;

            SqlDataAdapter adp2 = new SqlDataAdapter("select * from client_profile  where cleint_id ='" + Form1.client_id + "' ", conn);
            dt2.Rows.Clear();
            dt2.Columns.Clear();
            adp2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
        public Form2()
        {
            InitializeComponent();
            Fillgrids();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string client_id = Form1.client_id;
            

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string date1 = dateTimePicker1.Value.ToShortDateString();
            string date2 = dateTimePicker2.Value.ToShortDateString();
            MessageBox.Show("Connection Open  !");
            SqlDataAdapter adp = new SqlDataAdapter("select * from client_profile  where date between '" + date1+ "' and'" + date2 + "' ", conn);
            dt.Rows.Clear();
            dt.Columns.Clear();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bill_serial = textBox1.Text.Trim();
            string file = @"D:\bill\"+ bill_serial;
            Process.Start(new ProcessStartInfo { FileName = @"D:\bill\" + bill_serial+".txt", UseShellExecute = true });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var startup = new Form1();
            startup.Show();

        }
    }
}
