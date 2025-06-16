using System.Windows.Forms;

namespace App.src.modules.Users
{
    public class UsersController
    {
        public UsersController() { }

        public void init(DataGridView grid)
        {
            DatabaseManager db = new DatabaseManager();
            grid.DataSource = db.getUsers();
        }
    }
}
