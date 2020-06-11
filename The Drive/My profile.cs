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
    public partial class Confirmation_Page : Form
    {
        public Confirmation_Page()
        {
            InitializeComponent();
        }
        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zanele Thwala\Desktop\The Drive\The Drive\The Drive DB.mdf;Integrated Security=True";

        private void Button1_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            //logging the user out of the system
            Login login = new Login();
            login.Show();
            this.Close();
        }
       

        private void Confirmation_Page_Load(object sender, EventArgs e)
        {
            //getting the users info from database and displaying the info
            string client_id = Login.Client_ID;

            SqlConnection con = new SqlConnection(Login.conString);
            SqlCommand command;
            SqlDataReader reader;

            string sql = "Select * From ClientData Where Client_ID ='" + client_id + "'";
            
            try
            {
                con.Open();
                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();

                

                while (reader.Read())
                {
                    textBox1.Text = reader.GetValue(0).ToString();
                    textBox2.Text = reader.GetValue(1).ToString();
                    textBox3.Text = reader.GetValue(3).ToString();
                    textBox4.Text = reader.GetValue(5).ToString();
                    textBox5.Text = reader.GetValue(4).ToString();
                }
                command.Dispose();
                con.Close();

                

                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //updating the user info in the datase
                string client_id = Login.Client_ID;
                SqlConnection con = new SqlConnection(Login.conString);
                SqlDataAdapter adapter = new SqlDataAdapter();

                string update_sql = "Update ClientData Set Client_name = '" + textBox2.Text + "', Email_address = '" + 
                    textBox3.Text + "', Contact_number = '" + textBox4.Text + "', Physical_address= '" + textBox5.Text+ "' Where " +
                    "Client_ID ='" + client_id+"'";

                con.Open();

                SqlCommand command = new SqlCommand(update_sql, con) ;
                adapter.UpdateCommand = new SqlCommand(update_sql, con);
                adapter.UpdateCommand.ExecuteNonQuery();

                command.Dispose();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                //displaying the users recent orders

                string clientID = Login.Client_ID;
                
                SqlConnection con = new SqlConnection(Login.conString);
                SqlCommand command2;
                SqlDataReader reader2;

                con.Open();

                string sql2 = "Select * From Order_table Where Order_number ='" + clientID + "'";
                
                command2 = new SqlCommand(sql2, con);
                reader2 = command2.ExecuteReader();
                listBox1.Items.Clear();

                while (reader2.Read())
                {
                    listBox1.Items.Add("Order number: " + reader2.GetValue(0).ToString());
                    listBox1.Items.Add("Total Cost: " + reader2.GetValue(2).ToString());
                    listBox1.Items.Add("Delivery Date: " + reader2.GetValue(3).ToString());
                    listBox1.Items.Add("Manufacture: " + reader2.GetValue(4).ToString());
                    listBox1.Items.Add("Customisation: " + reader2.GetValue(5).ToString());
                    listBox1.Items.Add("Additional Cost " + reader2.GetValue(6).ToString());

                }

                command2.Dispose();

                con.Close();

                listBox1.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
