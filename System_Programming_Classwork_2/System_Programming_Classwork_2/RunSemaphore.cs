using System;
using System.Threading;

namespace System_Programming_Classwork_2
{
    public class RunSemaphore
    {
        private Semaphore semaphore = new Semaphore(3, 3);


        public void Run()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} wait for semaphore");
            semaphore.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entered to protected area");
            Thread.Sleep(20000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} done working");
            semaphore.Release();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} release semaphore");
        }
    }
}