using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Services
{
    public interface IMonsterDataService
    {
        Task<IEnumerable<Monster>> GetAllMonsters();

        Task<Monster> GetMonsterById(Monster monster);
        Task<Monster> GetMonsterById(int monsterId);

        Task<Monster> AddMonster(Monster monster);

        Task<Monster> UpdateMonster(Monster monster);

        Task DeleteMonster(Monster monster);
    }
}
