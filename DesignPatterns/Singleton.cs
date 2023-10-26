using System;

namespace DesignPatterns
{
    public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;

        private static readonly object obj = new object();

        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter value : " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

        //public class DerivedSingleton : Singleton
        //{

        //}
    }
}
