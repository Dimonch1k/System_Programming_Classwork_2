using System;
using System.Threading;

namespace System_Programming_Classwork_2
{
    public class RunThreadPool
    {
        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                int taskNumber = i;
                ThreadPool.QueueUserWorkItem(DoWork, taskNumber);
            }

            Console.WriteLine("Main thread started and do some work");
            Thread.Sleep(2000);
            Console.WriteLine("Main thread end work");
        }

        public void DoWork(object state)
        {
            int taskNumber = (int)state;
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started. Task number: {taskNumber}");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} end work. Task number: {taskNumber}");
        }


    }
}
