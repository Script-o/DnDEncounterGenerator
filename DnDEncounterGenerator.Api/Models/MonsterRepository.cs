using DnDEncounterGenerator.Api.Data;
using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Api.Models
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly MonsterDataContext _monsterDataContext;

        public MonsterRepository(MonsterDataContext appDbContext)
        {
            _monsterDataContext = appDbContext;
        }

        public IEnumerable<Monster> GetAllMonsters()
        {
            return _monsterDataContext.Monsters;
        }

        public Monster GetMonsterById(int monsterId)
        {
            return _monsterDataContext.Monsters.FirstOrDefault(c => c.MonsterId == monsterId);
        }

        public Monster AddMonster(Monster monster)
        {
            var addedEntity = _monsterDataContext.Monsters.Add(monster);
            _monsterDataContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Monster UpdateMonster(Monster monster)
        {
            var foundMonster = _monsterDataContext.Monsters.FirstOrDefault(e => e.MonsterId == monster.MonsterId);

            if (foundMonster != null)
            {
                foundMonster.MonsterId = monster.MonsterId;
                foundMonster.Name = monster.Name;
                foundMonster.ArmorClass = monster.ArmorClass;
                foundMonster.HitPoints = monster.HitPoints;
                foundMonster.Speed = monster.Speed;
                foundMonster.Strength = monster.Strength;
                foundMonster.Dexterity = monster.Dexterity;
                foundMonster.Constitution = monster.Constitution;
                foundMonster.Intelligence = monster.Intelligence;
                foundMonster.Wisdom = monster.Wisdom;
                foundMonster.Charisma = monster.Charisma;
                foundMonster.ChallengeRating = monster.ChallengeRating;

                _monsterDataContext.SaveChanges();

                return foundMonster;
            }

            return null;
        }

        public void DeleteMonster(int monsterId)
        {
            var foundEmployee = GetMonsterById(monsterId);
            if (foundEmployee == null) return;

            _monsterDataContext.Monsters.Remove(foundEmployee);
            _monsterDataContext.SaveChanges();
        }
    }
}
