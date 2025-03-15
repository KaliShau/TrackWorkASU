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
    public partial class CreateReques : Form
    {

        DataTable user;
        DataTable statuses;
        public CreateReques(DataTable dt)
        {
            InitializeComponent();
            user = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string content = textBox1.Text;

            if (content == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }


            DatabaseManager db = new DatabaseManager();

            db.createRequest(content, Convert.ToInt16(db.getStatusesByName("Новая").Rows[0]["status_id"]), Convert.ToInt16(this.user.Rows[0]["user_id"]));
        }
    }
}
