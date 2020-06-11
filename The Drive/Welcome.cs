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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Confirmation_Page confirmation = new Confirmation_Page();
            confirmation.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model_Page model_Page = new Model_Page();
            model_Page.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.ShowDialog();
            this.Close();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            button2.Focus();
        }
    }
}
