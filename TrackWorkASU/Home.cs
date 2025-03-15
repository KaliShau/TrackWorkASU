using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Home : Form
    {

        public DataTable user;

        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form signin = new SignIn(this);
            signin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form signup = new SignUp(this);
            signup.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form child = new CreateReques(this.user);
            changeForm(child);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form child = new MyRequests(this.user);
            changeForm(child);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form child = new AllRequests(this.user);
            changeForm(child);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form child = new MyAssignedRequests(this.user);
            changeForm(child);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form child = new AddAsuStaff(this.user);
            changeForm(child);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form child = new Users();
            changeForm(child);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form child = new CreateReport(this.user);
            changeForm(child);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Form child = new AllReports();
            changeForm(child);
        }

        //<---- Utils ---->\\

        private void changeForm(Form form)
        {
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panel6.Controls.Clear();
            panel6.Controls.Add(form);
            form.Show();
        }

    }
}
