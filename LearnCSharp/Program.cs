using System;
using System.Collections;
using System.Collections.Generic;

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

            //Animal a = new Animal();
            //Dog d = new Dog();
            //a.Sound();
            //d.Sound();
            //a = d;
            //a.Sound();

            //Console.WriteLine();

            //string str = "100";

            //if (str.IsNumeric())
            //    Console.WriteLine("The string object named str contains numeric value.");

            //int n = 2;

            //if (n.IsEven())
            //    Console.WriteLine("The value of the integer is even.");

            //FleetController fc = new FleetController();
            //fc.FirstMethod();
            //fc.SecondMethod();

            //Test test = new Test();
            //test.FirstMethod();
            //test.SecondMethod();


            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");

            ArrayList arrList = new ArrayList();
            arrList.Add("1");
            arrList.Add("2");
            arrList.Add(3);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in arrList)
            //{
            //    Console.WriteLine(item);
            //}

            int[] intList = new int[4];
            intList[0] = 11;
            intList[1] = 31;

            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        } 
        
        static void SomeMethod(int a, int b)
        {
            Console.WriteLine("Called some method");
        }

        
        
    }

    
    public class Test:FleetController
    {
        
    }


    public static class IntegerExtensions
    {
        public static bool IsEven(this int i)
        {
            return ((i % 2) == 0);
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