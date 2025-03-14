using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Services
{
    public interface IMonsterDataService
    {
        Task<IEnumerable<Monster>> GetAllMonsters();
    }
}
