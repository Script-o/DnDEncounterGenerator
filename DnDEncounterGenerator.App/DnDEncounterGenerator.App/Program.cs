using DnDEncounterGenerator.ConsoleApp;
using DnDEncounterGenerator.Data;
using EncounterGenerator.Domain;
using System;

namespace DnDEncounterGenerator.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DbCommands.CreateMonster("Ghost");
            DbCommands.ViewAllMonstersConsole();
            //DbCommands.UpdateMonsterByName("Orc", "New Orc");
            //DbCommands.DeleteMonsterByName("New Orc");
        }
    }
}