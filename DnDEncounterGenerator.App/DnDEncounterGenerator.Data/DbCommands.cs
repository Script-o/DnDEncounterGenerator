using DnDEncounterGenerator.Data;
using EncounterGenerator.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDEncounterGenerator.Data
{
    public class DbCommands
    {
        private static MonsterContext _monsterContext = new MonsterContext();

        /// <summary>
        /// MonsterContext object, String name of creature
        /// </summary>
        public async static void CreateMonster(string name)
        {
            _monsterContext.Database.EnsureCreated();

            var monster = new Monster { Name = name, Health = 10 };
            _monsterContext.Monsters.Add(monster);
            await _monsterContext.SaveChangesAsync();
        }

        public async static void ViewAllMonstersConsole()
        {
            var monsters = await _monsterContext.Monsters.ToListAsync();

            foreach (var monster in monsters)
            {
                Console.WriteLine(monster.Name);
            }
        }

        public IEnumerable<Monster> ViewAllMonstersWeb()
        {
            return _monsterContext.Monsters;
        }

        public async static void UpdateMonsterByName(string oldName, string newName)
        {
            var monster = await _monsterContext.Monsters.FirstOrDefaultAsync(m => m.Name == oldName);
            monster.Name = newName;
            await _monsterContext.SaveChangesAsync();
        }

        public async static void DeleteMonsterByName(string name)
        {
            var monster = await _monsterContext.Monsters.FirstOrDefaultAsync(m => m.Name == name);
            _monsterContext.Monsters.Remove(monster);
            await _monsterContext.SaveChangesAsync();
        }
    }
}
