using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Students : BaseChecker
    {
        static string query = @"
                    CREATE TABLE students (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        student_code NVARCHAR(50) NOT NULL,
                        full_name NVARCHAR(255) NOT NULL,
                        gender CHAR(1) NOT NULL CHECK(gender = 'm' OR gender = 'f'),
                        date_of_birth DATE NOT NULL,
                        email NVARCHAR(255) NOT NULL,
                        phone NVARCHAR(20) NOT NULL,
                        class_id INT FOREIGN KEY REFERENCES classes(id),
                        is_active INT NOT NULL
                    );";
        static string insertDataQuery = @"
        INSERT INTO students (student_code, full_name, gender, date_of_birth, email, phone, class_id, is_active)
        VALUES 
        ('S001', 'Alice Johnson', 'f', '2005-02-14', 'alicejohnson@example.com', '555-111-2222', 1, 1),
        ('S002', 'Bob Brown', 'm', '2004-09-03', 'bobbrown@example.com', '555-333-4444', 2, 0),
        ('S003', 'Charlie Davis', 'm', '2006-11-18', 'charliedavis@example.com', '555-555-6666', 3, 1),
        ('S004', 'Diana Clark', 'f', '2005-01-10', 'dianaclark@example.com', '555-666-7777', 4, 1),
        ('S005', 'Eva White', 'f', '2004-05-22', 'evawhite@example.com', '555-777-8888', 1, 1),
        ('S006', 'Felix Green', 'm', '2005-12-05', 'felixgreen@example.com', '555-888-9999', 2, 0);";

        public Students(SqlConnection connection) : base("students", query, insertDataQuery, connection)
        {
        }
    }
}
