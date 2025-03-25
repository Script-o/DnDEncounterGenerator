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

        public string DatabaseRequestMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowMonsters();
        }

        public Monster? NewMonster { get; set; }

        public void ShowCreateForm()
        {
            NewMonster = new Monster();
            DatabaseRequestMessage = "";
            ShowCreate = true;
        }

        public async Task CreateNewMonster()
        {
            if (NewMonster is not null)
            {
                var addedMonster = await MonsterDataService.AddMonster(NewMonster);

                if (addedMonster is not null)
                {
                    ShowCreate = false;
                    await ShowMonsters();
                }
                else
                {
                    DatabaseRequestMessage = "Sorry, one of the above fields needs to be corrected";
                }
            }
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

        public async Task CancelUpdate()
        {
            EditRecord = false;
            await ShowMonsters();
        }

        public async Task DeleteMonster(Monster ourMonster)
        {
            await MonsterDataService.DeleteMonster(ourMonster);

            await ShowMonsters();
        }
    }
}
