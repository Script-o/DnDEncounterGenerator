using DnDEncounterGenerator.Services;
using DnDEncounterGenerator.Shared;
using Microsoft.AspNetCore.Components;

namespace DnDEncounterGenerator.Components.Pages
{
    public partial class EncounterEditor
    {
        [Inject]
        public IEncounterDataService EncounterDataService { get; set; }

        [Inject]
        public IMonsterDataService MonsterDataService { get; set; }

        public bool ShowCreate { get; set; }
        public bool ShowEdit { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            ShowEdit = false;
            await ShowEncounters();
            await ShowAllMonsters();
        }

        public Encounter? NewEncounter { get; set; }

        public Encounter? MonsterHolderEncounter { get; set; }

        public void ShowCreateForm()
        {
            NewEncounter = new Encounter();
            MonsterHolderEncounter = new Encounter();
            ShowCreate = true;
        }

        public void ShowFullEditForm(Encounter encounter)
        {
            EncounterToUpdate = encounter;
            MonsterHolderEncounter = new Encounter();
            ShowEdit = true;
        }

        public async Task CreateNewEncounter()
        {
            if (NewEncounter is not null)
            {
                var updatedEncounter = await EncounterDataService.AddEncounter(NewEncounter);
                NewEncounter = updatedEncounter;
            }

            await AddMonstersToEncounter(NewEncounter);


            await ShowAllMonsters();
            ShowCreate = false;
            await ShowEncounters();
        }

        public async Task AddMonsterToTempEncounter(int monsterId)
        {
            Monster monsterToAdd = await MonsterDataService.GetMonsterById(monsterId);

            MonsterHolderEncounter.Monsters.Add(monsterToAdd);
        }

        public async Task ChangeMonsterButtonText(int monsterId)
        {
            Monster monsterToChangeName = await MonsterDataService.GetMonsterById(monsterId);
            AllMonsters.FirstOrDefault(m => m.MonsterId == monsterToChangeName.MonsterId).Name = "Added";
            StateHasChanged();
        }

        public async Task AddMonstersToEncounter(Encounter existingEncounter)
        {
            Encounter encounter = await EncounterDataService.GetEncounterById(existingEncounter);

            foreach(var monster in MonsterHolderEncounter.Monsters)
            {
                await EncounterDataService.AddMonsterToEncounter(existingEncounter, monster);
            }

            ShowCreate = false;
            await ShowEncounters();
        }

        public List<Encounter>? CurrentEncounters { get; set; }
        
        public async Task ShowEncounters()
        {
            CurrentEncounters = (List<Encounter>)await EncounterDataService.GetAllEncounters();
        }

        public bool EditRecord { get; set; }
        public int EditingId { get; set; }

        public Encounter? EncounterToUpdate { get; set; }

        public async Task ShowEditForm(Encounter ourEncounter)
        {
            MonsterHolderEncounter = new Encounter();

            EncounterToUpdate = await EncounterDataService.GetEncounterById(ourEncounter);
            EditingId = ourEncounter.EncounterId;
            EditRecord = true;
        }

        public List<Monster>? AllMonsters { get; set; }

        public async Task ShowAllMonsters()
        {
            AllMonsters = (List<Monster>)await MonsterDataService.GetAllMonsters();
        }

        public async Task UpdateEncounter()
        {
            EditRecord = false;
            ShowEdit = false;
            Encounter encounter = await EncounterDataService.GetEncounterById(EncounterToUpdate);

            if (encounter is not null)
            {
                await EncounterDataService.UpdateEncounter(EncounterToUpdate);
            }

            if (MonsterHolderEncounter is not null)
            {
                await AddMonstersToEncounter(EncounterToUpdate);
            }

            await ShowEncounters();
        }

        public async Task CancelUpdate()
        {
            EditRecord = false;
            await ShowEncounters();
        }

        public Monster? MonsterToUpdate { get; set; }

        public async Task RemoveMonsterFromEncounter(int monsterId)
        {
            Encounter encounter = await EncounterDataService.GetEncounterById(EncounterToUpdate);

            Monster monsterToRemove = await MonsterDataService.GetMonsterById(monsterId);

            if (encounter is not null && monsterToRemove is not null)
            {
                await EncounterDataService.RemoveMonsterFromEncounter(encounter, monsterToRemove);
            }

            ShowCreate = false;
            await ShowEncounters();
        }

        public async Task DeleteEncounter(Encounter ourEncounter)
        {
            await EncounterDataService.DeleteEncounter(ourEncounter);

            await ShowEncounters();
        }
    }
}
