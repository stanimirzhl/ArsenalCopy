using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStuff.Data;
using UniStuff.Data.Models;

namespace UniStuff.Controllers
{
    public class UniversityController
    {
        /*•	void AddUniversity(string name)
•	List<University> GetAllUniversities()
•	University? GetUniversityByName(string name)
•	int? GetUniversityIdByName(string name)
*/
        UniDbContext context;
        public UniversityController(UniDbContext context) 
        {
            this.context = context;
        }

        public async Task AddUniversity(string name)
        {
            await context.Universities.AddAsync(new University { Name = name });
            await context.SaveChangesAsync();
        }
        public async Task<List<University>> GetAllUniversities()
        {
            return await context.Universities.ToListAsync();
        }
        public async Task<University?> GetUniversityByName(string name)
        {
            return await context.Universities.FirstOrDefaultAsync(u => u.Name == name);
        }
        public async Task<int?> GetUniversityIdByName(string name)
        {
            var university = await context.Universities.FirstOrDefaultAsync(u => u.Name == name);
            return university?.Id;
        }
    }
}
