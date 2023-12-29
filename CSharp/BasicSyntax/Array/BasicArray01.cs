using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[3];

            score[0] = 1;
            score[1] = 2;
            score[2] = 3;

            Console.WriteLine(score[0]);
            Console.WriteLine(score[1]);
            Console.WriteLine(score[2]);

            char[] ch = new char[3];

            ch[0] = 'A';
            ch[1] = 'B';
            ch[2] = 'C';

            Console.WriteLine(ch[0]);
            Console.WriteLine(ch[1]);
            Console.WriteLine(ch[2]);

        }
    }
}
