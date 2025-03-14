using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Api.Models
{
    public interface IMonsterRepository
    {
        IEnumerable<Monster> GetAllMonsters();

        Monster GetMonsterById(int monsterId);

        Monster AddMonster(Monster monster);

        void DeleteMonster(int monsterId);

        Monster UpdateMonster(Monster monster);
    }
}
