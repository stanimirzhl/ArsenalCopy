using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Subjects : BaseChecker
    {
         static string query = @"
                    CREATE TABLE subjects (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        title NVARCHAR(255) NOT NULL,
                        [level] NVARCHAR(50) NOT NULL
                    );";
         static string insertDataQuery = @"
        INSERT INTO subjects (title, [level])
        VALUES 
        ('Mathematics', 'Primary'),
        ('Science', 'Primary'),
        ('History', 'Secondary'),
        ('Physics', 'High School'),
        ('Chemistry', 'Advanced'),
        ('English', 'Secondary'),
        ('Biology', 'High School'),
        ('Geography', 'Secondary');";

        public Subjects(SqlConnection connection) : base("subjects", query, insertDataQuery, connection)
        {
        }
    }
}
