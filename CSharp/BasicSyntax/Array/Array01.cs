using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArryQuiz02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //배열 선언
            int[] arr = new int[10];
            //배열에 1 ~ 10까지 값을 넣었음
            for(int i=0; i < arr.Length; i++)
                arr[i] = i + 1;
            //1.배열의 요소에서 짝수만출력 if(arr[i] 또는 index % 2 == 0 )
            Console.WriteLine("짝수만 출력");
            for(int i=0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)//값을 이용
                    Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n홀수만 출력");
            //2.배열의 요소에서 홀수만 출력 if(arr[i] 또는 index % 2 == 1)
            for (int i = 0; i < arr.Length; i += 2) //index를 이용
                Console.Write(arr[i]+ " ");

            //3.배열의 요소에서 3의 배수만 출력 if(arr[i] 또는 index %3 이용
            Console.WriteLine("\n3의 배수");
            for(int k=0; k < arr.Length; k++)
            {
                if (arr[k] % 3 == 0)
                    Console.Write(arr[k] + " ");   
            }
        }
    }
}
