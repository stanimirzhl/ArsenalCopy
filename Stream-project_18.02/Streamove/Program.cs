using Streamove;
using System.Runtime.InteropServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string command = Console.ReadLine();

List<Team> teams = new List<Team>();

List<IPlayer> players = new List<IPlayer>();

while (command != "exit")
{
    string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    switch (commands[0])
    {
        case "create_team":
            Team team = new Team(commands[1]);
            teams.Add(team);
            break;
        case "create_player":
            IPlayer player = new Player(commands[1], commands[2]);
            players.Add(player);
            break;
        case "add_player":
            var teamToFind = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToFind is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            var playerToFind = players.FirstOrDefault(x => x.Name == commands[2]);
            if (playerToFind is null)
            {
                Console.WriteLine("Несъществуващ играч.");
                break;
            }
            teamToFind.AddPlayer(playerToFind);
            break;
        case "remove_player":
            var teamToFindToRemove = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToFindToRemove is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            teamToFindToRemove.RemovePlayer(commands[2]);
            break;
        case "print_team":
            var teamToFindLog = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToFindLog is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            Console.WriteLine("Избери тип на запис - txt или excel:");
            try
            {
                teamToFindLog.Log(Console.ReadLine());
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case "print_log_txt":
            var teamToLog = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToLog is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            teamToLog.PrintLog(commands[0].Split("_").Last());
            break;
        case "print_log_excel":
            var teamToLogExcel = teams.FirstOrDefault(x => x.Name == commands[1]);
            if (teamToLogExcel is null)
            {
                Console.WriteLine("Несъществуващ отбор.");
                break;
            }
            teamToLogExcel.PrintLog(commands[0].Split("_").Last());
            break;
        default:
            Console.WriteLine("Командата не съществува.");
            break;
    }
    command = Console.ReadLine();
}
