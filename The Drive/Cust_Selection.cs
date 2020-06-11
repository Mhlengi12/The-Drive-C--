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
    public partial class Cust_Selection : Form
    {
        public Cust_Selection()
        {
            InitializeComponent();
        }

        
        public static double custprice = 0.0;
        public static string addon = "";
        public static string checkeditem = "";

        private void button2_Click(object sender, EventArgs e)
        {
            //closing this page and opening the welcome
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adding selected items to list
            try
            {
                if (checkBox1.Checked == true)
                {
                    addon += "\n" + checkBox1.Text;
                    checkeditem += "1";
                }
                if (checkBox2.Checked == true)
                {
                    addon += "\n" + checkBox2.Text;
                    checkeditem += "2";
                }
                if (checkBox3.Checked == true)
                {
                    addon += "\n" + checkBox3.Text;
                    checkeditem += "3";
                }
                if (checkBox4.Checked == true)
                {
                    addon += "\n" + checkBox4.Text;
                    checkeditem += "4";
                }
                if (checkBox5.Checked == true)
                {
                    addon += "\n" + checkBox5.Text;
                    checkeditem += "5";
                }
                if (checkBox6.Checked == true)
                {
                    addon += "\n" + checkBox6.Text;
                    checkeditem += "6";
                }
                if (checkBox7.Checked == true)
                {
                    addon += "\n" + checkBox7.Text;
                    checkeditem += "7";
                }
                if (checkBox8.Checked == true)
                {
                    addon += "\n" + checkBox8.Text;
                    checkeditem += "8";
                }
                if (checkBox9.Checked == true)
                {
                    addon += "\n" + checkBox9.Text;
                    checkeditem += "9";
                }
                if (checkBox10.Checked == true)
                {
                    addon += "\n" + checkBox10.Text;
                    checkeditem += "ten";
                }
                Selected_Mode_Pagel selectedform = new Selected_Mode_Pagel();
                selectedform.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //ingnor this
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //adding selected colour to add-on list
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    label2.BackColor = Color.White ; 
                    break;
                case 1:
                    label2.BackColor = Color.Black;
                    break;
                case 2:
                    label2.BackColor = Color.ForestGreen;
                    break;
                case 3:
                    label2.BackColor = Color.DeepSkyBlue;
                    break;
                case 4:
                    label2.BackColor = Color.HotPink;
                    break;
                case 5:
                    label2.BackColor = Color.OrangeRed;
                    break;


            }
            Boolean value = false;
            if(comboBox1.SelectedIndex > 0)
            {
                if (value == false)
                {
                    custprice += 50.0;
                    value = true;
                    label4.Text = custprice.ToString("c2");
                }
            }
            else
            {
                if (value == true)
                {
                    custprice -= 50.0;
                    value = false;
                    label4.Text = custprice.ToString("c2");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selectedform = new Selected_Mode_Pagel();
            selectedform.Show();
            this.Hide();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                custprice += 2250.00;
                listBox1.Items.Add(checkBox6.ToString());
            }
            else
            {
                custprice -= 2250.00;
                listBox1.Items.Remove(checkBox6.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void Cust_Selection_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            addon = "";
            listBox1.Items.Clear();
            custprice = 0.0;
            
            if (checkeditem.Contains("1"))
            {
                checkBox1.Checked = true;
            }
            if (checkeditem.Contains("2"))
            {
                checkBox2.Checked = true;
            }
            if (checkeditem.Contains("3"))
            {
                checkBox3.Checked = true;
            }
            if (checkeditem.Contains("4"))
            {
                checkBox4.Checked = true;
            }
            if (checkeditem.Contains("5"))
            {
                checkBox5.Checked = true;
            }
            if (checkeditem.Contains("6"))
            {
                checkBox6.Checked = true;
            }
            if (checkeditem.Contains("7"))
            {
                checkBox7.Checked = true;
            }
            if (checkeditem.Contains("8"))
            {
                checkBox8.Checked = true;
            }
            if (checkeditem.Contains("9"))
            {
                checkBox9.Checked = true;
            }
            if (checkeditem.Contains("ten"))
            {
                checkBox10.Checked = true;
            }
            label4.Text = custprice.ToString("c2");
            
        }
        //adding the add-ons and prices to the list
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                custprice += 1200.00;
                listBox1.Items.Add(checkBox1.ToString());
            }
            else
            {
                custprice -= 1200.00;
                listBox1.Items.Remove(checkBox1.ToString());

            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                custprice += 1500.00;
                listBox1.Items.Add(checkBox2.ToString());
            }
            else
            {
                custprice -= 1500.00;
                listBox1.Items.Remove(checkBox2.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                custprice += 1300.00;
                listBox1.Items.Add(checkBox3.ToString());
            }
            else
            {
                custprice -= 1300.00;
                listBox1.Items.Remove(checkBox3.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                custprice += 1150.00;
                listBox1.Items.Add(checkBox4.ToString());
            }
            else
            {
                custprice -= 1150.00;
                listBox1.Items.Remove(checkBox4.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                custprice += 2100.00;
                listBox1.Items.Add(checkBox5.ToString());
            }
            else
            {
                custprice -= 2100.00;
                listBox1.Items.Remove(checkBox5.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                custprice += 1800.00;
                listBox1.Items.Add(checkBox7.ToString());
            }
            else
            {
                custprice -= 1800.00;
                listBox1.Items.Remove(checkBox7.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                custprice += 2700.00;
                listBox1.Items.Add(checkBox8.ToString());
            }
            else
            {
                custprice -= 2700.00;
                listBox1.Items.Remove(checkBox8.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                custprice += 1400.00;
                listBox1.Items.Add(checkBox9.ToString());
            }
            else
            {
                custprice -= 1400.00;
                listBox1.Items.Remove(checkBox9.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                custprice += 2400.00;
                listBox1.Items.Add(checkBox10.ToString());
            }
            else
            {
                custprice -= 2400.00;
                listBox1.Items.Remove(checkBox10.ToString());
            }
            label4.Text = custprice.ToString("c2");
        }
    }
}
