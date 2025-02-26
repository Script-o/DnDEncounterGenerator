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
                        ArmorClass = 10,
                        HitPoints = 10,
                        Speed = 20,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charisma = 10,
                        ChallengeRating = .25
                    },
                    new Monster
                    {
                        MonsterId = 2,
                        Name = "Goblin",
                        ArmorClass = 10,
                        HitPoints = 10,
                        Speed = 20,
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
                        HitPoints = 10,
                        Speed = 20,
                        Strength = 10,
                        Dexterity = 10,
                        Constitution = 10,
                        Intelligence = 10,
                        Wisdom = 10,
                        Charisma = 10,
                        ChallengeRating = 2
                    }
                );
        }
    }
}
