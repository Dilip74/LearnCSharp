using System;

namespace DependencyInjectionExample
{
    // 1. Client Class = > The client class is a class which depends on the service class.
    // 2. Service Class = > The service class is a class that provides service to the client class.
    // 3. Injector Class = > The injector class injects the service class object into the client class.

    class Program
    {
        static void Main(string[] args)
        {
            //DependencyInjection ACS = new DependencyInjection(new ACService());
            //ACS.ON();
            //ACS.OFF();

            //DependencyInjection TVS = new DependencyInjection(new TVService());
            //TVS.ON();
            //TVS.OFF();

            string input = "Debugging???";

            //Console.WriteLine(RemoveSpecialChars.RemoveSpecialCharacters(input));
            //Console.WriteLine(RemoveSpecialChars.RemoveSplChars(input));


            Console.ReadKey();
        }

        
    }

    
}
