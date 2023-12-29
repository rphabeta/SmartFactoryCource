using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp004
{
    class Calculator
    {
        /* 오버로딩(overloading) */
        //1. 정수 두개를 합산하는 Plus 메소드
        public int Plus(int x, int y)
        {
            return x + y;
        }
        //2. 정수 네개를 합산하는 Plus 메소드
        public int Plus(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }
        //3. double 두개를 합산하는 Plus 메소드
        public double Plus(double x, double y)
        {
            return x + y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            
        }
    }
}
