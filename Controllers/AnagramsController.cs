using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AnagramBritAZ.DAL;
using AnagramBritAZ.Models;

namespace AnagramBritAZ.Controllers
{
    public class AnagramsController : Controller
    {
        private AnagramContext db = new AnagramContext();

        public ActionResult Check()
        {
            return View();
        }

        public ActionResult Find()
        {
            return View();
        }

        public ActionResult CheckAnagram(string word)
        {
            IQueryable<Anagram> wordDictionary = db.Anagrams;
            var finalWordList = new List<string>();
            
            Anagram finallAnagram = new Anagram { };

            string inputWordOrdered = String.Concat(word.OrderBy(a => a));
            string tempString = "";
            string unorderedTempString = "";

            foreach (Anagram w in wordDictionary)
            {
                unorderedTempString = w.Name;
                tempString = String.Concat(w.Name.OrderBy(a => a));

                if(inputWordOrdered == tempString)
                {
                    finalWordList.Add(unorderedTempString);

                }
            }
            
            if (!String.IsNullOrEmpty(word))
            {
                wordDictionary = wordDictionary.Where(a => a.Name.Contains(word));
            }

            return View(finalWordList);
        }

        public ActionResult FindAnagram(string longString, string word)
        {
            var anagramLength = word.Length;
            var amountOfPossibleAnagramLocations = longString.Length - anagramLength + 1;
            var substringIndexes = Enumerable.Range(0, amountOfPossibleAnagramLocations);
            int count = 0;

            foreach(var index in substringIndexes)
            {
                var substring = longString.Substring(index, anagramLength);

                if (IsAnagramOf(substring, word))
                    count++;

            }

            return View(count);
        }

        public static bool IsAnagramOf(string word1, string word2)
        {
            var word1Sorted = String.Concat(word1.OrderBy(c => c));
            var word2Sorted = String.Concat(word2.OrderBy(c => c));

            return word1Sorted == word2Sorted;
        }

    }
}
