using System.Windows.Forms;
using App.src.modules.Users;

namespace App
{
    public partial class Users : Form
    {
        UsersController _controller;
        public Users()
        {
            InitializeComponent();
            _controller = new UsersController();
            _controller.init(dataGridView1);
        }
    }
}
