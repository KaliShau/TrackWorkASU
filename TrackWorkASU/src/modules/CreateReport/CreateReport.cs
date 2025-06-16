using System;
using System.Data;
using System.Windows.Forms;
using App.src.modules.CreateReport;

namespace App
{
    public partial class CreateReport : Form
    {
        DataTable user;
        CreateReportController _controller;
        public CreateReport(DataTable dt)
        {
            InitializeComponent();
            user = dt;
            _controller = new CreateReportController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.generate(comboBox1, user);
        }
    }
}
