using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Drive
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }

        //connecting to the database
        SqlConnection connection;
        public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zanele Thwala\Desktop\The Drive - updated\The Drive\Drive_DB.mdf;Integrated Security=True";
        public static string Client_ID = "";

        public string client_id_str;

        public string Client_id_str
        {
            get { return client_id_str; }
            set { client_id_str = value; }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            New_Profile myform = new New_Profile();
            myform.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string username = "";
        private void button1_Click(object sender, EventArgs e)
        {
            //checking the users details
            try
            {
               username = textBox1.Text;
                string password = textBox2.Text;
                Welcome welcome = new Welcome();

                connection = new SqlConnection(conString);
                SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From ClientData Where Username = '" + username + "' and Password ='" + password + "'", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if(textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    Admin admin = new Admin();
                    admin.ShowDialog();
                    this.Hide();
                }
                else if (dataTable.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter adapter1 = new SqlDataAdapter("Select Client_ID From ClientData Where Username = '" + username + "' and Password ='" + password + "'", connection);
                    DataTable dataTable1 = new DataTable();
                    adapter1.Fill(dataTable1);
                    Client_ID = dataTable1.Rows[0][0].ToString();
                    client_id_str = Client_ID.ToString();


                    this.Hide();
                    welcome.Show();

                }
                else
                {
                    //display error message to user 
                    MessageBox.Show("Incorrect password or username! Please enter values again");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(conString);
                connection.Open();
               // connection.Close();
                textBox1.Focus();
   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {//showing the password when checkbox is selected
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
