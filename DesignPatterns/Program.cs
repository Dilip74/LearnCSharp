using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetails("From Employee");

            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");

            Console.WriteLine("--------------------------------");

            Singleton.DerivedSingleton derivedSingleton = new Singleton.DerivedSingleton();
            derivedSingleton.PrintDetails("Called from derived class");

            Console.ReadLine();
        }
    }
}
