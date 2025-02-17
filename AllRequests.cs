using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class AllRequests : Form
    {
        DataTable user;
        private string _selectedRequestId;
        public AllRequests(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;

            DatabaseManager db = new DatabaseManager();
            dataGridView1.DataSource = db.getRequests();

            dataGridView1.ContextMenuStrip = contextMenuStrip1;

            dataGridView1.MouseClick += DataGridView1_MouseClick;

            toolStripMenuItem1.Click += CopyToolStripMenuItem_Click;


        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Определяем, по какой строке и столбцу был клик
                var hitTest = dataGridView1.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
                {
                    // Выделяем строку
                    dataGridView1.Rows[hitTest.RowIndex].Selected = true;

                    // Получаем значение столбца "request_id"
                    _selectedRequestId = dataGridView1.Rows[hitTest.RowIndex].Cells["request_id"].Value?.ToString();

                    // Показываем контекстное меню
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }

        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                MessageBox.Show($"Скопировано request_id: {_selectedRequestId}");
            }
            else
            {
                MessageBox.Show("Значение request_id отсутствует.");
            }
        }
    }
}
