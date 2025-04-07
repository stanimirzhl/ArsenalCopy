using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStuff.Data.Models;

namespace UniStuff.Data
{
    public class UniDbContext : DbContext
    {
        public UniDbContext()
        {
            
        }
        public UniDbContext(DbContextOptions<UniDbContext> options)
        : base(options)
        {
        }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=UniDb;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
