using System;

namespace LearnCSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //getData();

            //Swap Number without temp variable
            /*
            SwapNumber sn = new SwapNumber();
            sn.SwapWithoutTemp(4, 5);
            */



            Console.ReadKey();
        } 
        
        public static void getData()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            

            Console.WriteLine(service.GetData(5));
        }
    }
}