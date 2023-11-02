using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
       /*
        * It’s happening because once the thread hits the awaiting operation in FirstAsync, the thread is freed from that method 
        * and returned to the thread pool.Once the operation is completed and the method has to continue, 
        * a new thread is assigned to it from a thread pool.The same process is repeated for the SecondAsync and ThirdAsync as well.
        */

        /*
         * Multithreading is a programming technique for executing operations running on multiple threads (also called workers) 
         * where we use different threads and block them until the job is done. 
         * 
         * Asynchronous programming is the concurrent execution of multiple tasks (here the assigned thread is returned back to a 
         * thread pool once the await keyword is reached in the method).
         */

        static void Main(string[] args)
        {
            MultiThread mt = new MultiThread();
            mt.ExecuteMultithreading();

            //await ExecuteAsyncFunctions();
        }

        public static async Task ExecuteAsyncFunctions()
        {
            var firstAsync = FirstAsync();
            var secondAsync = SecondAsync();
            var thirdAsync = ThirdAsync();

            await Task.WhenAll(firstAsync, secondAsync, thirdAsync);
        }

        public static async Task FirstAsync()
        {
            Console.WriteLine("First Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("First Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task SecondAsync()
        {
            Console.WriteLine("Second Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("Second Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }

        public static async Task ThirdAsync()
        {
            Console.WriteLine("Third Async Method on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            Console.WriteLine("Third Async Method Continuation on Thread with Id: " + Thread.CurrentThread.ManagedThreadId);
        }


    }
}
