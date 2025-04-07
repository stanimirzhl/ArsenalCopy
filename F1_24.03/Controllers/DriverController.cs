using Data.Data;
using Microsoft.EntityFrameworkCore;
using Presentation.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class DriverController
    {
        private readonly F1Context dbContext;

        public DriverController(F1Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<string> GetAllDrivers()
        {
            this.Checker();

            var list = new List<string>();
            foreach (var driver in dbContext.Drivers.Include(x => x.Team))
            {
                list.Add($"Driver First Name: {driver.FirstName}, Driver Last Name: {driver.LastName}, Birth Date: {driver.BirthDate}, Nationality: {driver.Nationality}, Team: {driver.Team.TeamName}");
            }
            return list;

        }
        public Driver GetDriverById(int id)
        {
            this.Checker();

            var driver = dbContext.Drivers.Include(x => x.Team).FirstOrDefault(x => x.DriverId == id);
            if (driver is null)
            {
                throw new ArgumentException("No such entity");
            }

            return driver;
        }
        public Driver GetDriverByLastName(string lastName)
        {
            this.Checker();

            var driver = dbContext.Drivers.Include(x => x.Team).FirstOrDefault(x => x.LastName == lastName);
            if (driver is null)
            {
                throw new ArgumentException("No such entity");
            }

            return driver;
        }
        public List<Driver> GetDriversByNationality(string nationality)
        {
            this.Checker();

            var drivers = dbContext.Drivers.Include(x => x.Team).Where(t => t.Nationality == nationality).ToList();
            if (drivers is null)
            {
                throw new ArgumentException("No such entity");
            }
            return drivers;
        }
        private void Checker()
        {
            if (!dbContext.Drivers.Any())
            {
                throw new ArgumentException("No teams available now!!!!");
            }
        }

    }
}
