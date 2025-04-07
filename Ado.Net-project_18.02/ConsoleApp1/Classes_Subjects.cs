using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Classes_Subjects : BaseChecker
    {
        static string query = @"
                    CREATE TABLE classes_subjects (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        classes_id INT FOREIGN KEY REFERENCES classes(id),
                        subject_id INT FOREIGN KEY REFERENCES subjects(id)
                    );";
        static string insertDataQuery = @"
        INSERT INTO classes_subjects (classes_id, subject_id)
        VALUES 
        (1, 1),
        (1, 2),
        (2, 3),
        (2, 4),
        (3, 6),
        (3, 7),
        (4, 5),
        (4, 8);";

        public Classes_Subjects(SqlConnection connection) : base("classes_subjects", query, insertDataQuery, connection)
        {
        }
    }
}
