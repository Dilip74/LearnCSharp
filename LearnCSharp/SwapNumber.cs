using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    class SwapNumber
    {
        public void SwapWithoutTemp(int var1, int var2)
        {
            int a = var1, b = var2;
            Console.WriteLine("Before swap a= " + a + " b= " + b);
            a = a * b; //a=20 (4*5)      
            b = a / b; //b=4 (20/5)      
            a = a / b; //a=5 (20/4)    
            Console.Write("After swap a= " + a + " b= " + b);
        }
    }
}
