using System;
using System.Threading;

namespace System_Programming_Classwork_2
{
    public class RunMutex
    {
        public int Field1 { get; set; }
        public int Field2 { get; set; }

        Mutex mutex = new Mutex();



        public void RunNameMutex()
        {
            using (Mutex mutex = new Mutex(false, "Global\\MyMutex"))
            {
                if (mutex.WaitOne(TimeSpan.FromMilliseconds(5), false))
                {
                    Console.WriteLine("Entered to protected area");
                    Thread.Sleep(50000);
                    return;
                }
                Console.WriteLine("No instances detected");
            }
        }


        public void Run()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} wait for mutex");
            mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} entered to protected area");
            Thread.Sleep(20000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} done working");
            mutex.ReleaseMutex();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} release mutex");
        }
    }
}