using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AbstractInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mathod();

            //Hyundai hyundai = new Hyundai();

            //Console.WriteLine(hyundai.CallFacility());
            //Console.WriteLine(hyundai.Wheel());
            //Console.WriteLine(hyundai.CheckAC());
            //Console.WriteLine(hyundai.DiscountPrice());
            //Console.ReadLine();

            //Toyota Toy = new Toyota();

            //Console.WriteLine(Toy.CallFacility());
            //Console.WriteLine(Toy.Wheel());
            //Console.WriteLine(Toy.CheckAC());
            //Console.WriteLine(Toy.DiscountPrice());

            //DecimalDigit();

            int input = 8675309;
            int numDigits = (int)Math.Ceiling(Math.Log10(input));

            //float result = input / MathF.Pow(10, numDigits);
        }

        static void DecimalDigit()
        {
            int dec0, dec1;

            //Console.Write("Enter a decimal number (,) :");
            double number = 125.45354;
            //double number = Convert.ToDouble(Console.ReadLine());

            string[] digits = number.ToString().Split('.');
            dec0 = digits[0].Length;

            if (digits.Length == 2)
            {
                dec1 = digits[1].Length;
            }
            else
            {
                dec1 = 0;
            }

            Console.WriteLine("Count of digit(s) before point:{0}", dec0);
            Console.WriteLine("Count of digit(s) after point:{0}", dec1);

            Console.ReadLine();

        }

        // try catch
        static void Mathod()
        {
            int Number1, Number2, Result;
            try
            {
                Console.WriteLine("Enter First Number");
                Number1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Second Number");
                //try
                //{
                    Number2 = int.Parse(Console.ReadLine());
                    Result = Number1 / Number2;
                    Console.WriteLine($"Result: {Result}");
                //}
                //catch(Exception ex)
                //{
                //    Console.WriteLine("Error");
                //}

            }
            catch (DivideByZeroException DBZE)
            {
                Console.WriteLine("Second Number Should Not Be Zero");
            }
            catch (FormatException FE)
            {
                Console.WriteLine("Enter Only Integer Numbers");
            }
        }
    }
}
