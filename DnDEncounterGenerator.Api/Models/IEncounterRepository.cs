using DnDEncounterGenerator.Shared;
using Microsoft.EntityFrameworkCore.Query;

namespace DnDEncounterGenerator.Api.Models
{
    public interface IEncounterRepository
    {
        IEnumerable<Encounter> GetAllEncounters();
        //IIncludableQueryable<Encounter, List<Monster>> GetAllEncounters();

        Encounter GetEncounterById(int encounterId);

        Encounter AddEncounter(Encounter encounter);

        Encounter UpdateEncounter(Encounter encounter);

        Encounter AddMonsterToEncounter(Encounter encounter, int id);

        Encounter RemoveMonsterFromEncounter(Encounter encounter, int id);

        void DeleteEncounter(int encounterId);
    }
}
