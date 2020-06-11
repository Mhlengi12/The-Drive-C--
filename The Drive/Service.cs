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
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Welcome loginform = new Welcome();
            this.Hide();
            loginform.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Service_Load(object sender, EventArgs e)
        {
            string client_id = Login.Client_ID;

            SqlConnection con = new SqlConnection(Login.conString);
            SqlCommand command;
            SqlDataReader reader;

            string sql = "Select * From Service Where Client_ID ='" + client_id + "'";

            try
            {
                con.Open();
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    textBox1.Text = reader.GetValue(4).ToString();
                    textBox2.Text = reader.GetValue(2).ToString();
                    label2.Text = reader.GetValue(0).ToString();
                    label10.Text = reader.GetValue(3).ToString();
                    label6.Text = reader.GetValue(5).ToString();
                }
                command.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Login.conString);
            con.Open();
            string client_id = Login.Client_ID;

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string sql = @"DELETE * FROM Service WHERE Client_id = '" + client_id + "'";

            command = new SqlCommand(sql, con);

            DataSet set = new DataSet();

            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Thank you for using our services \nSee you soon");
        }
    }
}
