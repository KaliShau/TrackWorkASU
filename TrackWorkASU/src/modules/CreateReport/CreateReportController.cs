using System;
using System.Data;
using System.Windows.Forms;

namespace App.src.modules.CreateReport
{
    public class CreateReportController
    {
        public CreateReportController() { }

        public void generate(ComboBox comboBox1, DataTable user)
        {
            if (comboBox1.Text == "Количество выполненных заявок за месяц")
            {
                DatabaseManager db = new DatabaseManager();
                db.reportClosedAtMonth(Convert.ToInt32(user.Rows[0]["user_id"]));
            }
        }
    }
}
