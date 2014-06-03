using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_uppgift {
    class Program {
        static void Main(string[] args) {;
            
        }
    }

    class A {
         class Ab {
            public void publicAb() {
            }
            private void privateAb() {
            }
            protected void protectedAb() {
            }
        }

        public void publicA() {
        }
        private void privateA() {
        }
        protected void protectedA() {
        }
    }

    class B : A {
        public void publicB() {
            
        }
        private void privateB() {
        }
        protected void protectedB() {
        }
    }
}
