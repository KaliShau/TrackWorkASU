using System;
using System.Data;
using System.Windows.Forms;

namespace App.src.modules.SignIn
{
    public class SignInController
    {
        public SignInController() { }

        public void signin(Home home, TextBox textBox1, TextBox textBox2, Form form)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

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
                home.groupBox1.Visible = false;
                home.groupBox2.Visible = true;
                home.groupBox3.Visible = false;
                home.groupBox4.Visible = false;
                home.groupBox5.Visible = false;
            }

            if (Convert.ToString(dt.Rows[0]["role"]) == "ASU_staff")
            {
                home.groupBox1.Visible = false;
                home.groupBox2.Visible = true;
                home.groupBox3.Visible = true;
                home.groupBox4.Visible = false;
                home.groupBox5.Visible = true;
            }

            if (Convert.ToString(dt.Rows[0]["role"]) == "Admin")
            {
                home.groupBox1.Visible = false;
                home.groupBox2.Visible = true;
                home.groupBox3.Visible = true;
                home.groupBox4.Visible = true;
                home.groupBox5.Visible = true;
            }


            home.user = dt;
            form.Close();

        }
    }
}
