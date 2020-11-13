using System;
using System.Collections.Generic;

namespace Merkel
{
    class NamesTable
    {                
        public SortedSet<NamesEntry> mySortedSet = new SortedSet<NamesEntry>(new NamesEntryComparer());

        public void AddNewEntry(NamesEntry entry)
        {            
            mySortedSet.Add(entry);            
        }

        /// <summary>
        /// Checks if two NamesTable are equals, if not, prints the values that do not appear in both of them
        /// </summary>
        /// <param name="tableNumberTwo">a table of entries</param>
        /// <returns></returns>
        public bool CompareTablesAndPrintResults(NamesTable tableNumberTwo)
        {
            // Checks whether sets are equal
            if (mySortedSet.SetEquals(tableNumberTwo.mySortedSet))
            {
                Console.WriteLine("The tables are equal");
                return true;
            }

            Console.WriteLine("Tables are not equal, these are the values that do not appear in both of them:");

            // This only leaves the "unique" entries in the hash - entries that are not in both hash sets.
            tableNumberTwo.mySortedSet.SymmetricExceptWith(this.mySortedSet);

            PrintHashSet(tableNumberTwo.mySortedSet);

            return false;           
        }

        public void PrintHashSet (SortedSet<NamesEntry> set)
        {
            foreach (NamesEntry entry in set)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
