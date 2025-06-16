using System;
using System.Data;
using System.Windows.Forms;

namespace App.src.modules.MyRequests
{
    public class MyRequestsController
    {
        public MyRequestsController() { }

        public void init(DataTable user, DataGridView grid)
        {
            DatabaseManager db = new DatabaseManager();
            grid.DataSource = db.getRequestsClient(Convert.ToInt16(user.Rows[0]["user_id"]));
        }
    }
}
