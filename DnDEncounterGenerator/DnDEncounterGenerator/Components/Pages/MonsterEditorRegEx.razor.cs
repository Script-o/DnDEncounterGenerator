using DnDEncounterGenerator.Data;
using System.Text.RegularExpressions;

namespace DnDEncounterGenerator.Components.Pages
{
    public partial class MonsterEditorRegEx
    {
        //protected override async Task OnInitializedAsync()
        //{
            
        //}

        private MonsterContext? _context;

        public Monster? NewMonster { get; set; }

        public string? NewMonsterString { get; set; }

        public string? textToParse { get; set; }

        public void ParsePageForMonster()
        {
            NewMonster = new Monster();

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
                NewMonsterString = "HP: " + NewMonster.HitPoints.ToString();
            }
            else
            {
                NewMonsterString = "No HP Found";
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
                NewMonster.HitPoints = finalInt;
                NewMonsterString += ", AC: " + NewMonster.HitPoints.ToString();
            }
            else
            {
                NewMonsterString += ", No AC Found";
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
                NewMonsterString += ", Speed: " + NewMonster.Speed.ToString() + " ft";
            }
            else
            {
                NewMonsterString += ", No Speed Found";
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
                NewMonsterString += ", STR: " + NewMonster.Strength.ToString();
            }
            else
            {
                NewMonsterString += ", No STR Found";
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
                NewMonsterString += ", DEX: " + NewMonster.Dexterity.ToString();
            }
            else
            {
                NewMonsterString += ", No DEX Found";
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
                NewMonsterString += ", CON: " + NewMonster.Constitution.ToString();
            }
            else
            {
                NewMonsterString += ", No CON Found";
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
                NewMonsterString += ", INT: " + NewMonster.Intelligence.ToString();
            }
            else
            {
                NewMonsterString += ", No INT Found";
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
                NewMonsterString += ", WIS: " + NewMonster.Wisdom.ToString();
            }
            else
            {
                NewMonsterString += ", No WIS Found";
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
                NewMonsterString += ", CHA: " + NewMonster.Charisma.ToString();
            }
            else
            {
                NewMonsterString += ", No CHA Found";
            }

            // Charisma
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
                NewMonsterString += ", Challenge: " + NewMonster.ChallengeRating.ToString();
            }
            else
            {
                NewMonsterString += ", No Challenge Found";
            }
        }

        public async Task CreateNewMonster()
        {
            _context ??= await MonsterContextFactory.CreateDbContextAsync();

            if (NewMonsterString is not null)
            {
                //_context?.Monsters.Add(NewMonster);
                //_context?.SaveChangesAsync();
            }
            //ShowCreate = false;
            //await ShowMonsters();
        }
    }
}
