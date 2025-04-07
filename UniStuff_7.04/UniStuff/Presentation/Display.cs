using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStuff.Controllers;

namespace UniStuff.Presentation
{
    public class Display
    {
        private readonly UniversityController universityController;
        private readonly FacultyController facultyController;
        private readonly MajorController majorController;

        public Display(UniversityController universityController, FacultyController facultyController, MajorController majorController)
        {
            this.universityController = universityController;
            this.facultyController = facultyController;
            this.majorController = majorController;
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Add university");
            Console.WriteLine("2. Add faculty");
            Console.WriteLine("3. Add major");
            Console.WriteLine("4. Show all universities");
            Console.WriteLine("5. Show faculties by university ID");
            Console.WriteLine("6. Show majors by faculty ID");
            Console.WriteLine("7. Show university ID by name");
            Console.WriteLine("8. Show faculty ID and name by name");
            Console.WriteLine("9. Show major ID and name by name");
            Console.WriteLine("10. Exit");
        }

        public async Task InputUniversity()
        {
            Console.Write("Enter university name: ");
            string name = Console.ReadLine();
            await universityController.AddUniversity(name);
            Console.WriteLine($"Successfully added {name} university.");
        }

        public async Task InputFaculty()
        {
            Console.Write("Enter faculty name: ");
            string name = Console.ReadLine();
            Console.Write("Enter university ID: ");
            int universityId = int.Parse(Console.ReadLine() ?? "0");
            await facultyController.AddFaculty(name, universityId);
        }

        public async Task InputMajor()
        {
            Console.Write("Enter major name: ");
            string name = Console.ReadLine();
            Console.Write("Enter faculty ID: ");
            int facultyId = int.Parse(Console.ReadLine() ?? "1");
            await majorController.AddMajor(name, facultyId);
        }

        public async Task GetAllUniversities()
        {
            var universities = await universityController.GetAllUniversities();
            if (!universities.Any())
            {
                Console.WriteLine("No results, :(");
                return;
            }
            foreach (var university in universities)
            {
                Console.WriteLine($"ID: {university.Id}, Name: {university.Name}");
            }
        }

        public async Task GetFacultiesByUniversityId()
        {
            Console.Write("Enter university ID: ");
            int universityId = int.Parse(Console.ReadLine() ?? "1");
            var faculties = await facultyController.GetFacultiesByUniversityId(universityId);
            if (!faculties.Any())
            {
                Console.WriteLine("No results, :(");
                return;
            }
            foreach (var faculty in faculties)
            {
                Console.WriteLine($"ID: {faculty.Id}, Name: {faculty.Name}");
            }
        }

        public async Task GetMajorsByFacultyId()
        {
            Console.Write("Enter faculty ID: ");
            int facultyId = int.Parse(Console.ReadLine() ?? "1");
            var majors = await majorController.GetMajorsByFacultyId(facultyId);
            if (!majors.Any())
            {
                Console.WriteLine("No results, :(");
                return;
            }
            foreach (var major in majors)
            {
                Console.WriteLine($"ID: {major.Id}, Name: {major.Name}");
            }
        }

        public async Task GetUniversityIdByName()
        {
            Console.Write("Enter university name: ");
            string name = Console.ReadLine();
            var universityId = await universityController.GetUniversityIdByName(name);
            Console.WriteLine($"University ID: {universityId}");
        }

        public async Task GetFacultyIdAndNameByName()
        {
            Console.Write("Enter faculty name: ");
            string name = Console.ReadLine();
            var faculty = await facultyController.GetFacultiesByName(name);
            if (!faculty.Any())
            {
                Console.WriteLine("No results, :(");
                return;
            }
            foreach (var f in faculty)
            {
                Console.WriteLine($"ID: {f.Id}, Name: {f.Name}");
            }
        }

        public async Task GetMajorIdAndNameByName()
        {
            Console.Write("Enter major name: ");
            string name = Console.ReadLine();
            var major = await majorController.GetMajorsByName(name);
            if (!major.Any())
            {
                Console.WriteLine("No results, :(");
                return;
            }
            foreach (var m in major)
            {
                Console.WriteLine($"ID: {m.Id}, Name: {m.Name}");
            }
        }
    }
}
