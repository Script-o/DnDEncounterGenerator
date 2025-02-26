using DnDEncounterGenerator.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
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

            GetNames(monster);
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
    }
}