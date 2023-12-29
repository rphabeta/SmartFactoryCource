using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverse01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string reversed = ""; //string.Empty
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }
            Console.WriteLine(reversed);
        }
    }
}
