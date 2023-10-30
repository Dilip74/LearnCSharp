using System;

namespace LearnCSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            getData();


            int a = 4, b = 5;
            Console.WriteLine("Before swap a= " + a + " b= " + b);
            a = a * b; //a=20 (4*5)      
            b = a / b; //b=4 (20/5)      
            a = a / b; //a=5 (20/4)    
            Console.Write("After swap a= " + a + " b= " + b);

            Console.ReadKey();
        } 
        
        public static void getData()
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            

            Console.WriteLine(service.GetData(5));
        }
    }
}