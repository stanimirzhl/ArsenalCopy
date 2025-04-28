using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoneyQuiz.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Data
{
    public class MoneyQuizDbContext : DbContext
    {
        public MoneyQuizDbContext()
        {
            
        }
        public MoneyQuizDbContext(DbContextOptions<MoneyQuizDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<LifeLine> LifeLines { get; set; }
        public virtual DbSet<Player_Answer> Player_Answers { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Player_Game_Session> Player_Game_Sessions { get; set; }
        public virtual DbSet<Game_Session> Game_Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=MoneyQuizDb;Integrated Security=True");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
