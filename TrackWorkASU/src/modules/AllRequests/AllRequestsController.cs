using System;
using System.Data;
using System.Windows.Forms;

namespace App.src.modules.AllRequests
{
    public class AllRequestsController
    {
        public AllRequestsController() { }

        public void init(DataGridView grid)
        {
            DatabaseManager db = new DatabaseManager();
            grid.DataSource = db.getRequests();
        }

        public void updateRequestForAccepted(string _selectedRequestId, DataTable user, DataGridView grid)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DatabaseManager db = new DatabaseManager();
                    db.updateRequestForAccepted(Convert.ToInt32(_selectedRequestId), 2, Convert.ToInt16(user.Rows[0]["user_id"]));
                    grid.DataSource = db.getRequests();

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
