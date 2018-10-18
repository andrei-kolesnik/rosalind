//http://rosalind.info/problems/dna/
//Sample Dataset
//AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC
//Sample Output
//20 12 17 21
using System;
using System.Collections.Generic;

namespace Rosalind
{
    class DNA
    {
        static string dna(string str)
        {
            var symbols = new SortedDictionary<char, int> ();
            symbols.Add('A', 0);
            symbols.Add('C', 0);
            symbols.Add('G', 0);
            symbols.Add('T', 0);
            foreach (char ch in str)
                symbols[ch]++;
            string output = "";
            foreach (int counter in symbols.Values)
                output = String.Format("{0} {1}", output, counter);
            return output.TrimStart();
        }
        static void Main(string[] args)
        {
            string input = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC";
            Console.WriteLine(dna(input));
            Console.ReadKey();
        }
    }
}
