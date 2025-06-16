using System.Data;
using System.Windows.Forms;

namespace App.src.modules.AddAsuStaff
{
    public class AddAsuStaffController
    {
        public AddAsuStaffController() { }

        public void createOperator(TextBox textBox1, TextBox textBox2, TextBox textBox3)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string fullname = textBox3.Text;

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
