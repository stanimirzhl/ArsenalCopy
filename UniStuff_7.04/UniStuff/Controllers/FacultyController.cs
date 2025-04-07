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
    public class FacultyController
    {
        /*•	void AddFaculty(string name, int universityId)
•	List<Faculty> GetFacultiesByUniversityId(int universityId)
•	List<Faculty> GetFacultiesByName(string name)
•	Faculty? GetFacultyByNameAndUniversityId(string name, int universityId)
*/
        UniDbContext context;
        public FacultyController(UniDbContext context)
        {
            this.context = context;
        }

        public async Task AddFaculty(string name, int universityId)
        {
            await context.Faculties.AddAsync(new Faculty { Name = name, UniversityId = universityId });
            await context.SaveChangesAsync();
        }
        public async Task<List<Faculty>> GetFacultiesByUniversityId(int universityId)
        {
            return await context.Faculties.Where(f => f.UniversityId == universityId).ToListAsync();
        }
        public async Task<List<Faculty>> GetFacultiesByName(string name)
        {
            return await context.Faculties.Where(f => f.Name == name).ToListAsync();
        }
        public async Task<Faculty?> GetFacultyByNameAndUniversityId(string name, int universityId)
        {
            return await context.Faculties.FirstOrDefaultAsync(f => f.Name == name && f.UniversityId == universityId);
        }
    }
}
