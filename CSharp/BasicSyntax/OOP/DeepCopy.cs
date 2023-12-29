using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp013
{
    //실험클래스
    class MyClass
    {
        public int MyField1;
        public int MyField2;

        //깊은복사
        public MyClass DeepCopy()
        {
            MyClass newCopy = new MyClass();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;

            return newCopy;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass source = new MyClass(); //#100
            source.MyField1 = 10;
            source.MyField2 = 20;

            //객체생성? 일반적으로 new를 통해서
            //MyClass target = source; //얕은복사(Shallow Copy)
            MyClass target = source.DeepCopy(); //깊은복사
            target.MyField2 = 30;

            Console.WriteLine(source.MyField1 + " : " +  source.MyField2);
            Console.WriteLine(target.MyField1 + " : " + target.MyField2);
        }
    }
}
