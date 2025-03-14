using DnDEncounterGenerator.Services;
using DnDEncounterGenerator.Shared;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace DnDEncounterGenerator.Components.Pages
{
    public partial class MonsterEditorRegEx
    {
        [Inject]
        public IMonsterDataService MonsterDataService { get; set; }

        public bool ShowCreate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
        }

        public Monster? NewMonster { get; set; }

        public string? MonsterAddedText { get; set; }

        public string? textToParse { get; set; }

        public void ShowCreateForm()
        {
            NewMonster = new Monster();
            ShowCreate = true;
        }

        public void ParsePageForMonster()
        {
            ShowCreateForm();

            // Hit Points
            string pattern = @"Hit Points\s*\d*";

            Regex rg = new Regex(pattern);

            Match firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            Match secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.HitPoints = finalInt;
            }
            else
            {
                NewMonster.HitPoints = 0;
            }

            // Armor Class
            pattern = @"Armor Class\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.ArmorClass = finalInt;
            }
            else
            {
                NewMonster.ArmorClass = 0;
            }

            // Speed
            pattern = @"Speed\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Speed = finalInt;
            }
            else
            {
                NewMonster.Speed = 0;
            }

            // Stregth
            pattern = @"STR\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Strength = finalInt;
            }
            else
            {
                NewMonster.Strength = 0;
            }

            // Dexterity
            pattern = @"DEX\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Dexterity = finalInt;
            }
            else
            {
                NewMonster.Dexterity = 0;
            }

            // Constitution
            pattern = @"CON\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Constitution = finalInt;
            }
            else
            {
                NewMonster.Constitution = 0;
            }

            // Intelligence
            pattern = @"INT\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Intelligence = finalInt;
            }
            else
            {
                NewMonster.Intelligence = 0;
            }

            // Wisdom
            pattern = @"WIS\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Wisdom = finalInt;
            }
            else
            {
                NewMonster.Wisdom = 0;
            }

            // Charisma
            pattern = @"CHA\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.Charisma = finalInt;
            }
            else
            {
                NewMonster.Charisma = 0;
            }

            // Challenge Rating
            pattern = @"Challenge\s*\d*";

            rg = new Regex(pattern);

            firstMatch = rg.Match(textToParse);

            pattern = @"\d+";

            rg = new Regex(pattern);

            secondMatch = rg.Match(firstMatch.ToString());

            if (firstMatch.Success)
            {
                int finalInt = 0;
                Int32.TryParse(secondMatch.ToString(), out finalInt);
                NewMonster.ChallengeRating = finalInt;
            }
            else
            {
                NewMonster.ChallengeRating = 0;
            }
        }

        public async Task CreateNewMonster()
        {
            if (NewMonster is not null)
            {
                await MonsterDataService.AddMonster(NewMonster);
            }

            textToParse = "";
            MonsterAddedText = $"{NewMonster.Name} has been added to the database.";

            ShowCreate = false;
        }
    }
}
