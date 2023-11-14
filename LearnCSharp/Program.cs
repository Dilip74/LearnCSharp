using System;

namespace LearnCSharp
{
    class Program
    {
        delegate void SomeMethodPtr(int a, int b);

        static void Main(string[] args)
        {
            //getData();

            //Swap Number without temp variable
            /*
            SwapNumber sn = new SwapNumber();
            sn.SwapWithoutTemp(4, 5);
            */
            //int a = 4, b = 5;
            //SomeMethodPtr del = new SomeMethodPtr(SomeMethod);
            //del.Invoke(a, b);

            Animal a = new Animal();
            Dog d = new Dog();
            a.Sound();
            d.Sound();
            a = d;
            a.Sound();

            Console.WriteLine();

            Console.ReadKey();
        } 
        
        static void SomeMethod(int a, int b)
        {
            Console.WriteLine("Called some method");
        }

        
    }

    public class Animal
    {
        protected int age;

        public Animal()
        {
            age = 100;
        }

        public virtual void Sound()
        {
            Console.WriteLine("age : {0}", age);
            Console.WriteLine("Make sound");
        }
    }

    public class Dog : Animal
    {
        public Dog()
        {
            age = 200;
        }

        public override void Sound()
        {
            Console.WriteLine("age : {0}", age);
            Console.WriteLine("Bark");
        }
    }

}