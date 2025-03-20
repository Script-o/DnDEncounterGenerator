using DnDEncounterGenerator.Api.Data;
using DnDEncounterGenerator.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
            var encounters = _monsterDataContext.Encounters.Include(e => e.Monsters);

            return encounters;
        }

        public Encounter GetEncounterById(int encounterId)
        {
            return _monsterDataContext.Encounters.Include(e => e.Monsters).FirstOrDefault(c => c.EncounterId == encounterId);
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
                //foundEncounter.Monsters = encounter.Monsters;

                _monsterDataContext.SaveChanges();

                return foundEncounter;
            }

            return null;
        }

        public Encounter AddMonsterToEncounter(Encounter encounter, int id)
        {
            var foundEncounter = _monsterDataContext.Encounters.Include(e => e.Monsters).FirstOrDefault(e => e.EncounterId == encounter.EncounterId);

            if (foundEncounter != null)
            {
                foundEncounter.Monsters.Add(_monsterDataContext.Monsters.FirstOrDefault(e => e.MonsterId == id));

                _monsterDataContext.SaveChanges();

                return foundEncounter;
            }

            return null;
        }

        public Encounter RemoveMonsterFromEncounter(Encounter encounter, int id)
        {
            var foundEncounter = _monsterDataContext.Encounters.Include(e => e.Monsters).FirstOrDefault(e => e.EncounterId == encounter.EncounterId);

            if (foundEncounter != null)
            {
                foundEncounter.Monsters.Remove(_monsterDataContext.Monsters.FirstOrDefault(e => e.MonsterId == id));

                _monsterDataContext.SaveChanges();

                return foundEncounter;
            }

            return null;
        }

        public void DeleteEncounter(int encounterId)
        {
            var foundEncounter = GetEncounterById(encounterId);
            if (foundEncounter == null) return;

            _monsterDataContext.Encounters.Remove(foundEncounter);
            _monsterDataContext.SaveChanges();
        }
    }
}
