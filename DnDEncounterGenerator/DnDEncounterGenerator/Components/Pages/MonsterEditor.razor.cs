using DnDEncounterGenerator.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DnDEncounterGenerator.Components.Pages
{
    public partial class MonsterEditor
    {
        public bool ShowCreate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowMonsters();

            // --- For testing a dynamic way to fill the tables ---
            //await GetAllAttributesFromObject();
        }

        private MonsterContext? _context;

        public Monster? NewMonster { get; set; }

        public void ShowCreateForm()
        {
            NewMonster = new Monster();
            ShowCreate = true;
        }

        public async Task CreateNewMonster()
        {
            _context ??= await MonsterContextFactory.CreateDbContextAsync();

            if (NewMonster is not null)
            {
                _context?.Monsters.Add(NewMonster);
                _context?.SaveChangesAsync();
            }
            ShowCreate = false;
            await ShowMonsters();
        }

        public List<Monster>? OurMonsters { get; set; }

        public async Task ShowMonsters()
        {
            _context ??= await MonsterContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                OurMonsters = await _context.Monsters.ToListAsync();
            }

            // --- 90% sure this is not needed and causes issues ---
            //if (_context is not null) await _context.DisposeAsync();
        }

        public bool EditRecord { get; set; }
        public int EditingId { get; set; }

        public Monster? MonsterToUpdate { get; set; }

        public async Task ShowEditForm(Monster ourMonster)
        {
            _context ??= await MonsterContextFactory.CreateDbContextAsync();
            MonsterToUpdate = _context.Monsters.FirstOrDefault(x => x.MonsterId == ourMonster.MonsterId);
            EditingId = ourMonster.MonsterId;
            EditRecord = true;
        }

        public async Task UpdateMonster()
        {
            EditRecord = false;
            _context ??= await MonsterContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                if (MonsterToUpdate is not null) _context.Monsters.Update(MonsterToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMonster(Monster ourMonster)
        {
            _context ??= await MonsterContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                if (ourMonster is not null) _context.Monsters.Remove(ourMonster);
                await _context.SaveChangesAsync();
            }

            await ShowMonsters();
        }





        // --- Below is an experiment to try and loop all of the attributes of an object ---
        public Monster? MonsterToCheck { get; set; }

        public List<string> ListOfAttributes { get; set; }
        public List<PropertyInfo> ListOfAttributes2 { get; set; }

        public PropertyInfo instance {get; set;}

        public async Task GetAllAttributesFromObject()
        {
            _context ??= await MonsterContextFactory.CreateDbContextAsync();
            MonsterToCheck = _context.Monsters.FirstOrDefault(x => x.MonsterId == 1);



            var monsterJson = JsonSerializer.Serialize(MonsterToCheck);




            var tempList = new List<string>();
            var attributeList = new List<PropertyInfo>();

            foreach (PropertyInfo propertyInfo in MonsterToCheck.GetType().GetProperties())
            {
                tempList.Add(propertyInfo.Name);
                attributeList.Add(propertyInfo);
            }
            ListOfAttributes = tempList;
            ListOfAttributes2 = attributeList;
        }
    }
}
