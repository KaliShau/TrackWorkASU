using System.Data;
using System.Windows.Forms;
using App.src.modules.MyRequests;

namespace App
{
    public partial class MyRequests : Form
    {
        DataTable user;
        MyRequestsController _controller;
        public MyRequests(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;

            _controller = new MyRequestsController();
            _controller.init(user, dataGridView1);
        }
    }
}
