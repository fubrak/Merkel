using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
    }
}
