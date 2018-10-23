//http://rosalind.info/problems/orf/
//Sample Dataset
//>Rosalind_99
//AGCCATGTAGCTAACTCAGGTTACATGGGGATGACCCCGCGACTTGGATTAGAGTCTCTTTTGGAATAAGCCTGAATGATCCGAGTAGCATCTCAG
//Sample Output
//MLLGSFRLIPKETLIQVAGSSPCNLS
//M
//MGMTPRLGLESLLE
//MTPRLGLESLLE

using System;
using System.Collections.Generic;
using System.Text;

namespace Rosalind
{
    internal class FASTA
    {
        public Dictionary<string, string> labels;

        public FASTA()
        {
            labels = new Dictionary<string, string>();
        }

        public void Load(string filename)
        {
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
        }

        public string GetAt(int ind)
        {
            int i = 0;
            foreach(string val in labels.Values)
                if (i++ == ind)
                    return val;
            return String.Empty;
        }
    }

    class ORF
    {
        static readonly Dictionary<string, char> codons = new Dictionary<string, char> {
{ "AAA",  'K' },
{ "AAC",  'N' },
{ "AAG",  'K' },
{ "AAT",  'N' },
{ "ACA",  'T' },
{ "ACC",  'T' },
{ "ACG",  'T' },
{ "ACT",  'T' },
{ "AGA",  'R' },
{ "AGC",  'S' },
{ "AGG",  'R' },
{ "AGT",  'S' },
{ "ATA",  'I' },
{ "ATC",  'I' },
{ "ATG",  'M' }, //start
{ "ATT",  'I' },
{ "CAA",  'Q' },
{ "CAC",  'H' },
{ "CAG",  'Q' },
{ "CAT",  'H' },
{ "CCA",  'P' },
{ "CCC",  'P' },
{ "CCG",  'P' },
{ "CCT",  'P' },
{ "CGA",  'R' },
{ "CGC",  'R' },
{ "CGG",  'R' },
{ "CGT",  'R' },
{ "CTA",  'L' },
{ "CTC",  'L' },
{ "CTG",  'L' },
{ "CTT",  'L' },
{ "GAA",  'E' },
{ "GAC",  'D' },
{ "GAG",  'E' },
{ "GAT",  'D' },
{ "GCA",  'A' },
{ "GCC",  'A' },
{ "GCG",  'A' },
{ "GCT",  'A' },
{ "GGA",  'G' },
{ "GGC",  'G' },
{ "GGG",  'G' },
{ "GGT",  'G' },
{ "GTA",  'V' },
{ "GTC",  'V' },
{ "GTG",  'V' },
{ "GTT",  'V' },
{ "TAA",  ' ' }, // Stop
{ "TAC",  'Y' },
{ "TAG",  ' ' }, // Stop
{ "TAT",  'Y' },
{ "TCA",  'S' },
{ "TCC",  'S' },
{ "TCG",  'S' },
{ "TCT",  'S' },
{ "TGA",  ' ' }, // Stop
{ "TGC",  'C' },
{ "TGG",  'W' },
{ "TGT",  'C' },
{ "TTA",  'L' },
{ "TTC",  'F' },
{ "TTG",  'L' },
{ "TTT",  'F' }
            };

        public static string Revc(string input)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
                switch (arr[i])
                {
                    case 'A': arr[i] = 'T'; break;
                    case 'T': arr[i] = 'A'; break;
                    case 'C': arr[i] = 'G'; break;
                    case 'G': arr[i] = 'C'; break;
                }
            return new string(arr);
        }

        public static IEnumerable<string> Orf(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Math.Min(3, input.Length-2); i++)
            {
                sb.Clear();
                bool started = false, stopped = false;
                for (int j = i; j < input.Length-2; j+=3)
                {
                    char ch = codons[input.Substring(j, 3)];
                    if (ch == 'M' && !started)
                        started = true;
                    if (started)
                    {
                        if (ch == ' ')
                        {
                            stopped = true;
                            foreach (var result in Orf(input.Substring(j + 1)))
                                yield return result;
                            break;
                        }
                        sb.Append(ch);
                    }
                }
                if (sb.Length > 0 && started && stopped)
                    for (int k = 0; k < sb.Length; k++)
                        if (sb[k] == 'M')
                            yield return sb.ToString(k, sb.Length - k);
            }
        }

        public static void OrfAll(string input)
        {
            var results = new HashSet<string>();
            foreach (var str in Orf(input))
                results.Add(str);
            input = Revc(input);
            foreach (var str in Orf(input))
                results.Add(str);
            foreach (var str in results)
                System.Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            FASTA fasta = new FASTA();
            fasta.Load("rosalind_orf.txt");
            OrfAll(fasta.GetAt(0));
            System.Console.ReadKey();
        }
    }
}
