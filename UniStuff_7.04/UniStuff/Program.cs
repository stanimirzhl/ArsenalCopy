using UniStuff.Controllers;
using UniStuff.Data;
using UniStuff.Presentation;

var context = new UniDbContext();
var universityController = new UniversityController(context);
var facultyController = new FacultyController(context);
var majorController = new MajorController(context);
var display = new Display(universityController, facultyController, majorController);

while (true)
{
    display.ShowMenu();
    Console.Write("Choose an option: ");
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            await display.InputUniversity();
            break;
        case "2":
            await display.InputFaculty();
            break;
        case "3":
            await display.InputMajor();
            break;
        case "4":
            await display.GetAllUniversities();
            break;
        case "5":
            await display.GetFacultiesByUniversityId();
            break;
        case "6":
            await display.GetMajorsByFacultyId();
            break;
        case "7":
            await display.GetUniversityIdByName();
            break;
        case "8":
            await display.GetFacultyIdAndNameByName();
            break;
        case "9":
            await display.GetMajorIdAndNameByName();
            break;
        case "10":
            Console.WriteLine("Exiting program...");
            return;
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
    Console.WriteLine(new string('-', 25));
}