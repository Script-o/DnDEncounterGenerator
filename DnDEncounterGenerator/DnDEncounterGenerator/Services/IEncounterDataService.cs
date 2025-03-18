using DnDEncounterGenerator.Shared;
using Microsoft.EntityFrameworkCore.Query;

namespace DnDEncounterGenerator.Services
{
    public interface IEncounterDataService
    {
        Task<IEnumerable<Encounter>> GetAllEncounters();
        //Task<IIncludableQueryable<Encounter, List<Monster>>> GetAllEncounters();

        Task<Encounter> GetEncounterById(Encounter encounter);

        Task<Encounter> AddEncounter(Encounter encounter);

        Task UpdateEncounter(Encounter encounter);

        Task AddMonsterToEncounter(Encounter encounter, Monster monster);

        Task RemoveMonsterFromEncounter(Encounter encounter, Monster monster);

        Task DeleteEncounter(Encounter encounter);
    }
}
