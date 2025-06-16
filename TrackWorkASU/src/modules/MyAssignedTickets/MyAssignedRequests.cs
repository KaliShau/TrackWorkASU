using System;
using System.Data;
using System.Windows.Forms;
using App.src.modules.MyAssignedTickets;

namespace App
{
    public partial class MyAssignedRequests : Form
    {
        DataTable user;
        private string _selectedRequestId;
        MyAssignedRequestsController _controller;
        public MyAssignedRequests(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;

            _controller = new MyAssignedRequestsController();
            _controller.init(user, dataGridView1);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _controller.update(_selectedRequestId, user, dataGridView1);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    this._selectedRequestId = dataGridView1.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();

                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }
        }
    }
}
