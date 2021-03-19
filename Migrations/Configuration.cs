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
            //  This method will be called after migrating to the latest version.
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            var anagrams = new List<Anagram>
            {
                new Anagram { Name = "anagram3"},
                new Anagram { Name = "anagram4"}
            };

            List<string> wordslist = System.IO.File.ReadLines(@"C:\Users\SergiuLydia\Desktop\brit.txt").ToList();

            foreach (string word in wordslist)
            {
                anagrams.Add(new Anagram { Name = word });
            }
            

            anagrams.ForEach(c => context.Anagrams.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();



            //maybe i could try a way to put these strings, each string with a for loop or something, put them in the code like  i would hard code something
            //to put in db
            /*
             * ex for each string to do 
 var categories = new List<Category>
 {
 new Category { Name = "the string here" }
 };
 categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
 context.SaveChanges();

            and i do this for each 70000 times :P
            so basically i would make the model like making the categories , making that list of anagrams in my case and then putting in with thi 
    this categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
             * 
             * 
             * 
             */
            // categories.Add(new Category { Name = line });

        }
    }
}
