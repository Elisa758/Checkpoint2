using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WCS
{
    public class Database
    {
        private static Database _instance = null;
        private SqlConnection _connection = null;

        public static Database Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Database();
                }
                return _instance;
            }
        }

        private Database()
        {

            string connectionString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=Checkpoint2_bc;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);

            _connection = conn;
        }


        public void Connect(SqlConnectionStringBuilder builder)
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                throw new Exception("Database already connected");
            }
            _connection.ConnectionString = builder.ConnectionString;
            _connection.Open();
        }

        public void DisplayStudentsByCursus(string cursusName)
        {
            //Create connection and open it.
            Database con = Database.Instance;
            _connection.Open();

            //create command object to pass the connection and other information
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;

            //set command type as stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //pass the stored procedure name
            cmd.CommandText = "sp_GetStudentsByCursus";

            //pass the parameter to stored procedure
            cmd.Parameters.Add(new SqlParameter("@CursusName", SqlDbType.VarChar)).Value = cursusName;

            List<string> columnsName = new List<string> { "StudentsName" };
                       
            using SqlDataReader dataread = cmd.ExecuteReader();
            
            if (dataread.HasRows)
            {
                while (dataread.Read())
                {
                    foreach (string item in columnsName)
                    {
                        Console.Write("Students in " + cursusName + " : " + dataread[item].ToString());
                    }
                    Console.WriteLine();
                }
            }
            dataread.Close();
            cmd.Dispose();
            _connection.Close();
        }

        public void DisplayStudentsByInstructor(int instructorId)
        {
            //Create connection and open it.
            //SqlConnection con = new SqlConnection(Database.Instance._connection);
            Database con = Database.Instance;
            _connection.Open();

            //create command object to pass the connection and other information
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;

            //set command type as stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            //pass the stored procedure name
            cmd.CommandText = "sp_GetStudentsByInstructor";

            //pass the parameter to stored procedure
            cmd.Parameters.Add(new SqlParameter("@InstructorId", SqlDbType.VarChar)).Value = instructorId;

            List<string> columnsName = new List<string> { "StudentsName" };

            using SqlDataReader dataread = cmd.ExecuteReader();

            if (dataread.HasRows)
            {
                while (dataread.Read())
                {
                    foreach (string item in columnsName)
                    {
                        Console.Write( "Students of " + instructorId + " : " + dataread[item].ToString());
                    }
                    Console.WriteLine();
                }
            }
            dataread.Close();
            cmd.Dispose();
            _connection.Close();
        }
    }
}
