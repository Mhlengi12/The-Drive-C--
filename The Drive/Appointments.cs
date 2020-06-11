using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace The_Drive
{
    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            this.Hide();
            welcome.Show();
        }
        public static int totalCost = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            service.ShowDialog();
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        string service = "";
        public string date = "";
        
        private void Appointments_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            string Client_ID = Login.Client_ID;//getting the client id from login 

            label2.Text = Client_ID.ToString();
            radioButton5.Checked = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add info when updated button is clicked
            string date = dateTimePicker1.Value.ToShortDateString();

            if (dateTimePicker1.Value <= DateTime.Today)
            {
                MessageBox.Show("Date selected has passed \n Please select another date");
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Date of service: "+ date);
                listBox1.Items.Add("");
                listBox1.Items.Add("Type of service");
                if (checkBox1.Checked)
                {
                    listBox1.Items.Add(checkBox1.Text + "\n");
                }
                if(checkBox2.Checked)
                {
                    listBox1.Items.Add(checkBox2.Text + "\n");
                }
                if(checkBox3.Checked)
                {
                    listBox1.Items.Add(checkBox3.Text + "\n");
                }
                if(radioButton5.Checked)
                {
                    listBox1.Items.Add(radioButton5.Text + "\n");
                }
                listBox1.Items.Add("");
                listBox1.Items.Add("\nTotal: " + totalCost.ToString());
                button1.Enabled = true;

            }
            

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                radioButton5.Checked = false;
                totalCost += 8000;
                label5.Text = totalCost.ToString();
            }
            if (checkBox1.Checked == false)
            {
                
                totalCost -= 8000;
                label5.Text = totalCost.ToString();
            }


        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                radioButton5.Checked = false;
                totalCost += 8000;
                label5.Text = totalCost.ToString();
            }
            if (checkBox2.Checked == false)
            {
                
                totalCost -= 8000;
                label5.Text = totalCost.ToString();
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                radioButton5.Checked = false;
                totalCost += 5000;
                label5.Text = totalCost.ToString();
            }
            if (checkBox3.Checked == false)
            {
                totalCost -=5000;
                label5.Text = totalCost.ToString();
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //unchecking the checkboxex when radiobutton is checked
            if (radioButton5.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                totalCost = 20000;
                label5.Text = totalCost.ToString();

                service += radioButton5.Text;
            }
            if(radioButton5.Checked == false)
            {
                totalCost = 0;
                label5.Text = totalCost.ToString();
            }
        }
       
        
        private void Button1_Click_1(object sender, EventArgs e)
        {
            Random rand = new Random();

            int Service_num = rand.Next(100, 1000);// creatingservice number
            try
            {
                string date = dateTimePicker1.Value.ToShortDateString();
                string service = "", employee = "";

                //adding the employee name and type of service
                if (checkBox1.Checked)
                {
                    service += checkBox1.Text;
                    employee += "Sam Deker, ";
                   
                }
                else
                {
                    service += "";
                    employee += "";
                    
                }

                if (checkBox2.Checked)
                {
                    service += checkBox2.Text;
                    employee += "Stembiso Zwane,";
                   
                }
                else
                {
                    service += "";
                    employee += "";
                    
                }

                if (checkBox3.Checked)
                {
                    service += checkBox3.Text;
                    employee += "James Hlope";
                   
                }
                else
                {
                    service += "";
                    employee += "";
                   
                }

                if (radioButton5.Checked)
                {
                    service = radioButton5.Text;
                    employee = "David May";
                }
                else
                {
                    service += "";
                    employee += "";
                }

                
                string Client_ID = Login.Client_ID;
                // adding service info to service table

                SqlConnection conn = new SqlConnection(Login.conString);
                
                conn.Open();
                string insert = "INSERT INTO Service ([Service_number], [Client_id], [Service_type], [Service_date], [Employee_name], [Total_cost]) VALUES('"+ Service_num +"','"+ Client_ID + "','" + service + "','" + date + "','" + employee + "','" + totalCost +"')";

                SqlDataAdapter adapter1 = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(insert, conn);

                adapter1.InsertCommand = new SqlCommand(insert, conn);
                adapter1.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                conn.Close();
               
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            
            // displaying user message
            MessageBox.Show("Service appointment made successfully! \n Service number: " +  Service_num.ToString() + " Service Date: " + date.ToString());
            Welcome w = new Welcome();
            w.ShowDialog();
            this.Hide();
        }
    }
}
