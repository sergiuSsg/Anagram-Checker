namespace AnagramBritAZ.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AnagramBritAZ.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AnagramBritAZ.DAL.AnagramContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AnagramBritAZ.DAL.AnagramContext";
        }

        protected override void Seed(AnagramBritAZ.DAL.AnagramContext context)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            var anagrams = new List<Anagram>
            {
                new Anagram { Name = "anagram3"},
                new Anagram { Name = "anagram4"}
            };

            List<string> wordslist = System.IO.File.ReadLines(@"C:\Users\"user-here"\Desktop\brit.txt").ToList();
            foreach (string word in wordslist)
            {
                anagrams.Add(new Anagram { Name = word });
            }
            
            anagrams.ForEach(c => context.Anagrams.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}
