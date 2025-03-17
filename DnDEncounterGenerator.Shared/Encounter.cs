using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDEncounterGenerator.Shared
{
    public class Encounter
    {
        public int EncounterId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Monster> Monsters { get; set; } = new List<Monster>();
    }
}
