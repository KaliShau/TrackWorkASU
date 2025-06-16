using System;
using System.Data;
using System.Windows.Forms;

namespace App.src.modules.MyAssignedTickets
{
    public class MyAssignedRequestsController
    {
        public MyAssignedRequestsController() { }

        public void init(DataTable user, DataGridView grid)
        {
            DatabaseManager db = new DatabaseManager();
            grid.DataSource = db.getRequestsAssigned(Convert.ToInt32(user.Rows[0]["user_id"]));
        }

        public void update(string _selectedRequestId, DataTable user, DataGridView grid)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                    DatabaseManager db = new DatabaseManager();
                    db.updateRequestForAccepted(Convert.ToInt32(_selectedRequestId), 3, Convert.ToInt16(user.Rows[0]["user_id"]));
                    db.updateRequestClosedAt(Convert.ToInt32(_selectedRequestId));
                    grid.DataSource = db.getRequestsAssigned(Convert.ToInt32(user.Rows[0]["user_id"]));

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
