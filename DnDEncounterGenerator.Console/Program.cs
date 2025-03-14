using DnDEncounterGenerator.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetAllAttributesFromObject();

            var monster = new Monster();

            monster.MonsterId = 1;
            monster.Name = "Gobbo";

            //GetNames(monster);

            //RegExTesting();

            JsonTesting();
        }

        public static void GetAllAttributesFromObject()
        {
            var monster = new Monster();

            monster.MonsterId = 1;
            monster.Name = "Gobbo";

            foreach (PropertyInfo propertyInfo in monster.GetType().GetProperties())
            {
                Console.WriteLine(propertyInfo.Name);
                //Console.WriteLine(propertyInfo.GetValue(monster, null));
            }
        }

        public static IEnumerable<String> GetNames(IEnumerable<Object> objects, string nameProperty = "Name")
        {
            foreach (var instance in objects)
            {
                var type = instance.GetType();
                var property = type.GetProperty(nameProperty);
                yield return property.GetValue(instance, null) as string;
            }
        }

        public static void RegExTesting()
        {
            // Create a pattern for a word that starts with the letter "M"
            string pattern = @"\b[M]\w+";
            // Create a Regex
            Regex rg = new Regex(pattern);

            // Long string
            string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll";
            // Get all matches
            MatchCollection matchedAuthors = rg.Matches(authors);

            Match firstMatch = rg.Match(authors);

            // Print all matched authors
            for (int count = 0; count < matchedAuthors.Count; count++)
                Console.WriteLine(matchedAuthors[count].Value);

            Console.WriteLine($"First Match: {firstMatch}");
        }

        public static void JsonTesting()
        {
            int fieldOne = 10;

            string jsonString = """
                {"Name": "Test",
                "ArmorClass": 10,
                "HitPoints": 9,
                "Speed": 8,
                "Strength": 7,
                "Dexterity": 6,
                "Constitution": 5,
                "Intelligence": 4,
                "Wisdom": 3,
                "Charisma": 2,
                "ChallengeRating": 1}
                """;

            Monster monster = JsonSerializer.Deserialize<Monster>(jsonString);

            Console.WriteLine(monster.Name);
            Console.WriteLine(monster.ArmorClass);
            Console.WriteLine(monster.HitPoints);
            Console.WriteLine(monster.Speed);
            Console.WriteLine(monster.Strength);
            Console.WriteLine(monster.Dexterity);
            Console.WriteLine(monster.Constitution);
            Console.WriteLine(monster.Intelligence);
            Console.WriteLine(monster.Wisdom);
            Console.WriteLine(monster.Charisma);
            Console.WriteLine(monster.ChallengeRating);
        }
    }
}