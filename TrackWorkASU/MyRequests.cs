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
    public partial class MyRequests : Form
    {
        DataTable user;
        public MyRequests(DataTable dt)
        {
            InitializeComponent();
            this.user = dt;

            DatabaseManager db = new DatabaseManager();
            dataGridView1.DataSource = db.getRequestsClient(Convert.ToInt16(this.user.Rows[0]["user_id"]));
        }
    }
}
