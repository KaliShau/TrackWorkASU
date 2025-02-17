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
    public partial class SignIn : Form
    {

        Home home;

        public SignIn(Home form)
        {
            InitializeComponent();
            this.home = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (username == "" || password == "")
            {
                return;
            }

            DataTable dt = new DataTable();
            DatabaseManager db = new DatabaseManager();
            dt = db.login(username, password);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            if (Convert.ToString(dt.Rows[0]["role"]) == "Client")
            {
                this.home.groupBox1.Visible = false;
                this.home.groupBox2.Visible = true;
                this.home.groupBox3.Visible = false;
            }

            if (Convert.ToString(dt.Rows[0]["role"]) == "ASU_staff")
            {
                this.home.groupBox1.Visible = false;
                this.home.groupBox2.Visible = true;
                this.home.groupBox3.Visible = true;
            }

            if (Convert.ToString(dt.Rows[0]["role"]) == "Admin")
            {
                this.home.groupBox1.Visible = false;
                this.home.groupBox2.Visible = true;
                this.home.groupBox3.Visible = true;
            }


            this.home.user = dt;
            this.Close();

        }
    }
}
