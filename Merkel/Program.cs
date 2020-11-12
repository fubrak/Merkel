using System;


namespace Merkel
{
    class Program
    {
        private static readonly int sizeOfTable = 10000;

        static void Main(string[] args)
        {
            NamesTable myTable1 = new NamesTable();
            NamesTable myTable2 = new NamesTable();

            NamesEntry randomEntry;

            Console.WriteLine("Adding random entries...");

            for (int i = 0; i < sizeOfTable; i++)
            {
                randomEntry = GetRandomEntry();

                myTable1.AddNewEntry(randomEntry);
                myTable2.AddNewEntry(randomEntry);
            }



            // Uncomment the line below to get false results
            // myTable1.AddNewEntry(new NamesEntry("single", "value", 666));

            myTable1.CompareTablesAndPrintResults(myTable2);

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
