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
using System.Net;
using System.Net.Mail;

namespace The_Drive
{
    public partial class PAYMENT_PAGE : Form
    {
        public PAYMENT_PAGE()
        {
            InitializeComponent();
        }
        //string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Zanele Thwala\Desktop\The Drive\The Drive\The Drive DB.mdf;Integrated Security=True";
        SqlConnection con;
        private void PAYMENT_PAGE_Load(object sender, EventArgs e)
        {
       

            switch (Model_Page.modeltype)
            {
                case "A":
                    baseprice = 850000.00;
                    break;
                case "B":
                    baseprice = 750000.00;
                    break;
                case "C":
                    baseprice = 775000.00;
                    break;
                case "D":
                    baseprice = 975000.00;
                    break;
            }
            label5.Text = baseprice.ToString("C2");
            label6.Text = Cust_Selection.custprice.ToString("C2");
           double totalprice = Cust_Selection.custprice + baseprice;
            label7.Text = totalprice.ToString("C2");

            label14.Visible = false;
            label15.Visible = false;
            label12.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            comboBox3.Visible = false;
        }
        public static double baseprice = 0.0;
        private void button3_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.ShowDialog();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label14.Visible = true;
            label15.Visible = true;
            textBox3.Visible = true;
            textBox5.Visible = true;
            label12.Visible = true;
            comboBox3.Visible = true;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label14.Visible = false;
            label15.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            label12.Visible = false;
            comboBox3.Visible = false;
        }

        string acc_num, pay_method = "Cash", tot_cost, client_name, installment,bank_name;
        
        int product_num, order_num;

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            string Client_ID = login.Client_id_str;

            acc_num = textBox2.Text;


            if (radioButton1.Checked)
            {
                pay_method = radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                pay_method = radioButton2.Text;
            }

            tot_cost = label7.Text;
            client_name = textBox1.Text;
            bank_name = textBox5.Text;

            if (pay_method == radioButton1.Text)
            {
                installment = "Cash payment";
            }
            else
            {
                installment = (textBox3.Text);
            }

            if (textBox2.TextLength <= 0)
            {
                MessageBox.Show("Please enter your account number");
            }
            else
            {
                
                //Account insert
                account_insert();

                //Insert Product and Order
                product_order_insert();


                MessageBox.Show("Successfull Purchase!\nThank you for your order\nPlease keep your pruchase ID: " + manufacture() + Client_ID + ", for reference " +
                    "\n An email of with the details of your purchase has been sent to you. \n If you do not receive our confirmation emaiil within 24 hours please contact us on Infinity@gmail.com");
                sendmail();
                Welcome welcome1 = new Welcome();
                this.Hide();
                welcome1.Show();
            }
            try
            {
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
                
        }

        private void account_insert()
        {
            Login login = new Login();
            string Client_ID = login.Client_id_str;
            double totalprice = Cust_Selection.custprice + baseprice;

            con = new SqlConnection(Login.conString);
            con.Open();

            string account_insert = "INSERT INTO Account (Account_number, Client_ID ,Payment_method, Total_cost, Bank_name, Monthly_installment, Credit_score)"
               + " VALUES('" + acc_num + "', '" + Client_ID + "', '" + pay_method + "', '" + totalprice + "', '" + bank_name + "', '" + installment + "', '" + " "+ "')";

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(account_insert, con);

            adapter.InsertCommand = new SqlCommand(account_insert, con);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();

            con.Close();
        }

        private void product_order_insert()
        {
            
            try
            {
                Login login = new Login();
                string Client_ID = login.Client_id_str;

                con = new SqlConnection(Login.conString);
                con.Open();

                SqlDataAdapter adapter_order = new SqlDataAdapter("Select isnull(max(cast([Order_number] as int)),0)+1 From Order_table", con);
                //Recieve largest order number and plus 1 

                DataTable dt = new DataTable();
                adapter_order.Fill(dt);
                order_num = int.Parse(dt.Rows[0][0].ToString());

                SqlDataAdapter adapter_product = new SqlDataAdapter("Select isnull(max(cast([Product_number] as int)),0)+1 From Order_table", con);
                DataTable dt1 = new DataTable();
                adapter_order.Fill(dt1);
                product_num = int.Parse(dt1.Rows[0][0].ToString());

                string orderinsert = "INSERT INTO Order_table ([Order_number], [Product_number], [Total_cost],[Delivery_date], Manufacture, Customisation, [Additional_cost], Client_id)"
                    + " VALUES('" + order_num + "', '" + product_num + "', '" + tot_cost + "', '" + (DateTime.Today.AddMonths(6)).ToString() + "', '" + manufacture() + "', '" + Cust_Selection.addon.ToString() + "', '" + Cust_Selection.custprice.ToString() + "', '" + Client_ID + "')";

                SqlDataAdapter adapter_order2 = new SqlDataAdapter();
                SqlCommand command_order = new SqlCommand(orderinsert, con);

                adapter_order2.InsertCommand = new SqlCommand(orderinsert, con);
                adapter_order2.InsertCommand.ExecuteNonQuery();
                command_order.Dispose();


                //Product Insert

                string prod_insert = "INSERT INTO Product ([Product_number], [Client_id], [Product_brand], [Product_modal], [Standard_features])"
                    + " VALUES('" + product_num + "', '" + Client_ID + "', '" + manufacture() + "', '" + manufacture() + "', '" + "?????" + "')";

                SqlDataAdapter adapter_product2 = new SqlDataAdapter();
                SqlCommand command_product = new SqlCommand(prod_insert, con);

                adapter_order2.InsertCommand = new SqlCommand(prod_insert, con);
                adapter_order2.InsertCommand.ExecuteNonQuery();
                command_product.Dispose();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendmail()
        {
            
            try
            {
                SqlCommand command;
                SqlDataReader reader;
                Login login = new Login();
                string Client_ID = login.Client_id_str;
                string to = "", from, pass, body;
                string sql = "Select * From ClientData Where Client_ID ='" + Client_ID + "'";

                con = new SqlConnection(Login.conString);
                con.Open();

                command = new SqlCommand(sql, con);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    to = reader.GetValue(3).ToString();
                }
                command.Dispose();
                con.Close();

                from = "mshadow0012@gmail.com";

                body = "Dear Sir / ma'am \n" +
                    "Reference number: " + manufacture() + Client_ID + "\n" +
                    "Congratulation on purchasing you new " + manufacture() + "" + DateTime.Today + " \n" +
                    "Delivery date: " + (DateTime.Today.AddMonths(6)) + "\n" +
                    "Retrieval method: collection at dealership \n" +
                    "We hope you enjoy your" + manufacture() + " \n" +
                    "Thank you for using TheDrive \n\n" +
                    "Sincerely Infinity.";

                pass = "chippzunnuff12";
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = body;
                message.Subject = "Testing mail";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);


                smtp.Send(message);
                MessageBox.Show("An email has been sent to you", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            double installment = 0.0, subinstallment, interest, baseprice = PAYMENT_PAGE.baseprice;

            if (comboBox3.SelectedIndex == 0)
            {
                subinstallment = baseprice / 36;
                interest = subinstallment * 0.15;
                installment = subinstallment + interest;
                textBox3.Text = installment.ToString("C2");
            }
            if (comboBox3.SelectedIndex == 1)
            {
                subinstallment = baseprice / 48;
                interest = subinstallment * 0.15;
                installment = subinstallment + interest;
                textBox3.Text = installment.ToString("C2");
            }
            if (comboBox3.SelectedIndex == 2)
            {
                subinstallment = baseprice / 60;
                interest = subinstallment * 0.15;
                installment = subinstallment + interest;
                textBox3.Text = installment.ToString("C2");
            }
            if (comboBox3.SelectedIndex == 3)
            {
                subinstallment = baseprice / 72;
                interest = subinstallment * 0.15;
                installment = subinstallment + interest;
                textBox3.Text = installment.ToString("C2");
            }
        }
        private string manufacture()
        {
            string manu = "";

            switch (Model_Page.modeltype)
            {
                case "A":
                    manu = "Range Rover";
                    break;
                case "B":
                    manu = "Mustang";
                    break;
                case "C":
                    manu = "Mercedes-Benz";
                    break;
                case "D":
                    manu = "BMW";
                    break;
            }

            return manu;
        }
    }
}
