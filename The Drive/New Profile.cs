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
    public partial class New_Profile : Form
    {
        public New_Profile()
        {
            InitializeComponent();
        }



        //string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zanele Thwala\Desktop\The Drive\The Drive\The Drive DB.mdf;Integrated Security=True";





        bool valid = true;
        public static int client_id;
        public static string title = "";
        private void New_Profile_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Login.conString);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("Select isnull(max(cast(Client_ID as int)),0)+1 from ClientData", con);
                //Recieve largest client id and plus 1 
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                client_id = int.Parse(dt.Rows[0][0].ToString());

                /*
                SqlCommand command = new SqlCommand("Select MAX([Client Id]) from ClientData", con);
                client_id = Convert.ToInt32(command.ExecuteScalar()) + 1;

                
                Random rand = new Random();
                client_id = rand.Next(1000, 100000);
                */

                label13.Text = client_id.ToString();
                button3.Enabled = false;
                comboBox1.Focus();
                button1.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        

        
        private void button1_Click(object sender, EventArgs e)
        {
            string client_name, email, physical_address, username, password, conpassowrd;
            string credit_score, ID_num, cell_Num;

            client_name = textBox1.Text;
            physical_address = textBox6.Text;
            ID_num = textBox2.Text;
            email = textBox3.Text;
            credit_score = textBox4.Text;
            cell_Num = textBox5.Text;
            username = textBox9.Text.Trim();
            password = textBox10.Text.Trim();
            conpassowrd = textBox11.Text.Trim();

            try
            {

                SqlConnection conn = new SqlConnection(Login.conString);
                validate();
                if (valid == false)
                {
                    MessageBox.Show("Please fix your errors");

                }
                else
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) From ClientData Where Username = '" + username + "'", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Username taken! Please change username");
                        textBox9.Focus();
                    }
                    else
                    {
                        client_name = title + " " + client_name;

                        string insert = "INSERT INTO ClientData ([Client_ID], [Client_name], [ID_number], [Email_address], [Physical_address], [Contact_number], Username, Password) VALUES('" + client_id + "','" + client_name + "','" + ID_num + "','" + email + "','" + physical_address + "','" + cell_Num + "','" + username + "','" + password + "')";

                        SqlDataAdapter adapter1 = new SqlDataAdapter();
                        SqlCommand command = new SqlCommand(insert, conn);

                        adapter1.InsertCommand = new SqlCommand(insert, conn);
                        adapter1.InsertCommand.ExecuteNonQuery();
                        command.Dispose();

                        conn.Close();


                        MessageBox.Show("Welcome " + client_name + ". Please click continue ");

                        button3.Enabled = true;
                        button1.Enabled = false;
                        button3.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

        private void validate()
        {
            errorCellnum.SetError(textBox5, "");
            errorCellnum.Clear();
            errorPassword.SetError(textBox11, "");
            errorPassword.Clear();
            errorProvider1.SetError(textBox2, "");
            errorProvider1.Clear();

            valid = true;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please selcet a title");
                comboBox1.Focus();
                valid = false;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                title = "Mr";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                title = "Ms";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                title = "Mrs";
            }




            //int Client_Id = random.Next(1000000, 10000000);
            /// Id validate

            int ID_num;

            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Please enter your ID number");
                valid = false;

            }
            else
            {
                //if (int.TryParse(textBox2.Text, out ID_num) == false)
                //{
                //    errorProvider1.SetError(textBox2, "1. Please enter a valid ID number");
                //    valid = false;
                //}
                //else
                if (textBox2.TextLength != 13)
                {
                    errorProvider1.SetError(textBox2, "Please enter a valid ID number");
                    valid = false;
                }

            }

            int cell_num;

            if (int.TryParse(textBox5.Text, out cell_num) == false || textBox5.TextLength != 10)
            {
                errorCellnum.SetError(textBox5, "Please enter a valid contact number");
                valid = false;
            }

            if (textBox11.Text != textBox10.Text)
            {
                errorPassword.SetError(textBox11, "Passwords don't match");
                valid = false;
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a title");
                comboBox1.Focus();
                valid = false;
            }
            else
            {
                valid = true;

                if (comboBox1.SelectedIndex == 0)
                {
                    title = "Mr";
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    title = "Ms";
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    title = "Mrs";
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.ShowDialog();
            this.Close();
            /*
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.ShowDialog();
            this.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            int birthyear;
            int age;

            if (textBox2.TextLength == 13)
            {
                string idstring = textBox2.Text.Substring(0, 2);

                if (int.Parse(idstring) < 19)
                    birthyear = 2000 + int.Parse(idstring);
                else
                    birthyear = 1900 + int.Parse(idstring);

                age = int.Parse(DateTime.Today.Year.ToString()) - birthyear;

                if (age < 18)
                {
                    MessageBox.Show("You are too young to register.\n You must be 18 YEARS old");
                    Login loginform = new Login();
                    loginform.ShowDialog();
                    this.Close();
                }
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                errorValues.SetError(textBox6, "Please enter an address");
                textBox6.Focus();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a name");
                textBox1.Focus();
            }
        }
    }
}
