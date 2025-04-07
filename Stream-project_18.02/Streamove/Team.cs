using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Streamove
{
    public class Team
    {
        public string Name { get; set; }
        private List<IPlayer> players = new List<IPlayer>();
        private ILog txtLog;
        private ILog xcelLog;
        public Team(string name)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.Name = name;
            this.txtLog = new TXT(@$"{path}\{this.Name}.txt");
            this.xcelLog = new ExcelTXT(@$"{path}\{this.Name}.xlsx");
            txtLog.Save($"{this.Name} отбор беше създаден на {DateTime.Now}");
            xcelLog.Save($"{this.Name} отбор беше създаден на {DateTime.Now}");
        }
        public void PrintLog(string type)
        {
            if (type == "txt")
            {
                this.txtLog.PrintLogger();
                return;
            }

            this.xcelLog.PrintLogger();
        }

        public void Log(string typeOfLog)
        {
            if (typeOfLog != "txt" && typeOfLog != "excel")
            {
                throw new ArgumentException("Неправилен формат за запис!");
            }
            if (typeOfLog == "txt")
            {
                Console.WriteLine("Информацията е записана във файла с разширение txt.");
                this.txtLog.Write();
                return;
            }
            Console.WriteLine("Информацията е записана във файла с разширение xlsx/excel.");
            this.xcelLog.Write();
        }

        public void AddPlayer(IPlayer player)
        {
            var playerToFind = this.players.Find(x => x.Name == player.Name && x.Position == player.Position);
            if (playerToFind is not null)
            {
                Console.WriteLine($"Играчът с име:{player.Name} вече съществува в отбора.");
                return;
            }
            this.players.Add(player);
            txtLog.Save($"{player.Name} е успешно добавен - {DateTime.Now}.");
            xcelLog.Save($"{player.Name} е успешно добавен - {DateTime.Now}.");
            Console.WriteLine($"{player.Name} е успешно добавен.");
        }

        public void RemovePlayer(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                this.players.Remove(player);
                txtLog.Save($"Играч с позиция:{player.Position} и име:{player.Name} беше успешно премахнат - {DateTime.Now}.");
                xcelLog.Save($"Играч с позиция:{player.Position} и име:{player.Name} беше успешно премахнат - {DateTime.Now}.");
                Console.WriteLine($"Играч с името:{name} е успешно премахнат.");
                return;
            }
            Console.WriteLine($"Играч с името:{name} не съществува");
            txtLog.Save($"Играч с името:{name} не съществува");
            xcelLog.Save($"Играч с името:{name} не съществува");
        }
    }
}
