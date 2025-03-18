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

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowEncounters();
        }

        public Encounter? NewEncounter { get; set; }

        public void ShowCreateForm()
        {
            NewEncounter = new Encounter();
            ShowCreate = true;
        }

        public async Task CreateNewEncounter()
        {
            if (NewEncounter is not null)
            {
                await EncounterDataService.AddEncounter(NewEncounter);
            }
            ShowCreate = false;
            await ShowEncounters();
        }

        public async Task AddMonsterToEncounter()
        {
            //Need to add
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
            EncounterToUpdate = await EncounterDataService.GetEncounterById(ourEncounter);
            EditingId = ourEncounter.EncounterId;
            EditRecord = true;
        }

        public async Task UpdateEncounter()
        {
            EditRecord = false;
            Encounter encounter = await EncounterDataService.GetEncounterById(EncounterToUpdate);

            if (encounter is not null)
            {
                await EncounterDataService.UpdateEncounter(EncounterToUpdate);
            }

            await ShowEncounters();
        }

        public async Task CancelUpdate()
        {
            EditRecord = false;
            await ShowEncounters();
        }

        public Monster? MonsterToUpdate { get; set; }

        public async Task RemoveMonsterFromEncounter(Monster monster)
        {
            var monsterToRemove = await MonsterDataService.GetMonsterById(monster);

            EncounterToUpdate.Monsters.Remove(monsterToRemove);
        }

        public async Task DeleteEncounter(Encounter ourEncounter)
        {
            await EncounterDataService.DeleteEncounter(ourEncounter);

            await ShowEncounters();
        }
    }
}
