using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Classrooms : BaseChecker
    {
        static string query = @"
                    CREATE TABLE classrooms (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        [floor] INT NOT NULL,
                        capacity INT NOT NULL,
                        [description] NVARCHAR(255)
                    );";
        static string insertDataQuery = @"INSERT INTO classrooms ([floor], capacity, [description])
               VALUES 
               (1, 30, 'Standard classroom with whiteboard and projector'),
               (2, 25, 'Small classroom for science experiments'),
               (3, 20, 'Computer lab with 15 PCs'),
               (1, 35, 'Large auditorium with stage for events');";

        public Classrooms(SqlConnection connection) : base("classrooms", query, insertDataQuery, connection)
        {
        }
    }
}
