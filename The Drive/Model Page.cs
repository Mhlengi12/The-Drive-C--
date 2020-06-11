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
    public partial class Model_Page : Form
    {
        public Model_Page()
        {
            InitializeComponent();
        }
        //displaying the next page deplending on what model was chosen
        
        public static string modeltype = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "A";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "B";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "C";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "D";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void Model_Page_Load(object sender, EventArgs e)
        {
            Cust_Selection.custprice = 0.0;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "B";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "A";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "C";
            selected_ModelForm.Show();
            this.Hide();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Selected_Mode_Pagel selected_ModelForm = new Selected_Mode_Pagel();
            modeltype = "D";
            selected_ModelForm.Show();
            this.Hide();
        }
    }
}
