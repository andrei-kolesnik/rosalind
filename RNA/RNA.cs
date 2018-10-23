//http://rosalind.info/problems/rna/
//Sample Dataset
//GATGGAACTTGACTACGTAAATT
//Sample Output
//GAUGGAACUUGACUACGUAAAUU
using System;

namespace Rosalind
{
    class RNA
    {
        static string rna(string str)
        {
            return str.Replace("T", "U");
        }
        static void Main(string[] args)
        {
            //string input = "GATGGAACTTGACTACGTAAATT";
            string input = System.IO.File.ReadAllText(@"rosalind_rna.txt");
            Console.WriteLine(rna(input));
            Console.ReadKey();
        }
    }
}
