using System;
using System.Collections.Generic;
using System.Text;

namespace Merkel
{
    public class NamesEntryComparer : IComparer<NamesEntry>
    {
        public int Compare(NamesEntry first, NamesEntry second)
        {
            return first.Id.CompareTo(second.Id);
        }
    }
}
