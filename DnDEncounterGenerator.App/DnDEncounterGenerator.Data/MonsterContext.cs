using EncounterGenerator.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;

namespace DnDEncounterGenerator.Data
{
    public class MonsterContext : DbContext
    {
        public DbSet<Monster> Monsters { get; set; }

        public string DbPath { get; }

        public MonsterContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "monsters.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>().ToTable("Monsters");
        }
    }
}
