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
                    this._selectedRequestId = dataGridView1.Rows[hitTest.RowIndex].Cells[0].Value?.ToString();

                    // Показываем контекстное меню
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
            }


        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedRequestId))
            {
                try
                {
                   DatabaseManager db = new DatabaseManager();
                    db.updateRequestForAccepted(Convert.ToInt32(this._selectedRequestId), 2, Convert.ToInt16(this.user.Rows[0]["user_id"]));
                    dataGridView1.DataSource = db.getRequests();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при принятии запроса: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Не выбран request_id.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
