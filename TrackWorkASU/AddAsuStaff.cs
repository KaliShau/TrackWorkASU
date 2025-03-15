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
    public partial class AddAsuStaff : Form
    {
        DataTable user;
        public AddAsuStaff(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            string fullname = this.textBox3.Text;

            if (username == "" || password == "" || fullname == "")
            {
                return;
            }

            DataTable dt = new DataTable();
            DatabaseManager db = new DatabaseManager();
            db.createOperator(username, password, fullname);

            
        }
    }
}
