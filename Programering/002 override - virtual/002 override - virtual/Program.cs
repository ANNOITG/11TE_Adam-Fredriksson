using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_override___virtual {
    class Program {
        static void Main(string[] args) {
            A ab = new B();
            ab.overRide();
            Console.ReadKey();
            
        }
    }
    public class A {

        public virtual void overRide(){
            Console.WriteLine("Virtual for A");
        }
    }
    public class B : A {
        public override void overRide() {
             Console.WriteLine("Override for B");
        }
    }
    public class C : B {
        public override void overRide() {
             Console.WriteLine("Override for C");
        }
    }
}

