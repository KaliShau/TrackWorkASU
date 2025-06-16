using System;
using System.Data;
using System.Windows.Forms;
using App.src.modules.CreateRequest;

namespace App
{
    public partial class CreateRequest : Form
    {

        DataTable user;
        CreateRequestController _controller;
        public CreateRequest(DataTable dt)
        {
            InitializeComponent();
            user = dt;
            _controller = new CreateRequestController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.create(textBox1, user);
        }
    }
}
