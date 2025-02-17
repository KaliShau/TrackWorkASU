using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            Cmd.CommandText = "SELECT * from Requests;";

            NpgsqlDataReader dr = Cmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
    }
}