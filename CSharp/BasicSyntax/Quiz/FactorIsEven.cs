using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorisEven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 어떤 수의 약수의 개수가 짝수인지 아닌지를 판별하는 데는 그 수가 제곱수인지 
             * 아닌지가 판단해야합니다. 제곱수가 아닌 경우, 약수들은 항상 쌍을 이루므로 약수의 개수는 
             * 짝수입니다. 반대로 제곱수의 경우에는 정확히 제곱근이 한 개만 추가되므로 약수의 개수는
             * 홀수가 됩니다.
             *  A와 B 사이에 있는 제곱수의 개수를 구하고
             *  그것을 B - A + 1에서 빼면 약수의 개수가 짝수인 수의 개수를 얻을 수 있습니다.
            */
            string[] input = Console.ReadLine().Split();
            int A = int.Parse(input[0]);
            int B = int.Parse(input[1]);

            int sqrtA = (int)Math.Ceiling(Math.Sqrt(A)); //숫자를 가장 가까운 정수로 올림
                                                        // [3.0]->3 [3.2]->4 [3.1]->4
            int sqrtB = (int)Math.Floor(Math.Sqrt(B)); //숫자를 내림합니다. ex).3.7 -> 3, 3.2->3

            int oddCount = sqrtB - sqrtA + 1;
            int totalCount = B - A + 1;
            int evenCount = totalCount - oddCount;

            Console.WriteLine(evenCount);

        }
    }
}
