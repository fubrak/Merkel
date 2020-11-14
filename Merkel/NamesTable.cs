using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MerkleTools;

namespace Merkel
{
    class NamesTable
    {                
        public ArrayList tableOfEntries = new ArrayList();
        public MerkleTree tableHashTree = new MerkleTree();

        public void AddNewEntry(NamesEntry entry)
        {            
            tableOfEntries.Add(entry);

            string stringForTree = entry.ToString();
            tableHashTree.AddLeaf(Encoding.ASCII.GetBytes(stringForTree));
        }

        /// <summary>
        /// Checks if two NamesTable are equals, if not, prints the values that do not appear in both of them
        /// </summary>
        /// <param name="tableNumberTwo">a table of entries</param>
        /// <returns>true of false if table is identical</returns>
        public bool CompareTablesAndPrintResults(NamesTable tableNumberTwo)
        {
            // Check if tree root identical
            if (HexEncoder.Encode(tableHashTree.MerkleRootHash) == 
                HexEncoder.Encode(tableNumberTwo.tableHashTree.MerkleRootHash))
            {
                Console.WriteLine("Tables are identical");
                return true;
            }

            // If you're here, the tables aren't identical

            int currIndex = tableOfEntries.Count / 2;
            int lowerLimit = 0;
            int upperLimit = tableOfEntries.Count - 1;
            string direction;
            Proof currProof, myProof;
            ArrayList currProofStr, myProofStr;

            while (true)
            {
                try
                {
                    // If GetProof throws exception, value is not in table
                    currProof = tableNumberTwo.tableHashTree.GetProof(ToBytes(tableOfEntries[currIndex].ToString()));
                }                                                      
                catch 
                {
                    Console.WriteLine("The entry \"" + 
                        tableOfEntries[currIndex].ToString() + 
                        "\" is not in the other table");
                    return false;
                }

                // this is a failsafe, should never be true
                if (currIndex == 0)
                {
                    break;
                }

                // Getting proof for my table
                myProof = tableHashTree.GetProof(ToBytes(tableOfEntries[currIndex].ToString()));

                // Parsing proofs from both tables
                currProofStr = ParseProof(currProof);
                myProofStr = ParseProof(myProof);

                // finding different hashes in the Proof and setting the direction to continue
                for (int i = 0; i < currProofStr.Count; i++)
                {
                    i++;

                    if (!(currProofStr[i].Equals(myProofStr[i])))
                    {
                        direction = myProofStr[i - 1].ToString().Replace(" ", string.Empty);

                        if (direction.Equals("right"))  // Going right
                        {
                            lowerLimit = currIndex;

                            currIndex = ((lowerLimit + upperLimit) / 2);
                            if (((lowerLimit + upperLimit) % 2) == 1)
                            {
                                currIndex++;
                            }
                        }
                        else    // Going left
                        {
                            upperLimit = currIndex;
                            currIndex = (lowerLimit + upperLimit) / 2;
                        }

                        break;
                    }
                }
            }

            return false;           
        }

        /// <summary>
        /// parses a Proof of Merkle table to a list of strings
        /// </summary>
        /// <param name="proof"></param>
        /// <returns>ArrayList with all the strings</returns>
        private static ArrayList ParseProof(Proof proof)
        {
            var temptext = proof.ToJson();

            var charsToRemove = new string[] { "[", "]", ",", "{", "}", ":" };
            foreach (var c in charsToRemove)
            {
                temptext = temptext.Replace(c, string.Empty);
            }
            temptext = temptext.Replace("\"", " ");

            ArrayList tempend = new ArrayList(temptext.Split("  "));
            tempend.RemoveRange(0, 1);

            return tempend;
        }

        /// <summary>
        /// Turns a string to byte[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private byte[] ToBytes (string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }
    }
}
