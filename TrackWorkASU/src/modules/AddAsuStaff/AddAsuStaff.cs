using System;
using System.Data;
using System.Windows.Forms;
using App.src.modules.AddAsuStaff;

namespace App
{
    public partial class AddAsuStaff : Form
    {
        AddAsuStaffController _controller;
        public AddAsuStaff(DataTable dt)
        {
            InitializeComponent();
            _controller = new AddAsuStaffController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.createOperator(textBox1, textBox2, textBox3);
        }
    }
}
