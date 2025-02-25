using Microsoft.EntityFrameworkCore;

namespace DnDEncounterGenerator.Data
{
    public class MonsterContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MonsterContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("MonsterDB"));
        }

        public DbSet<Monster> Monsters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>()
                .ToTable("Monsters");

            modelBuilder.Entity<Monster>()
                .HasData(
                    new Monster
                    {
                        MonsterId = 1,
                        Name = "Orc",
                        Health = 10
                    },
                    new Monster
                    {
                        MonsterId = 2,
                        Name = "Goblin",
                        Health = 8
                    },
                    new Monster
                    {
                        MonsterId = 3,
                        Name = "Kobold",
                        Health = 6
                    }
                );
        }
    }
}
