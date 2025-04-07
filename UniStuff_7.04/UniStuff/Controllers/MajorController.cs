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
    public class MajorController
    {
        /*•	void AddMajor(string name, int facultyId)
•	List<Major> GetMajorsByFacultyId(int facultyId)
•	List<Major> GetMajorsByName(string name)
•	Major? GetMajorByNameAndFacultyId(string name, int facultyId)
*/
        UniDbContext context;
        public MajorController(UniDbContext context)
        {
            this.context = context;
        }

        public async Task AddMajor(string name, int facultyId)
        {
            await context.Majors.AddAsync(new Major { Name = name, FacultyId = facultyId });
            await context.SaveChangesAsync();
        }
        public async Task<List<Major>> GetMajorsByFacultyId(int facultyId)
        {
            return await context.Majors.Where(m => m.FacultyId == facultyId).ToListAsync();
        }
        public async Task<List<Major>> GetMajorsByName(string name)
        {
            return await context.Majors.Where(m => m.Name == name).ToListAsync();
        }
        public async Task<Major?> GetMajorByNameAndFacultyId(string name, int facultyId)
        {
            return await context.Majors.FirstOrDefaultAsync(m => m.Name == name && m.FacultyId == facultyId);
        }
    }
}
