using System;
using System.Data;
using System.Windows.Forms;
using App.src.shared;

namespace App
{
    public partial class Home : Form
    {
        public DataTable user;
        FormManager _formManager;
        public Home()
        {
            InitializeComponent();
            _formManager = new FormManager();
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
            Form child = new CreateRequest(this.user);
            _formManager.changeForm(child, panel6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form child = new MyRequests(this.user);
            _formManager.changeForm(child, panel6);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form child = new AllRequests(this.user);
            _formManager.changeForm(child, panel6);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form child = new MyAssignedRequests(this.user);
            _formManager.changeForm(child, panel6);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Form child = new AddAsuStaff(this.user);
            _formManager.changeForm(child, panel6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Form child = new Users();
            _formManager.changeForm(child, panel6);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form child = new CreateReport(this.user);
            _formManager.changeForm(child, panel6);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Form child = new AllReports();
            _formManager.changeForm(child, panel6);
        }
    }
}
