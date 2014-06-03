using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5 {
    class Program {
        static void Main(string[] args) {
            
            
        }
    }
    public class A {
        public A() {
        }
        public void publicA() {
            Console.WriteLine("Public för A");
        }
        private void privateA() {
            Console.WriteLine("Private för A");
        }

        protected void protectedA() {
            Console.WriteLine("Protected för A");
        }
    }
    public class B : A {
        public B() {


        }
        public void publicB() {
            Console.WriteLine("Public för B");
        }
        private void privateB() {
            Console.WriteLine("Private för B");
        }
        protected void protectedB() {
            Console.WriteLine("Protected för B");
            
        }
    }
    public class C : B {
        public C() {

        }
        public void publicC() {
            Console.WriteLine("Public för C");
        }
        private void privateC() {
            Console.WriteLine("Private för C");
        }
        protected void protectedC() {
            Console.WriteLine("Protected för C");
        }
    }
}
