using Controllers;
using Data.Data;
using Presentation.Data.Models;
using System;
using System.Linq;

namespace Presentation
{
    public class Display
    {
        private readonly TeamController teamController;
        private readonly DriverController driverController;

        public Display(F1Context dbContext)
        {
            teamController = new TeamController(dbContext);
            driverController = new DriverController(dbContext);
            this.ShowMenu();
        }
        private void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nSelect a command:");
                Console.WriteLine("1. GetTeams");
                Console.WriteLine("2. GetTeamById <id>");
                Console.WriteLine("3. GetTeamsByCountry <country>");
                Console.WriteLine("4. GetOldestTeam");
                Console.WriteLine("5. GetDrivers");
                Console.WriteLine("6. GetDriverById <id>");
                Console.WriteLine("7. GetDriverByName <lastName>");
                Console.WriteLine("8. GetDriversByNationality <nationality>");
                Console.WriteLine("9. End");
                Console.Write("Enter command: ");

                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "End")
                {
                    Console.WriteLine("Exiting program....");
                    return;
                }

                try
                {
                    switch (commands[0])
                    {
                        case "GetTeams":
                            if (commands.Length > 1)
                            {
                                Console.WriteLine("Too many characters, try again!");
                                break;
                            }
                            var teams = teamController.GetAllTeams();
                            teams.ForEach(Console.WriteLine);
                            break;

                        case "GetTeamById":
                            if (commands.Length < 2 || !int.TryParse(commands[1], out int teamId) || commands.Length > 2)
                            {
                                Console.WriteLine("Invalid ID or too many/not enough characters!!");
                                break;
                            }
                            var team = teamController.GetTeamById(teamId);
                            Console.WriteLine($"Team Name: {team.TeamName}, Country: {team.Country}, Foundation Year: {team.FoundationYear}");
                            break;

                        case "GetTeamsByCountry":
                            if (commands.Length < 2 || commands.Length > 2)
                            {
                                Console.WriteLine("Too many/Not enough characters!!");
                                break;
                            }
                            var teamsByCountry = teamController.GetTeamsByCountry(commands[1]);
                            teamsByCountry.ForEach(t => Console.WriteLine($"Team Name: {t.TeamName}, Country: {t.Country}, Foundation Year: {t.FoundationYear}"));
                            break;

                        case "GetOldestTeam":
                            if (commands.Length > 1)
                            {
                                Console.WriteLine("Too many characters!!");
                                break;
                            }
                            var oldestTeam = teamController.GetOldestTeam();
                            Console.WriteLine($"Oldest team: {oldestTeam}");
                            break;

                        case "GetDrivers":
                            if (commands.Length > 1)
                            {
                                Console.WriteLine("Too many characters!!");
                                break;
                            }
                            var drivers = driverController.GetAllDrivers();
                            drivers.ForEach(Console.WriteLine);
                            break;

                        case "GetDriverById":
                            if (commands.Length < 2 || !int.TryParse(commands[1], out int driverId) || commands.Length > 2)
                            {
                                Console.WriteLine("Invalid ID or too many/not enough characters!!");
                                break;
                            }
                            var driver = driverController.GetDriverById(driverId);
                            Console.WriteLine($"Driver: {driver.FirstName} {driver.LastName}, Birth Date: {driver.BirthDate}, Nationality: {driver.Nationality}, Team: {driver.Team.TeamName}");
                            break;

                        case "GetDriverByName":
                            if (commands.Length < 2 || commands.Length > 2)
                            {
                                Console.WriteLine("Too many/not enough characters!!");
                                break;
                            }
                            var driverByName = driverController.GetDriverByLastName(commands[1]);
                            Console.WriteLine($"Driver: {driverByName.FirstName} {driverByName.LastName}, Birth Date: {driverByName.BirthDate}, Nationality: {driverByName.Nationality}, Team: {driverByName.Team.TeamName}");
                            break;

                        case "GetDriversByNationality":
                            if (commands.Length < 2 || commands.Length > 2)
                            {
                                Console.WriteLine("Too many/not enough characters!!");
                                break;
                            }
                            var driversByNationality = driverController.GetDriversByNationality(commands[1]);
                            driversByNationality.ForEach(d => Console.WriteLine($"Driver: {d.FirstName} {d.LastName}, Birth Date: {d.BirthDate}, Nationality: {d.Nationality}, Team: {d.Team.TeamName}"));
                            break;

                        default:
                            Console.WriteLine("Invalid command :(, you need to try again, please this time choose from the provided list!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
