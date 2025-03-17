using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Api.Models
{
    public interface IEncounterRepository
    {
        IEnumerable<Encounter> GetAllEncounters();

        Encounter GetEncounterById(int encounterId);

        Encounter AddEncounter(Encounter encounter);

        Encounter UpdateEncounter(Encounter encounter);

        void DeleteEncounter(int encounterId);
    }
}
