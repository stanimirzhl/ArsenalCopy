using System;
using System.Data.SqlClient;

public abstract class BaseChecker
{
    private string tableName;
    private string tableCreationQuery;
    private string insertValueQuery;

    protected BaseChecker(string tableName, string createTableQuery, string insertDataQuery, SqlConnection connection)
    {
        this.tableName = tableName;
        this.tableCreationQuery = createTableQuery;
        this.insertValueQuery = insertDataQuery;
        if (!this.Exists(connection))
        {
            this.CreateTable(connection);
            this.InsertData(connection);
            Console.WriteLine($"Successfully created and inserted values into the table {tableName}");
        }
        else
        {
            if (!HasData(connection))
            {
                this.InsertData(connection);
                Console.WriteLine($"Successfully inserted values into table {tableName}");
                return;
            }
            Console.WriteLine($"Table {tableName} already exists and has values inserted in it!");
        }
    }

    private void CreateTable(SqlConnection connection)
    {
        using (SqlCommand command = new SqlCommand(tableCreationQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    private void InsertData(SqlConnection connection)
    {
        using (SqlCommand command = new SqlCommand(insertValueQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    private bool Exists(SqlConnection connection)
    {
        string query = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_name = @tableName";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@tableName", tableName);
            return (int)command.ExecuteScalar() > 0;
        }
    }

    private bool HasData(SqlConnection connection)
    {
        string query = $"SELECT COUNT(*) FROM {tableName}";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            return (int)command.ExecuteScalar() > 0;
        }
    }
}