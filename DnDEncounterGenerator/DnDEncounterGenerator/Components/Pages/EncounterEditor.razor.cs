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

        public string DatabaseRequestMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            ShowEdit = false;
            await ShowEncounters();
            await ShowAllMonsters();
        }

        public Encounter? NewEncounter { get; set; }

        public Encounter? MonsterHolderEncounter { get; set; }

        public async Task ShowCreateForm()
        {
            NewEncounter = new Encounter();
            MonsterHolderEncounter = new Encounter();
            DatabaseRequestMessage = "";
            await ShowAllMonsters();
            ShowCreate = true;
        }

        public async Task ShowFullEditForm(Encounter encounter)
        {
            EncounterToUpdate = encounter;
            MonsterHolderEncounter = new Encounter();
            DatabaseRequestMessage = "";
            await ShowAllMonsters();
            ShowEdit = true;
        }

        public async Task CreateNewEncounter()
        {
            if (NewEncounter is not null)
            {
                var addedEncounter = await EncounterDataService.AddEncounter(NewEncounter);
                
                if (addedEncounter is not null)
                {
                    NewEncounter = addedEncounter;

                    await AddMonstersToEncounter(NewEncounter);

                    EditRecord = false;
                    ShowCreate = false;
                    await ShowEncounters();
                }
                else
                {
                    DatabaseRequestMessage = "Sorry, one of the above fields needs to be corrected";
                }
            }
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
            if (existingEncounter is not null)
            {
                Encounter encounter = await EncounterDataService.GetEncounterById(existingEncounter);

                foreach (var monster in MonsterHolderEncounter.Monsters)
                {
                    await EncounterDataService.AddMonsterToEncounter(existingEncounter, monster);
                }
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
            Encounter encounter = await EncounterDataService.GetEncounterById(EncounterToUpdate);

            if (encounter is not null)
            {
                var addedEncounter = await EncounterDataService.UpdateEncounter(EncounterToUpdate);

                if (addedEncounter is not null)
                {
                    if (MonsterHolderEncounter is not null)
                    {
                        await AddMonstersToEncounter(EncounterToUpdate);
                    }

                    EditRecord = false;
                    ShowEdit = false;
                    await ShowEncounters();
                }
                else
                {
                    DatabaseRequestMessage = "Sorry, one of the above fields needs to be corrected";
                }
            }  
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
