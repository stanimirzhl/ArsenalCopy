using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Students_Parents : BaseChecker
    {
        static string query = @"
                    CREATE TABLE students_parents (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        student_id INT FOREIGN KEY REFERENCES students(id),
                        parent_id INT FOREIGN KEY REFERENCES parents(id)
                    );";
        static string insertDataQuery = @"
        INSERT INTO students_parents (student_id, parent_id)
        VALUES 
        (1, 1),
        (2, 2),
        (3, 3),
        (4, 4),
        (5, 1),
        (6, 2);";

        public Students_Parents(SqlConnection connection) : base("students_parents",query, insertDataQuery, connection)
        {
        }
    }
}
