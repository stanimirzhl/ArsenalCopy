using DatabaseInvoker;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class Program
{
    static string connectionString = @"Server=(localdb)\ProjectModels;Database=school;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;";
    public static void Main()
    {
        Database.CreateDb();
        Console.WriteLine("Hello welcome to the school database system, below you will be given a list of commands you can perform plus a couple of bonus ones:");
        DisplayInformation();

    }
    private static void DisplayInformation()
    {
        do
        {
            Console.WriteLine("\nInformation to print:");
            Console.WriteLine("1. Name of all students in 11B:");
            Console.WriteLine("2. Name of all teachers and their subject, grouped by the subject:");
            Console.WriteLine("3. All classes and their lead teacher:");
            Console.WriteLine("4. Subjects and the count of teachers teach that subject:");
            Console.WriteLine("5. ID and capacity of the main classes with no more capacity of 26 students:");
            Console.WriteLine("6. Name and class of all students, grouped by class:");
            Console.WriteLine("7. Name of all students in specific class:");
            Console.WriteLine("8. Name of students, born on specific date:");
            Console.WriteLine("9. Count of all subjects that one student learns:");
            Console.WriteLine("10. Name of teachers and subjects, that those teachers teach, by given student:");
            Console.WriteLine("11. Classes that children of specific parents learn:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayStudentsFromClass("11", "B");
                    break;
                case "2":
                    DisplayTeachersAndSubjects();
                    break;
                case "3":
                    DisplayClassesAndTeachers();
                    break;
                case "4":
                    DisplaySubjectsAndTeacherCount();
                    break;
                case "5":
                    DisplayClassroomsWithCapacity();
                    break;
                case "6":
                    DisplayStudentsGroupedByClass();
                    break;
                case "7":
                    DisplayStudentsFromSelectedClass();
                    break;
                case "8":
                    DisplayStudentsBornOnDate();
                    break;
                case "9":
                    DisplaySubjectCountForStudent();
                    break;
                case "10":
                    DisplayTeachersAndSubjectsForStudent();
                    break;
                case "11":
                    DisplayClassesForParent();
                    break;
                default:
                    Console.WriteLine("Invalid case, please try again with one of the above-mentioned.");
                    break;
            }
            Console.WriteLine("Do you wish to stop - Y/N?");
            string result = Console.ReadLine().ToUpper();
            if(result == "Y")
            {
                Console.WriteLine("Bye!");
                break;
            }
        }
        while (true);
    }

    private static void DisplayClassesForParent()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select concat(c.class_number, '', c.class_letter) from parents as p join students_parents as sp on p.id = sp.parent_id join students as s on sp.student_id = s.id join classes as c on s.class_id = c.id where p.email = @email";
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Write the parent's email, whose student you want to see the class he studies in, in format: example@mail.com");
            string email = Console.ReadLine();
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            while (!regex.IsMatch(email))
            {
                Console.WriteLine("Invalid format, example@example.com");
                email = Console.ReadLine();
            }

            command.Parameters.AddWithValue("@email", email);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 11:");
                if (!reader.HasRows)
                {
                    Console.WriteLine("No found matches");
                    return;
                }
                while (reader.Read())
                {
                    Console.WriteLine($"Class: {reader[0]}");
                }
            }
        }
    }

    private static void DisplayTeachersAndSubjectsForStudent()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT t.full_name AS teacher_name, s.title AS subject_name\r\nFROM students AS stu\r\nJOIN classes_subjects AS cs ON stu.class_id = cs.classes_id\r\nJOIN subjects AS s ON cs.subject_id = s.id\r\nJOIN teachers_subjects as ts on s.id = ts.subject_id\r\njoin teachers as t on ts.teacher_id = t.id\r\nWHERE stu.full_name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Write the student's name you want to see the count of subjects it learns in format: firstName lastName");
            string name = Console.ReadLine();
            command.Parameters.AddWithValue("@name", name);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 10:");
                while (reader.Read())
                {
                    Console.WriteLine($"Teacher: {reader[0]}, subject: {reader[1]}");
                }
            }
        }
    }

    private static void DisplaySubjectCountForStudent()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select count(cs.id) as count_of_subjects_student_learns from students as s join classes_subjects as cs on s.class_id = cs.classes_id where s.full_name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Write the student's name you want to see the count of subjects it learns in format: firstName lastName");
            string name = Console.ReadLine();
            command.Parameters.AddWithValue("@name", name);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 9:");
                while (reader.Read())
                {
                    Console.WriteLine($"Count of subjects: {reader[0]}");
                }
            }
        }
    }

    private static void DisplayStudentsBornOnDate()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select full_name from students where date_of_birth = @date";
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Enter a date in the format: yyyy-mm-dd");
            string date = Console.ReadLine();

            DateTime parsedDate;
            bool success = DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            while (success != true)
            {
                Console.WriteLine("Invalid format for date: yyyy-mm-dd");
                date = Console.ReadLine();
                success = DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            }


            command.Parameters.AddWithValue("@date", parsedDate.ToString("yyyy-MM-dd"));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<string> students = new List<string>();
                Console.WriteLine("Result for query 8:");
                while (reader.Read())
                {
                    students.Add((string)reader[0]);
                }
                if (!students.Any())
                {
                    Console.WriteLine($"No students in the given date: {parsedDate.ToString("yyyy-MM-dd")}");
                    return;
                }

                Console.WriteLine($"Students with birth date: {parsedDate.ToString("yyyy-MM-dd")} - students: {string.Join(", ", students)}");
            }
        }
    }

    private static void DisplayStudentsFromSelectedClass()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select s.full_name from students as s join classes as c on s.class_id = c.id where c.class_letter = @classLetter and c.class_number = @classNumber";
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Choose the class letter: a or b:");
            string classLetter = Console.ReadLine().ToUpper();
            Console.WriteLine("Choose the class number: ");
            int classNumber = int.Parse(Console.ReadLine());
            command.Parameters.AddWithValue("@classLetter", classLetter);
            command.Parameters.AddWithValue("@classNumber", classNumber);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<string> students = new List<string>();
                Console.WriteLine("Result for query 7:");
                while (reader.Read())
                {
                    students.Add((string)reader[0]);
                }
                Console.WriteLine($"Class: {classNumber.ToString() + classLetter} - students: {string.Join(", ", students)}");
            }
        }
    }

    private static void DisplayStudentsGroupedByClass()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select full_name, concat(c.class_number, '', c.class_letter) as class from students as s join classes as c on s.class_id = c.id order by c.class_number";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                Console.WriteLine("Result for query 2:");
                while (reader.Read())
                {
                    if (!dict.ContainsKey((string)reader[1]))
                    {
                        dict[(string)reader[1]] = new List<string>() { (string)reader[0] };
                    }
                    else
                    {
                        dict[(string)reader[1]].Add((string)reader[0]);
                    }
                }
                foreach (var value in dict)
                {
                    Console.WriteLine($"Teacher: {value.Key} - subjects: {string.Join(", ", value.Value)}");
                }
            }
        }
    }

    private static void DisplayClassroomsWithCapacity()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select id, capacity from classrooms where capacity <= 25 order by [floor]";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 5:");
                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader[0]} - capacity: {reader[1]}");
                }
            }
        }
    }

    private static void DisplaySubjectsAndTeacherCount()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT s.title AS subject_name, \r\nCOUNT(t.id) AS teacher_count\r\nFROM subjects AS s\r\nJOIN teachers_subjects AS ts ON ts.subject_id = s.id\r\nJOIN teachers AS t ON t.id = ts.teacher_id\r\nGROUP BY s.title";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 4:");
                while (reader.Read())
                {
                    Console.WriteLine($"Subject: {reader[0]} - count of teachers for it: {reader[1]}");
                }
            }
        }
    }

    private static void DisplayClassesAndTeachers()
    {

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select concat(c.class_number, '', c.class_letter) as class, t.full_name as teacher_full_name from classes as c join teachers as t on c.class_teacher_id = t.id \r\nwhere c.class_letter = @classLetter and c.class_number = @classNumber";
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Choose the class letter: a or b:");
            string classLetter = Console.ReadLine().ToUpper();
            Console.WriteLine("Choose the class number: ");
            int classNumber = int.Parse(Console.ReadLine());
            command.Parameters.AddWithValue("@classLetter", classLetter);
            command.Parameters.AddWithValue("@classNumber", classNumber);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 3:");
                while (reader.Read())
                {
                    Console.WriteLine($"Class: {reader[0]} and lead teacher: {reader[1]}");
                }
            }
        }
    }

    private static void DisplayTeachersAndSubjects()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT s.title AS subject_name, t.full_name AS teacher_full_name\r\nFROM teachers AS t\r\nJOIN teachers_subjects AS ts ON ts.teacher_id = t.id\r\nJOIN subjects AS s ON s.id = ts.subject_id\r\nORDER BY s.title, t.full_name;\r\n";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                Console.WriteLine("Result for query 2:");
                while (reader.Read())
                {
                    if (!dict.ContainsKey((string)reader[1]))
                    {
                        dict[(string)reader[1]] = new List<string>() { (string)reader[0] };
                    }
                    else
                    {
                        dict[(string)reader[1]].Add((string)reader[0]);
                    }
                }
                foreach (var value in dict)
                {
                    Console.WriteLine($"Teacher: {value.Key} - subjects: {string.Join(", ", value.Value)}");
                }
            }
        }
    }

    private static void DisplayStudentsFromClass(string classNumber, string classLetter)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "select full_name from students as s join classes as c on s.class_id = c.id where c.class_letter = 'B' and c.class_number = '11'";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Console.WriteLine("Result for query 1:");
                while (reader.Read())
                {
                    Console.WriteLine($"Student: {reader[0]}");
                }
            }
        }
    }
}