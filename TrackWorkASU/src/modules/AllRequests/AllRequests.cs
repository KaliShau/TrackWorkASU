using System;
using System.Data;
using System.Windows.Forms;
using App.src.modules.AllRequests;

namespace App
{
    public partial class AllRequests : Form
    {
        DataTable user;
        private string _selectedRequestId;
        AllRequestsController _controller;
        public AllRequests(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;
            _controller = new AllRequestsController();
            _controller.init(dataGridView1);
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
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

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.updateRequestForAccepted(_selectedRequestId, user, dataGridView1);
        }
    }
}
