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
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("EncounterDB"));
        }

        public DbSet<Monster> Monsters { get; set; }

        public DbSet<Encounter> Encounters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>()
                .HasMany(e => e.Encounters)
                .WithMany(e => e.Monsters);

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
                        ChallengeRating = 1,
                        Encounters = { }
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
                        ChallengeRating = 1,
                        Encounters = { }
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
                        ChallengeRating = 1,
                        Encounters = { }
                    }
                );

            modelBuilder.Entity<Encounter>()
                .HasMany(e => e.Monsters)
                .WithMany(e => e.Encounters);

            modelBuilder.Entity<Encounter>()
                .ToTable("Encounter");

            modelBuilder.Entity<Encounter>()
                .HasData(
                    new Encounter
                    {
                        EncounterId = 1,
                        Name = "There Be Goblins",
                        Description = "This is an encounter with some goblins.",
                        Monsters = { }
                    },
                    new Encounter
                    {
                        EncounterId = 2,
                        Name = "Big Ol Orcs",
                        Description = "This is an encounter with some orcs.",
                        Monsters = { }
                    },
                    new Encounter
                    {
                        EncounterId = 3,
                        Name = "Fearsom Kobolds",
                        Description = "This is an encounter with some kobolds.",
                        Monsters = { }
                    }
                );
        }
    }
}
