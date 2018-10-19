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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind
{
    internal class GCcontent
    {
        public string data { get; set; }
        public float gc { get; set; }
//        public GCcontent(string data, float pc) { this.data = data; this.gc = gc; }
    }

    internal class FASTA
    {
        public Dictionary<string, GCcontent> labels;

        public FASTA()
        {
            labels = new Dictionary<string, GCcontent>();
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

        public void GetHighestGC(string filename, out string id, out float gc)
        {
            id = "";
            gc = 0F;
            string[] data = System.IO.File.ReadAllLines(filename);
            string current = String.Empty;
            foreach (string str in data)
            {
                if (str[0] == '>')
                {
                    current = str.Substring(1);
                    labels[current] = new GCcontent();
                }
                else if (current.Length > 0)
                    labels[current].data += str;
                //else we just ignore the string
            }
            foreach(var label in labels) //label is KeyValuePair<string, string>
                labels[label.Key].gc = GetGC(label.Value.data);
            //could have calculated MAX in the loop above, but just wanted to illustrate Max with LINQ
            foreach(var label in labels.OrderByDescending(i => i.Value.gc).Take(1))
            {
                id = label.Key;
                gc = label.Value.gc;
                return;
            }
        }
    }

    class GC
    {
        static void Main(string[] args)
        {
            FASTA fasta = new FASTA();
            string id;
            float gc;
            fasta.GetHighestGC(@"rosalind_gc_1_dataset.txt", out id, out gc);
            System.Console.WriteLine("{0}", id);
            System.Console.WriteLine("{0}", gc);
            System.Console.ReadKey();
        }
    }
}
