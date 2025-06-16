using System;
using System.Windows.Forms;

namespace App.src.modules.AllReports
{
    public class AllReportsController
    {
        public AllReportsController() { }

        public void init(DataGridView grid)
        {
            DatabaseManager db = new DatabaseManager();
            grid.DataSource = db.getReports();
        }

        public void export(string _selectedRequestId, DataGridView grid)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DatabaseManager db = new DatabaseManager();
                    db.ExportReportClosedAtMonthToDocx(Convert.ToInt32(_selectedRequestId));
                    grid.DataSource = db.getReports();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при принятии запроса: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Не выбран request_id.");
            }
        }
    }
}
