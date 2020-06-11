using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace The_Drive
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string constring = Login.conString;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            conn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = @"Select * FROM ClientData";
            command = new SqlCommand(sql, conn);

            DataSet set = new DataSet();

            adapter.SelectCommand = command;
            adapter.Fill(set, "ClientData");

            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "ClientData";

            conn.Close();
        }
        
        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string constring = Login.conString;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            conn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = @"Select * FROM Account";
            command = new SqlCommand(sql, conn);

            DataSet set = new DataSet();

            adapter.SelectCommand = command;
            adapter.Fill(set, "Account");

            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "Account";

            conn.Close();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string constring = Login.conString;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            conn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = @"Select * FROM Order_table";
            command = new SqlCommand(sql, conn);

            DataSet set = new DataSet();

            adapter.SelectCommand = command;
            adapter.Fill(set, "Order_table");

            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "Order_table";

            conn.Close();
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string constring = Login.conString;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            conn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = @"Select * FROM Product";
            command = new SqlCommand(sql, conn);

            DataSet set = new DataSet();

            adapter.SelectCommand = command;
            adapter.Fill(set, "Product");

            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "Product";

            conn.Close();
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string constring = Login.conString;
            SqlConnection conn;
            conn = new SqlConnection(constring);
            conn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = @"Select * FROM Service";
            command = new SqlCommand(sql, conn);

            DataSet set = new DataSet();

            adapter.SelectCommand = command;
            adapter.Fill(set, "Service");

            dataGridView1.DataSource = set;
            dataGridView1.DataMember = "Service";

            conn.Close();
        }
    }
}
