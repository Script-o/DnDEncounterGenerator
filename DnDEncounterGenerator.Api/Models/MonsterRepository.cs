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
            return null;
        }

        public Monster AddMonster(Monster monster)
        {
            return null;
        }

        public void DeleteMonster(int monsterId)
        {
            
        }

        public Monster UpdateMonster(Monster monster)
        {
            return null;
        }
    }
}
