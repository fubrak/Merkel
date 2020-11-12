using System;


namespace Merkel
{
    class Program
    {
        private static readonly int sizeOfTable = 10000000;

        static void Main(string[] args)
        {
            NamesTable myTable1 = new NamesTable();
            NamesTable myTable2 = new NamesTable();

            NamesEntry randomEntry;

            for (int i = 0; i < sizeOfTable; i++)
            {
                randomEntry = GetRandomEntry();

                myTable1.AddNewEntry(randomEntry);
                myTable2.AddNewEntry(randomEntry);
            }

            Console.WriteLine("calculating");
            Console.WriteLine(myTable1.myHashSet.SetEquals(myTable2.myHashSet));

            Console.ReadLine();
        }


        /// <summary>
        /// returns random values for NamesEntry
        /// </summary>
        /// <returns></returns>
        public static NamesEntry GetRandomEntry()
        {
            return new NamesEntry(
                new Random(10000).Next().ToString(),
                new Random(10000).Next().ToString(),
                new Random(10000).Next()
                );
        }
    }
}
