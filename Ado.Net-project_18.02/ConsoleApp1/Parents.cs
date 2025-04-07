using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Parents : BaseChecker
    {
        static string query = @"
                    CREATE TABLE parents (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        parent_code NVARCHAR(50) NOT NULL,
                        full_name NVARCHAR(255) NOT NULL,
                        email NVARCHAR(255) NOT NULL,
                        phone NVARCHAR(20) NOT NULL
                    );";
        static string insertDataQuery = @"INSERT INTO parents (parent_code, full_name, email, phone)
         VALUES 
         ('P001', 'Mary Doe', 'marydoe@example.com', '111-222-3333'),
         ('P002', 'Robert Smith', 'robertsmith@example.com', '444-555-6666'),
         ('P003', 'Sarah Johnson', 'sarahj@example.com', '555-111-8888'),
         ('P004', 'David Green', 'davidgreen@example.com', '666-777-9999');";

        public Parents(SqlConnection connection) : base("parents", query, insertDataQuery, connection)
        {
        }
    }
}
