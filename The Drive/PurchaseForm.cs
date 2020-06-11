using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Drive
{
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel model_Page = new Selected_Mode_Pagel();
            model_Page.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //please ignor this
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PAYMENT_PAGE paymentform = new PAYMENT_PAGE();

            paymentform.Show();
            this.Hide();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            switch (Model_Page.modeltype)
            {
                case "A":
                    pictureBox1.Image = Properties.Resources._0a417e2fb6954a968fff041f49f6c6b4;
                    label2.Text = "Range Rover";
                    label4.Text = "Evoque";
                    break;
                case "B":
                    pictureBox1.Image = Properties.Resources._2018_ford_mustang_shelby_gt350r_002;
                    label2.Text = "Mustang";
                    label4.Text = "Shelby";
                    break;
                case "C":
                    pictureBox1.Image = Properties.Resources.Capture;
                    label2.Text = "Mercedes-Benz";
                    label4.Text = "C-Class";
                    break;
                case "D":
                    pictureBox1.Image = Properties.Resources.USC90BMC681A021001;
                    label2.Text = "BMW";
                    label4.Text = "i8";
                    break;
            }
            double totalprice = 0.0;
            switch (Model_Page.modeltype)
            {
                case "A":
                    totalprice = 850000.00 + Cust_Selection.custprice;
                    break;
                case "B":
                    totalprice = 750000.00 + Cust_Selection.custprice;
                    break;
                case "C":
                    totalprice = 775000.00 + Cust_Selection.custprice;
                    break;
                case "D":
                    totalprice = 975000.00 + Cust_Selection.custprice;
                    break;
            }
            label6.Text = totalprice.ToString("c2");
            
            label8.Text = "\t\tAdd ons\n" + Cust_Selection.addon.ToString();
        }

    }
}
