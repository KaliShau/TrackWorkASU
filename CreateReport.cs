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
    public partial class CreateReport : Form
    {
        DataTable user;
        public CreateReport(DataTable dt)
        {
            InitializeComponent();
            user = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Количество выполненных заявок за месяц")
            {
                DatabaseManager db = new DatabaseManager();
                db.reportClosedAtMonth(Convert.ToInt32(this.user.Rows[0]["user_id"]));
            }
        }
    }
}
