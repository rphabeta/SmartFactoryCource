using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer03App
{
    public class ArrayWrapper
    {
        private int[] arr;
        public ArrayWrapper(int length)
        {
            arr = new int[length];
        }

        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public void Print()
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayWrapper arrayWrapper = new ArrayWrapper(5);

            for (int i = 0; i < 5; i++)
            {
                arrayWrapper[i] = i * 10;
            }
            arrayWrapper.Print();
        }
    }
}
