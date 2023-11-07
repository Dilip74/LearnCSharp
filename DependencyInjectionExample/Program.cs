using System;
using Microsoft.Win32;

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


            //int[] A = { 1, 3, 6,7,8,9, 4, 1, 2 };
            //int[] A = { -1, -3};
            //Console.WriteLine(Solution(A));

            //Geek g = new Geek();
            //g.M1();
            //g.M2();
            //g.M3();
            //g.M4();
            //g.M5("Method Name: M5");

            //NewMethodClass.M4(g);


            

            Console.ReadKey();
        } 

        static int Solution(int[] A)
        {
            int n = A.Length;
            Array.Sort(A);
            int res = 1;

            for (int i = 0; i < n; i++)
            {
                if (A[i] == res)
                    res++;

                if (A[i] > res)
                    return res;
            }

            return res;
        }
        
    }

    

    class Base
    {
        public void Method1()
        {
            Console.WriteLine("Method1 Base");
        }
        public virtual void Method2()
        { Console.WriteLine("Method2 Base");
        }
        public virtual void Method3()
        { Console.WriteLine("Method3 Base");
        }
    }
    class Derived : Base
    {
        new public void Method1()
        {
            Console.WriteLine("Method1 Derived");
        }
        public override void Method2()
        {
            Console.WriteLine("Method2 Derived");
        }
        public new void Method3()
        {
            Console.WriteLine("Method3 Derived");
        }
    }

        class A
    {
        static A()
        {

        }
    }

    class Geek
    {
        // Method 1 
        public void M1()
        {
            Console.WriteLine("Method Name: M1");
        }

        // Method 2 
        public void M2()
        {
            Console.WriteLine("Method Name: M2");
        }

        // Method 3 
        public void M3()
        {
            Console.WriteLine("Method Name: M3");
        }
    }

    static class NewMethodClass
    {

        // Method 4 
        public static void M4(this Geek g)
        {
            Console.WriteLine("Method Name: M4");
        }

        // Method 5 
        public static void M5(this Geek g, string str)
        {
            Console.WriteLine(str);
        }
    }



    abstract class mcn
    {
        public int add(int a, int b)
        {
            return (a + b);
        }
    }
    class mcn1 : mcn
    {
        public int mul(int a, int b)
        {
            return a * b;
        }
    }

    public class Area
    {
        public double area(double s)
        {
            double area = s * s;
            return area;
        }

        public double area(double l, double b)
        {
            double area = l * b;
            return area;
        }
    }
}
