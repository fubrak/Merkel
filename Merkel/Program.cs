using System;
using System.Linq;

namespace Merkel
{
    public class Program
    {
        private static readonly int sizeOfTable = 10000;
        private static Random random = new Random();

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
            myTable1.AddNewEntry(new NamesEntry("single", "value", 666));

            myTable1.CompareTablesAndPrintResults(myTable2);

            Console.WriteLine("done");
        }


        /// <summary>
        /// returns random values for NamesEntry
        /// </summary>
        /// <returns></returns>
                 
        public static NamesEntry GetRandomEntry()
        {
            return new NamesEntry(
                RandomString(8),
                RandomString(8),
                new Random().Next(1000000000)
                );
        }


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
