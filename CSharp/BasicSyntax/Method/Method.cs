using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodApp01
{
    internal class Program
    {
        static void Method01()
        {
            Console.WriteLine("Method01");
        }
        static int Method02()
        {
            Console.WriteLine("Method02");
            return 100;
        }
        static string Method03()
        {
            Console.WriteLine("Method03");
            return "안녕하세요";
        }
        static int Method04(int n)
        {
            return n;
        }
        static double Method05(int a, int b)
        {
            double result = a + b;
            return result;
        }
        static void Main(string[] args)
        {
            Method01();
            int a = Method02();
            string b = Method03();
            Console.WriteLine(a);
            Console.WriteLine(b);
            int n = Method04(999);
            Console.WriteLine(n);

            double d = Method05(100, 200);
            Console.WriteLine(d);   
        }
    }
}
