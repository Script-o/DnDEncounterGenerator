using Microsoft.EntityFrameworkCore;
using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Api.Data
{
    public class MonsterDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MonsterDataContext(IConfiguration configuration)
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
                .ToTable("Monster");

            modelBuilder.Entity<Monster>()
                .HasData(
                    new Monster
                    {
                        MonsterId = 1,
                        Name = "Goblin",
                        ArmorClass = 10,
                        HitPoints = 20,
                        Speed = 30,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charisma = 10,
                        ChallengeRating = 1
                    },
                    new Monster
                    {
                        MonsterId = 2,
                        Name = "Orc",
                        ArmorClass = 10,
                        HitPoints = 20,
                        Speed = 30,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charisma = 10,
                        ChallengeRating = 1
                    },
                    new Monster
                    {
                        MonsterId = 3,
                        Name = "Kobold",
                        ArmorClass = 10,
                        HitPoints = 20,
                        Speed = 30,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charisma = 10,
                        ChallengeRating = 1
                    }
                );
        }
    }
}
