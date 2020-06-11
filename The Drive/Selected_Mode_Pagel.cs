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
    public partial class Selected_Mode_Pagel : Form
    {
        public Selected_Mode_Pagel()
        {
            InitializeComponent();
        }

        Model_Page Model_PageForm = new Model_Page();
        

        private void button3_Click(object sender, EventArgs e)
        {
            Model_PageForm.ShowDialog();
            this.Close();
        }

        private void Selected_Mode_Pagel_Load(object sender, EventArgs e)
        {
            switch (Model_Page.modeltype)
            {
                case "A":
                    pictureBox1.Image = Properties.Resources._0a417e2fb6954a968fff041f49f6c6b4;
                    pictureBox2.Image = Properties.Resources.cdcssl_ibsrv_net;
                    pictureBox3.Image = Properties.Resources._4;
                    pictureBox4.Image = Properties.Resources.range_rover_evoque_hse_dynamic_7;
                    break;
                case "B":
                    pictureBox1.Image = Properties.Resources._2018_ford_mustang_shelby_gt350r_002;
                    pictureBox2.Image = Properties.Resources.Mustang_back;
                    pictureBox3.Image = Properties.Resources.Mustang_Front;
                    pictureBox4.Image = Properties.Resources.must_int;
                    break;
                case "C":
                    pictureBox1.Image = Properties.Resources.Capture;
                    pictureBox2.Image = Properties.Resources.merc_back;
                    pictureBox3.Image = Properties.Resources.merc_front;
                    pictureBox4.Image = Properties.Resources.merc_inter;
                    break;
                case "D":
                    pictureBox1.Image = Properties.Resources.USC90BMC681A021001;
                    pictureBox2.Image = Properties.Resources.bmw_back;
                    pictureBox3.Image = Properties.Resources.bmw_front;
                    pictureBox4.Image = Properties.Resources.bmw_int;
                    break;
            }
            label1.Text = "                        Standard Features \n\t- Automatic LED headlights \n\t -Climate control \n\t- 10 - inch Touch Pro infotainment" +
                "\n\t - Heated front seats \n\t -Rear camera \n\t - All - round parking sensors \n\t-Autonomous emergency braking \n\n\n                        Add ons";

            label1.Text += Cust_Selection.addon.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PurchaseForm pruchaseForm = new PurchaseForm();
            pruchaseForm.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cust_Selection myform = new Cust_Selection();
            myform.Show();
            this.Hide();
        }
    }
}
