using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Overload {
    class Program {
        static void Main(string[] args) {
        }
    }
    class A{
        public int overLoadMetod(int numberOne, int numberTwo){
            return (numberOne+numberTwo);
        }
        public int overLoadMetod(string numberOne, string numberTwo){
            int tempOne = 0;
            int tempTwo = 0;
            bool isNumberOne = int.TryParse(numberOne, out tempOne);
            bool isNumberTwo = int.TryParse(numberTwo, out tempTwo);
            if(isNumberOne && isNumberTwo)
                return (tempOne+tempTwo);
            return 0;
        }
    }
}
