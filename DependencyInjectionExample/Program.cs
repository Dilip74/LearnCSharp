using DependencyInjectionExample.Implementation;
using DependencyInjectionExample.Interface;
using DependencyInjectionExample.OpenClose;
using System;
using System.Collections.Generic;

namespace DependencyInjectionExample
{
    // 1. Client Class = > The client class is a class which depends on the service class.
    // 2. Service Class = > The service class is a class that provides service to the client class.
    // 3. Injector Class = > The injector class injects the service class object into the client class.

    class Program
    {
        static void Main(string[] args)
        {
            //DependencyInjection
            /*
            DependencyInjection ACS = new DependencyInjection(new ACService());
            ACS.ON();
            ACS.OFF();

            DependencyInjection TVS = new DependencyInjection(new TVService());
            TVS.ON();
            TVS.OFF();
            */

            //RemoveSpecialCharacters
            /*
            string input = "Debugging???";

            Console.WriteLine(RemoveSpecialChars.RemoveSpecialCharacters(input));
            Console.WriteLine(RemoveSpecialChars.RemoveSplChars(input));
            */

            // Open Close Principle
            /*
            Employee empJohn = new PermanentEmployee(1, "John");
            Employee empJason = new TemporaryEmployee(2, "Jason");

            Console.WriteLine(string.Format("Employee {0} Bonus : {1}", empJohn.ToString(), empJohn.CalculateBonus(100000).ToString()));
            Console.WriteLine(string.Format("Employee {0} Bonus : {1}", empJason.ToString(), empJason.CalculateBonus(75000).ToString()));
            */

            //Liskov Substitution Principle
            /*
            List<Employee> employees = new List<Employee>();
            employees.Add(new PermanentEmployee(1, "Dilip"));
            employees.Add(new TemporaryEmployee(2, "Kumar"));

            foreach (var employee in employees)
            {
                Console.WriteLine(string.Format("Employee {0} Bonus : {1} Minimum Sal : {2}",
                    employee.ToString(),
                    employee.CalculateBonus(100000).ToString(),
                    employee.GetMinimumSalary().ToString()));
            }

            Console.WriteLine();
            Console.WriteLine();

            List<IEmployee> employees1 = new List<IEmployee>();
            employees1.Add(new PermanentEmployee(1, "Dilip"));
            employees1.Add(new TemporaryEmployee(2, "Kumar"));
            employees1.Add(new ContractEmployee(3, "Jason"));

            foreach (var employee in employees1)
            {
                Console.WriteLine(string.Format("Employee {0} Minimum Sal : {1}",
                    employee.ID.ToString(),
                    employee.GetMinimumSalary().ToString()));
            }
            */




            Console.ReadKey();
        }   
    }
}
