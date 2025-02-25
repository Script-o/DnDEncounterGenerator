using DnDEncounterGenerator.Data;
using Microsoft.EntityFrameworkCore;

namespace DnDEncounterGenerator.Components.Pages
{
    public partial class MonsterEditor
    {
        public bool ShowCreate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowMonsters();
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
    }
}
