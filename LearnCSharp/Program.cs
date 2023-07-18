using System;
using System.Collections.Generic;
using System.Threading;

namespace LearnCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int myNum = 15;
            string myString = "Dilip";

            Console.WriteLine("myNum Before : {0}", myNum);
            ProcessNumber(myNum);
            Console.WriteLine("myNum After : {0}", myNum);
            Console.WriteLine("myString Before : {0}", myString);
            ProcessString(myString);
            Console.WriteLine("myString After : {0}", myString);

            Console.ReadKey();
        }

        public static void ProcessNumber(int num)
        {
            num = 100;
        }

        public static void ProcessString(string str)
        {
            str += " Kumar";
        }
    }    
}