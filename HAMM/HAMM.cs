//http://rosalind.info/problems/hamm/
//Sample Dataset
//GAGCCTACTAACGGGAT
//CATCGTAATGACGGCCT
//Sample Output
//7
using System;

namespace Rosalind
{
    class HAMM
    {
        static int Hamm(string input1, string input2)
        {
            int result = 0;
            for (int i = 0; i < Math.Min(input1.Length, input2.Length); i++)
                if (input1[i] != input2[i])
                    result++;
            return result;
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine(Hamm("GAGCCTACTAACGGGAT", "CATCGTAATGACGGCCT"));
            System.Console.ReadKey();
        }
    }
}
