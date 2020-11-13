using System;
using System.Collections;
using System.Collections.Generic;

namespace Merkel
{
    class NamesTable
    {        
        public HashSet<NamesEntry> myHashSet = new HashSet<NamesEntry>();

        public void AddNewEntry(NamesEntry entry)
        {            
            myHashSet.Add(entry);            
        }

        /// <summary>
        /// This removes value after value from the hash set and check if item removed successfully
        /// </summary>
        /// <param name="tableNumberTwo">a table of entries</param>
        /// <returns></returns>
        public bool CompareTablesAndPrintResults(NamesTable tableNumberTwo)
        {
            // Checks whether sets are equal
            if (myHashSet.SetEquals(tableNumberTwo.myHashSet))
            {
                Console.WriteLine("The tables are equal");
                return true;
            }

            Console.WriteLine("Tables are not equal, these are the values that do not appear in both of them:");

            // This only leaves the "unique" entries in the hash - entries that are not in both hash sets.
            tableNumberTwo.myHashSet.SymmetricExceptWith(this.myHashSet);

            PrintHashSet(tableNumberTwo.myHashSet);

            return false;           
        }

        public void PrintHashSet (HashSet<NamesEntry> set)
        {
            foreach (NamesEntry entry in set)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
