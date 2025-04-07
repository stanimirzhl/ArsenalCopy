using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Teachers_Subjects : BaseChecker
    {
        static string query = @"
                    CREATE TABLE teachers_subjects (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        teacher_id INT FOREIGN KEY REFERENCES teachers(id),
                        subject_id INT FOREIGN KEY REFERENCES subjects(id)
                    );";
        static string insertDataQuery = @"
        INSERT INTO teachers_subjects (teacher_id, subject_id)
        VALUES 
        (1, 1),
        (1, 3),
        (2, 2),
        (2, 4),
        (3, 6),
        (3, 7),
        (4, 5),
        (4, 8);";

        public Teachers_Subjects(SqlConnection connection) : base("teachers_subjects", query, insertDataQuery, connection)
        {
        }
    }
}
