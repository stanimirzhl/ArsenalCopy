using Data.Data;
using Microsoft.EntityFrameworkCore;
using Presentation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class TeamController
    {
        private readonly F1Context dbContext;

        public TeamController(F1Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<string> GetAllTeams()
        {

            this.Checker();
            var list = new List<string>();
            foreach (var team in dbContext.Teams)
            {
                list.Add($"Team Name: {team.TeamName}, Country: {team.Country}, Foundation Year: {team.FoundationYear}");
            }
            return list;
        }

        public Team GetTeamById(int id)
        {

            this.Checker();

            var team = dbContext.Teams.Find(id);
            if (team is null)
            {
                throw new ArgumentException("No such entity");
            }

            return team;

        }

        public List<Team> GetTeamsByCountry(string country)
        {

            this.Checker();
            var team = dbContext.Teams.Where(t => t.Country == country).ToList();
            if (team is null)
            {
                throw new ArgumentException("No such entity");
            }
            return team;
        }

        public string GetOldestTeam()
        {

            this.Checker();
            return dbContext.Teams.OrderByDescending(x => x.FoundationYear).First().TeamName;
        }

        private void Checker()
        {
            if (!dbContext.Teams.Any())
            {
                throw new ArgumentException("No teams available now!!!!");
            }
        }

    }
}
