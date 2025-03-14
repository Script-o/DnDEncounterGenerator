using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDEncounterGenerator.Shared
{
    public class Monster
    {
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public double ChallengeRating { get; set; }
    }
}
