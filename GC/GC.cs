using System;
using System.Collections.Generic;
//Sample Dataset
//>Rosalind_6404
//CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTTCCC
//TCCCACTAATAATTCTGAGG
//>Rosalind_5959
//CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGGTCT
//ATATCCATTTGTCAGCAGACACGC
//>Rosalind_0808
//CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGAC
//TGGGAACCTGCGGGCAGTAGGTGGAAT
//Sample Output
//Rosalind_0808
//60.919540
namespace Rosalind
{
    internal struct GCcontent
    {
        public string id;
        public float pc;
        public GCcontent(string id, float pc) { this.id = id; this.pc = pc; }
    }

    internal class FASTA
    {
        public Dictionary<string, string> labels;

        public FASTA()
        {
            labels = new Dictionary<string, string>();
        }
        public static float GetGC(string dna)
        {
            if (dna.Length == 0) return 0F;
            int gcCount = 0;
            foreach(char ch in dna)
                switch (ch)
                {
                    case 'C': case 'G': gcCount++; break;
                }
            return (float)gcCount / dna.Length;
        }
        public GCcontent GetHighestGC(string filename)
        {
            GCcontent result = new GCcontent("{Empty}", 0);
            string[] data = System.IO.File.ReadAllLines(filename);
            string current = String.Empty;
            foreach (string str in data)
            {
                if (str[0] == '>')
                {
                    current = str.Substring(1);
                    labels[current] = String.Empty;
                }
                else if (current.Length > 0)
                    labels[current] += str;
                //else we just ignore the string
            }
            foreach(var dna in labels) //dna is KeyValuePair<string, string>
            {
                float gc = GetGC(dna.Value);
                if (gc > result.pc)
                {
                    result.id = dna.Key;
                    result.pc = gc;
                }
            }
            return result;
        }
    }

    class GC
    {
        static void Main(string[] args)
        {
            FASTA fasta = new FASTA();
            GCcontent highest = fasta.GetHighestGC(@"rosalind_gc_1_dataset.txt");
            System.Console.WriteLine("{0}", highest.id);
            System.Console.WriteLine("{0}", highest.pc);
            System.Console.ReadKey();
        }
    }
}
