using DnDEncounterGenerator.Services;
using DnDEncounterGenerator.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DnDEncounterGenerator.Components.Pages
{
    public partial class MonsterEditor
    {
        [Inject]
        public IMonsterDataService MonsterDataService { get; set; }

        public bool ShowCreate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowMonsters();

            // --- For testing a dynamic way to fill the tables ---
            //await GetAllAttributesFromObject();
        }

        public Monster? NewMonster { get; set; }

        public void ShowCreateForm()
        {
            NewMonster = new Monster();
            ShowCreate = true;
        }

        public async Task CreateNewMonster()
        {
            if (NewMonster is not null)
            {
                await MonsterDataService.AddMonster(NewMonster);
            }
            ShowCreate = false;
            await ShowMonsters();
        }

        public List<Monster>? OurMonsters { get; set; }

        public async Task ShowMonsters()
        {
            OurMonsters = (List<Monster>)await MonsterDataService.GetAllMonsters();
        }

        public bool EditRecord { get; set; }
        public int EditingId { get; set; }

        public Monster? MonsterToUpdate { get; set; }

        public async Task ShowEditForm(Monster ourMonster)
        {
            MonsterToUpdate = await MonsterDataService.GetMonsterById(ourMonster);
            EditingId = ourMonster.MonsterId;
            EditRecord = true;
        }

        public async Task UpdateMonster()
        {
            EditRecord = false;
            Monster monster = await MonsterDataService.GetMonsterById(MonsterToUpdate);

            if (monster is not null)
            {
                await MonsterDataService.UpdateMonster(MonsterToUpdate);
            }

            await ShowMonsters();
        }

        public async Task DeleteMonster(Monster ourMonster)
        {
            await MonsterDataService.DeleteMonster(ourMonster);

            await ShowMonsters();
        }





        // --- Below is an experiment to try and loop all of the attributes of an object ---
        public Monster? MonsterToCheck { get; set; }

        public List<string> ListOfAttributes { get; set; }
        public List<PropertyInfo> ListOfAttributes2 { get; set; }

        public PropertyInfo instance {get; set;}

        public async Task GetAllAttributesFromObject()
        {
            //_context ??= await MonsterContextFactory.CreateDbContextAsync();
            //MonsterToCheck = _context.Monsters.FirstOrDefault(x => x.MonsterId == 1);



            //var monsterJson = JsonSerializer.Serialize(MonsterToCheck);




            //var tempList = new List<string>();
            //var attributeList = new List<PropertyInfo>();

            //foreach (PropertyInfo propertyInfo in MonsterToCheck.GetType().GetProperties())
            //{
            //    tempList.Add(propertyInfo.Name);
            //    attributeList.Add(propertyInfo);
            //}
            //ListOfAttributes = tempList;
            //ListOfAttributes2 = attributeList;
        }
    }
}
