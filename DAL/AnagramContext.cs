using AnagramBritAZ.Models;
using System.Data.Entity;

namespace AnagramBritAZ.DAL
{
    public class AnagramContext:DbContext
    {
        public DbSet<Anagram> Anagrams { get; set; }
    }
}