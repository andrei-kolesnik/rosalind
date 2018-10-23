//http://rosalind.info/problems/prot/
//Sample Dataset
//AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA
//Sample Output
//MAMAPRTEINSTRING
using System;
using System.Collections.Generic;
using System.Text;

namespace Rosalind
{
    class PROT
    {
        public static string Prot(string input)
        {
            Dictionary<string, char> codons = new Dictionary<string, char> {
{ "AAA", 'K' },
{ "AAC", 'N' },
{ "AAG", 'K' },
{ "AAU", 'N' },
{ "ACA", 'T' },
{ "ACC", 'T' },
{ "ACG", 'T' },
{ "ACU", 'T' },
{ "AGA", 'R' },
{ "AGC", 'S' },
{ "AGG", 'R' },
{ "AGU", 'S' },
{ "AUA", 'I' },
{ "AUC", 'I' },
{ "AUG", 'M' },
{ "AUU", 'I' },
{ "CAA", 'Q' },
{ "CAC", 'H' },
{ "CAG", 'Q' },
{ "CAU", 'H' },
{ "CCA", 'P' },
{ "CCC", 'P' },
{ "CCG", 'P' },
{ "CCU", 'P' },
{ "CGA", 'R' },
{ "CGC", 'R' },
{ "CGG", 'R' },
{ "CGU", 'R' },
{ "CUA", 'L' },
{ "CUC", 'L' },
{ "CUG", 'L' },
{ "CUU", 'L' },
{ "GAA", 'E' },
{ "GAC", 'D' },
{ "GAG", 'E' },
{ "GAU", 'D' },
{ "GCA", 'A' },
{ "GCC", 'A' },
{ "GCG", 'A' },
{ "GCU", 'A' },
{ "GGA", 'G' },
{ "GGC", 'G' },
{ "GGG", 'G' },
{ "GGU", 'G' },
{ "GUA", 'V' },
{ "GUC", 'V' },
{ "GUG", 'V' },
{ "GUU", 'V' },
{ "UAA", ' ' }, //Stop   
{ "UAC", 'Y' },
{ "UAG", ' ' }, //Stop   
{ "UAU", 'Y' },
{ "UCA", 'S' },
{ "UCC", 'S' },
{ "UCG", 'S' },
{ "UCU", 'S' },
{ "UGA", ' ' }, //Stop   
{ "UGC", 'C' },
{ "UGG", 'W' },
{ "UGU", 'C' },
{ "UUA", 'L' },
{ "UUC", 'F' },
{ "UUG", 'L' },
{ "UUU", 'F' }
			};
            StringBuilder sb = new StringBuilder(input.Length/3);
            for (int ind = 0; ind < input.Length; ind += 3)
            {
                char ch = codons[input.Substring(ind, 3)];
                if (ch == ' ') break;
                sb.Append(ch);
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine(Prot("AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA"));
            System.Console.ReadKey();
        }
    }
}
