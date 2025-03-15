using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App
{
    public class DatabaseManager
    {

        string StrConnection = "Server=localhost; port=5432; User Id=postgres ;Password=root;database=asu_database;";
        NpgsqlConnection Con;
        NpgsqlCommand Cmd;


        public void connection()
        {
            Con = new NpgsqlConnection();
            Con.ConnectionString = StrConnection;

            if (Con.State == System.Data.ConnectionState.Closed)
            {
                Con.Open();
            }
        }


        public DataTable login(string username, string pass)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Users WHERE username = :username AND password = :pass";
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }


        public DataTable register(string username, string pass, string fio)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            dt = this.login(username, pass);

            if (dt.Rows.Count > 0)
            {
                DataTable error = new DataTable();
                return error;
            }

            Cmd.CommandText = "INSERT INTO Users (full_name,username,password, role) VALUES(:fio,:username,:pass, 'Client');";
            Cmd.Parameters.AddWithValue("fio", fio);
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.ExecuteReader();


            dt = this.login(username, pass);

            return dt;
        }

        public void createOperator(string username, string pass, string fio)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandText = "INSERT INTO Users (full_name,username,password, role) VALUES(:fio,:username,:pass, 'ASU_staff');";
            Cmd.Parameters.AddWithValue("fio", fio);
            Cmd.Parameters.AddWithValue("username", username);
            Cmd.Parameters.AddWithValue("pass", pass);
            Cmd.ExecuteReader();
            MessageBox.Show("Оператор добавлен!!");

        }

        public DataTable getStatuses()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * from Statuses;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getStatusesByName(string name)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * from Statuses WHERE status_name = :name;";
            Cmd.Parameters.AddWithValue("name", name);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void createRequest(string content, int status_id, int client_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "INSERT INTO Requests (client_id, content, status_id) VALUES (:client_id, :content, :status_id);";
            Cmd.Parameters.AddWithValue("client_id", client_id);
            Cmd.Parameters.AddWithValue("content", content);
            Cmd.Parameters.AddWithValue("status_id", status_id);

            Cmd.ExecuteReader();
            MessageBox.Show("Заявка добавлена!!");
        }
        public DataTable getReports()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * FROM Reports;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void updateRequestForAccepted(int request_id, int status_id, int assigned_to)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "Update Requests SET status_id = :status_id, assigned_to = :assigned_to WHERE request_id = :request_id;";
            Cmd.Parameters.AddWithValue("request_id", request_id);
            Cmd.Parameters.AddWithValue("status_id", status_id);
            Cmd.Parameters.AddWithValue("assigned_to", assigned_to);

            Cmd.ExecuteReader();
            MessageBox.Show("Запрос выполнен!!");
        }

        public void updateRequestClosedAt(int request_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "Update Requests SET closed_at = NOW() WHERE request_id = :request_id;";
            Cmd.Parameters.AddWithValue("request_id", request_id);

            Cmd.ExecuteReader();
            MessageBox.Show("Запрос выполнен!!");
        }


        public DataTable getRequestsClient(int client_id)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * from Requests WHERE client_id = :client_id;";
            Cmd.Parameters.AddWithValue("client_id", client_id);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getRequests()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT r.*, s.status_name from Requests r JOIN Statuses s ON r.status_id = s.status_id;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getUsers()
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT * from Users;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public DataTable getRequestsAssigned(int assigned_to)
        {
            DataTable dt = new DataTable();
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT r.*, s.status_name from Requests r JOIN Statuses s ON r.status_id = s.status_id WHERE assigned_to = :assigned_to;";
            Cmd.Parameters.AddWithValue("assigned_to", assigned_to);

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        public void reportClosedAtMonth(int user_id)
        {
            connection();
            Cmd = new NpgsqlCommand();
            Cmd.Connection = Con;

            string sql = @"
                SELECT 
                    DATE_TRUNC('month', closed_at) AS month,
                    COUNT(*) AS closed_requests_count
                FROM 
                    Requests
                WHERE 
                    closed_at IS NOT NULL
                GROUP BY 
                    DATE_TRUNC('month', closed_at)
                ORDER BY 
                    month;";
            Cmd.CommandText = sql;
            NpgsqlDataReader dr = Cmd.ExecuteReader();

            while (dr.Read())
            {
                DateTime month = dr.GetDateTime(0);
                int closedRequestsCount = dr.GetInt32(1);

                string reportTitle = $"Отчет по закрытым заявкам за {month:MMMM yyyy}";
                string reportText = $"Количество закрытых заявок: {closedRequestsCount}";

                SaveReportToDatabase(user_id, reportTitle, reportText);
            }
        }

        private void SaveReportToDatabase(int user_id, string reportTitle, string reportText)
        {
            using (var insertCon = new NpgsqlConnection(StrConnection))
            {
                insertCon.Open();

                string insertSql = @"
            INSERT INTO Reports (user_id, report_title, report_text)
            VALUES (@user_id, @report_title, @report_text);";

                using (var insertCmd = new NpgsqlCommand(insertSql, insertCon))
                {
                    insertCmd.Parameters.AddWithValue("user_id", user_id);
                    insertCmd.Parameters.AddWithValue("report_title", reportTitle);
                    insertCmd.Parameters.AddWithValue("report_text", reportText);
                    insertCmd.Parameters.AddWithValue("created_at", DateTime.Now);

                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Отчет создан");
                }
            }
        }

        public void ExportReportClosedAtMonthToDocx(int reportId)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents|*.docx"; 
            saveFileDialog.Title = "Сохранить отчет";
            saveFileDialog.FileName = $"Отчет_{DateTime.Now:yyyyMMdd_HHmmss}.docx"; 

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName; 

                using (var connection = new NpgsqlConnection(StrConnection))
                {
                    connection.Open();

                    string sql = @"
                    SELECT report_title, report_text, created_at
                    FROM Reports
                    WHERE report_id = @report_id;";

                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("report_id", reportId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string reportTitle = reader.GetString(0);
                                string reportText = reader.GetString(1);
                                DateTime createdAt = reader.GetDateTime(2);

                                using (var doc = DocX.Create(filePath))
                                {
                                    var title = doc.InsertParagraph(reportTitle);
                                    title.FontSize(18).Bold().Alignment = Alignment.center;

                                    var text = doc.InsertParagraph(reportText);
                                    text.FontSize(12).Alignment = Alignment.left;

                                    var date = doc.InsertParagraph($"Дата создания: {createdAt:dd.MM.yyyy HH:mm}");
                                    date.FontSize(12).Italic().Alignment = Alignment.right;

                                    doc.Save();
                                }

                                MessageBox.Show($"Отчет успешно сохранен: {filePath}");
                            }
                            else
                            {
                                MessageBox.Show("Отчет с указанным ID не найден.");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Сохранение отчета отменено.");
            }
        }
    }
}