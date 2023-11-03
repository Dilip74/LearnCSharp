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
            int a = 4, b = 5;
            SomeMethodPtr del = new SomeMethodPtr(SomeMethod);
            del.Invoke(a, b);


            Console.ReadKey();
        } 
        
        static void SomeMethod(int a, int b)
        {
            Console.WriteLine("Called some method");
        }

        public static void getData()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            

            Console.WriteLine(service.GetData(5));
        }
    }
}