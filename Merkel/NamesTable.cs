using System;
using System.Collections;
using System.Collections.Generic;

namespace Merkel
{
    class NamesTable
    {
        public ArrayList myTable = new ArrayList();
        public HashSet<NamesEntry> myHashSet = new HashSet<NamesEntry>();

        public void AddNewEntry(NamesEntry entry)
        {
            myTable.Add(entry);
            myHashSet.Add(entry);            
        }

        public bool CompareTablesAndPrintResults(NamesTable tableNumberTwo)
        {
            if (!myHashSet.SetEquals(tableNumberTwo.myHashSet))
            {
                Console.WriteLine("Tables aren't equal");


                // Check for items in table 1 but not in table 2
                foreach (NamesEntry n in myTable)
                {

                    // if .Remove returns false, it means the value is not there
                    if (!tableNumberTwo.myHashSet.Remove(n))
                    {
                        Console.WriteLine("item {0} is not on both tables", n);
                    }

                    tableNumberTwo.myTable.Remove(n);
                }

                // Check for items in table 2 but not in table 1
                foreach (NamesEntry n in tableNumberTwo.myTable)
                {
                    if (!myHashSet.Remove(n))
                    {
                        Console.WriteLine("item {0} is not on both tables", n);
                    }

                    // readding the NameEntry hash
                    myTable.Add(n);
                }
                return false;
            }
           
            Console.WriteLine("Tables are equal");
            return true;
        }
    }
}
