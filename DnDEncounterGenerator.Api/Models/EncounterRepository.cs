using DnDEncounterGenerator.Api.Data;
using DnDEncounterGenerator.Shared;

namespace DnDEncounterGenerator.Api.Models
{
    public class EncounterRepository : IEncounterRepository
    {
        private readonly MonsterDataContext _monsterDataContext;

        public EncounterRepository(MonsterDataContext appDbContext)
        {
            _monsterDataContext = appDbContext;
        }

        public IEnumerable<Encounter> GetAllEncounters()
        {
            return _monsterDataContext.Encounters;
        }

        public Encounter GetEncounterById(int encounterId)
        {
            return _monsterDataContext.Encounters.FirstOrDefault(c => c.EncounterId == encounterId);
        }

        public Encounter AddEncounter(Encounter encounter)
        {
            var addedEntity = _monsterDataContext.Encounters.Add(encounter);
            _monsterDataContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Encounter UpdateEncounter(Encounter encounter)
        {
            var foundEncounter = _monsterDataContext.Encounters.FirstOrDefault(e => e.EncounterId == encounter.EncounterId);

            if (foundEncounter != null)
            {
                foundEncounter.EncounterId = encounter.EncounterId;
                foundEncounter.Name = encounter.Name;
                foundEncounter.Description = encounter.Description;
                foundEncounter.Monsters = encounter.Monsters;

                _monsterDataContext.SaveChanges();

                return foundEncounter;
            }

            return null;
        }

        //public Encounter AddMonsterToEncounter(Encounter encounter, Monster monster)
        //{
        //    var encounterToUpdate = _monsterDataContext.Encounters.FirstOrDefault(e => e.EncounterId == encounter.EncounterId);
        //    var monsterToAdd = _monsterDataContext.Monsters.FirstOrDefault(e => e.MonsterId == monster.MonsterId);

        //    if (encounterToUpdate != null)
        //    {
        //        encounterToUpdate.Monsters.Add(monsterToAdd);

        //        _monsterDataContext.SaveChanges();
        //        return encounterToUpdate;
        //    }

        //    return null;
        //}

        public void DeleteEncounter(int encounterId)
        {
            var foundEncounter = GetEncounterById(encounterId);
            if (foundEncounter == null) return;

            _monsterDataContext.Encounters.Remove(foundEncounter);
            _monsterDataContext.SaveChanges();
        }
    }
}
