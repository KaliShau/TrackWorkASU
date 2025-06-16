using System;
using System.Windows.Forms;
using App.src.modules.AllReports;

namespace App
{
    public partial class AllReports : Form
    {
        private string _selectedRequestId;
        AllReportsController _controller;
        public AllReports()
        {
            InitializeComponent();
            _controller = new AllReportsController();

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
            _controller.export(_selectedRequestId, dataGridView1);
        }
    }
}
