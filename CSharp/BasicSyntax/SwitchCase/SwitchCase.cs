using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAppTest01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("숫자를 입력해 주세요 : ");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("1을 입력하였습니다.");
                        break;
                    case 2:
                        Console.WriteLine("2을 입력하였습니다.");
                        break;
                    default:
                        Console.WriteLine("1, 2이외의 수를  입력하였습니다.");
                        break;
                }
                if(n == 100)
                {
                    Console.WriteLine("100을 입력하셔서 종료합니다.");
                    break;
                }
            }
        }
    }
}
