using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Overload_UPG_2 {
    class Program {
        static void Main(string[] args) {
            A a = new A();
            A ab = new B();
            B b = new B();
            Console.WriteLine(a.myMethod(5,5));
            Console.WriteLine(ab.myMethod(5,5));
            Console.WriteLine(b.myMethod(5,5));
            Console.ReadKey();
            
        }
    }

    class A{
        public int myMethod(int numberOne, int numberTwo){
            return numberOne+numberTwo;
        }
    }
    class B:A{
        public float myMethod(float numberOne, float numberTwo){
            return numberOne*numberTwo;
        }
    }
}
