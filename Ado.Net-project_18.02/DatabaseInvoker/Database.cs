using ConsoleApp1;
using System.Data.SqlClient;
using System.Reflection;

namespace DatabaseInvoker
{
    public class Database
    {
        public static void CreateDb()
        {
            string masterConnectionString = @"Server=(localdb)\ProjectModels;Database=master;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
            string schoolConnectionString = @"Server=(localdb)\ProjectModels;Database=school;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection masterConnection = new SqlConnection(masterConnectionString))
            {
                masterConnection.Open();

                if (!DatabaseExists(masterConnection, "school"))
                {
                    string createDatabaseQuery = "CREATE DATABASE school";
                    ExecuteQuery(masterConnection, createDatabaseQuery);
                    Console.WriteLine("Database successfully created.");
                }
                else
                {
                    Console.WriteLine("Database already exists!");
                }
            }
            using (SqlConnection schoolConnection = new SqlConnection(schoolConnectionString))
            {
                schoolConnection.Open();

                var tables = new BaseChecker[]
                {
                    new Subjects(schoolConnection),
                    new Teachers(schoolConnection),
                    new Classrooms(schoolConnection),
                    new Parents(schoolConnection),
                    new Classes(schoolConnection),
                    new Students(schoolConnection),
                    new Students_Parents(schoolConnection),
                    new Teachers_Subjects(schoolConnection),
                    new Classes_Subjects(schoolConnection)

                };
            }
        }
        static bool DatabaseExists(SqlConnection connection, string databaseName)
        {
            string query = $"SELECT database_id FROM sys.databases WHERE Name = @databaseName";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@databaseName", databaseName);
                return command.ExecuteScalar() != null;
            }
        }
        static void ExecuteQuery(SqlConnection connection, string query)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection is not open. Opening connection...");
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
