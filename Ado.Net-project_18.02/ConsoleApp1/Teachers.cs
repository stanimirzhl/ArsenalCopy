using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Teachers : BaseChecker
    {
        static string query = @"
                    CREATE TABLE teachers (
                        id INT PRIMARY KEY IDENTITY(1,1),
                        teacher_code NVARCHAR(50) NOT NULL,
                        full_name NVARCHAR(255) NOT NULL,
                        gender CHAR(1) NOT NULL CHECK(gender = 'f' OR gender = 'm'),
                        date_of_birth DATE NOT NULL,
                        email NVARCHAR(255) NOT NULL,
                        phone NVARCHAR(20) NOT NULL,
                        working_days NVARCHAR(255) NOT NULL
                    );";
        static string insertDataQuery = @"
        INSERT INTO teachers (teacher_code, full_name, gender, date_of_birth, email, phone, working_days)
        VALUES 
        ('T001', 'John Doe', 'm', '1980-05-15', 'johndoe@example.com', '123-456-7890', 'Monday, Wednesday, Friday'),
        ('T002', 'Jane Smith', 'f', '1985-08-25', 'janesmith@example.com', '987-654-3210', 'Tuesday, Thursday'),
        ('T003', 'Michael Brown', 'm', '1979-03-12', 'michaelbrown@example.com', '555-123-4567', 'Monday, Thursday'),
        ('T004', 'Emily White', 'f', '1990-07-22', 'emilywhite@example.com', '555-234-5678', 'Wednesday, Friday');";

        public Teachers(SqlConnection connection) : base("teachers", query, insertDataQuery, connection)
        {
        }
    }
}
