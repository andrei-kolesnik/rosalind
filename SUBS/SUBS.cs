//http://rosalind.info/problems/subs/
//Sample Dataset
//GATATATGCATATACTT
//ATAT
//Sample Output
//2 4 10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.RegularExpressions;

namespace Rosalind
{
    internal static class SUBS
    {
        public static IEnumerable<int> Subs(this string source, string motif)
        {
            //foreach (Match match in Regex.Matches(source, Regex.Escape(motif))) //does not find overlapping results
            //    yield return match.Index+1; //returns "2 10" instead of "2 4 10"
            int result = 0;
            while (result < source.Length)
            {
                result = source.IndexOf(motif, result) + 1;
                if (result == 0) break;
                yield return result; 
            }
        }
        static void Main(string[] args)
        {
            string dna = "GATATATGCATATACTT", motif = "ATAT";
            foreach (int it in dna.Subs(motif))
                System.Console.Write("{0} ", it);
            System.Console.ReadKey();
        }
    }
}
