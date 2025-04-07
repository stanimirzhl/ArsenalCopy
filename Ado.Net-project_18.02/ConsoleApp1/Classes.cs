using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Classes : BaseChecker
    {
        static string query = @"
                        CREATE TABLE classes (
                        id INT PRIMARY KEY IDENTITY,
                        class_number INT NOT NULL,
                        class_letter NVARCHAR(5) NOT NULL,
                        class_teacher_id INT FOREIGN KEY REFERENCES teachers(id),
                        classroom_id INT FOREIGN KEY REFERENCES classrooms(id)
                      );";

        static string insertDataQuery = @"
        INSERT INTO classes (class_number, class_letter, class_teacher_id, classroom_id)
        VALUES 
        (10, 'A', 1, 1),
        (10, 'B', 2, 2),
        (9, 'A', 3, 3),
        (11, 'B', 4, 4);";

        public Classes(SqlConnection connection) : base("classes", query, insertDataQuery, connection)
        {
        }
    }
}
