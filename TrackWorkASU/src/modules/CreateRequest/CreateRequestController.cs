using System;
using System.Data;
using System.Windows.Forms;

namespace App.src.modules.CreateRequest
{
    public class CreateRequestController
    {
        public CreateRequestController() { }

        public void create(TextBox textBox1, DataTable user)
        {
            string content = textBox1.Text;

            if (content == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }

            DatabaseManager db = new DatabaseManager();
            db.createRequest(content, Convert.ToInt16(db.getStatusesByName("Новая").Rows[0]["status_id"]), Convert.ToInt16(user.Rows[0]["user_id"]));
        }
    }
}
