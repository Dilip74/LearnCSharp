using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExamples
{
    class StarPatterns
    {
        /*
        
        Pattern 1:
        ********
        *******
        ******
        *****
        ****
        ***
        **
        *
        
        */

        public void Star1(int starCount)
        {
            if (starCount == 0)
                starCount = 8;

            for (int row = starCount; row >= 1; row--)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        /*
        
        Pattern 2:
        *
        **
        ***
        ****
        *****
        ******
        *******
        ********
        
        */

        public void Star2(int starCount)
        {
            if (starCount == 0)
                starCount = 8;

            for (int row = 1; row <= starCount; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        /*
        
        Pattern 3:
              *
             ***
            *****
           *******
          *********
         ***********
        *************
         ***********
          *********
           *******
            *****
             ***
              *
        
        */

        public void Star3()
        {
            int number, i, k, count = 1;

            Console.WriteLine("Enter the number of rows:");
            number = int.Parse(Console.ReadLine());

            count = number - 1;
            for (k = 1; k <= number; k++)
            {
                for (i = 1; i <= count; i++)
                    Console.Write(" ");
                count--;
                for (i = 1; i <= 2 * k - 1; i++)
                    Console.Write("*");
                Console.WriteLine();
            }

            count = 1;
            for (k = 1; k <= number - 1; k++)
            {
                for (i = 1; i <= count; i++)
                    Console.Write(" ");
                count++;
                for (i = 1; i <= 2 * (number - k) - 1; i++)
                    Console.Write("*");
                Console.WriteLine();
            }

        }


        /*
        
        Pattern 4:
        
               *
              **
             ***
            ****
           *****
          ******
         *******
        ********
        
        */

        public void Star4(int startCount)
        {
            if (startCount == 0)
                startCount = 8;

            for (int i = 1; i <= startCount; i++)
            {
                for (int k = 1; k <= startCount- i; k++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }

        /*
        
        Pattern 5:
        
               *
              **
             ***
            ****
           *****
          ******
         *******
        ********
        
        */

        public void Star5(int startCount)
        {
            if (startCount == 0)
                startCount = 8;

            for (int i = 0; i < startCount; ++i)
            {
                for (int j = 0; j <= i; ++j)
                {
                    Console.Write("*");
                }

                Console.Write(" ");

                //if (i != startCount - 1)
                //{
                //    Console.Write(" ");
                //}
                //else
                //{
                //    Console.Write(" * ");
                //}
                for (int j = 0; j <= i; ++j)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

        }

        /*
        
        Pattern 6:
        
        *******
        *     *
        *     *
        *     *
        *     *
        *     *
        *******
        
        */

        public void Star6(int startCount)
        {
            if (startCount == 0)
                startCount = 7;

            for (int i = 0; i < startCount; ++i)
            {
                if (i == 0 || i == startCount - 1)
                {
                    for (int j = 1; j <= startCount; ++j)
                    {
                        Console.Write("*");
                    }
                }

                if (i > 0 && i < startCount - 1)
                {
                    for (int j = 1; j <= startCount; ++j)
                    {
                        if (j == 1 || j == startCount)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        /*
        
        Pattern 7:
        
        
        
        */

        public void Star7(int startCount)
        {
            if (startCount == 0)
                startCount = 7;

            for (int i = 0; i < startCount; ++i)
            {
                stars(i + 1);
                spaces(startCount - i - 1);
                stars(startCount - i + 1);
                spaces(2 * i);
                stars(startCount - i);
                spaces(startCount - i - 1);
                stars(i + 1);

                Console.WriteLine();
            }

        }

        static void stars(int count)
        {
            for (int i = 0; i < count; ++i)
                Console.Write("*");
        }

        static void spaces(int count)
        {
            for (int i = 0; i < count; ++i)
                Console.Write(" ");
        }


    }
}
