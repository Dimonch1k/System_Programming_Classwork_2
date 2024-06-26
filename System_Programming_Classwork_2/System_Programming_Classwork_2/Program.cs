using System;
using System.Threading;

namespace System_Programming_Classwork_2
{
    public class Program
    {
        private static IncrementNumbers incrementNumbers = new IncrementNumbers();

        private static int num1 = 0;
        private static int num2 = 0;


        static void Main(string[] args)
        {
            //RunThreadPool runThreadPool = new RunThreadPool();
            //runThreadPool.Run();


            // runAsyncIncrement();

            // runMonitor();
            // runLock();

            // runMutex();

            runSemaphore();

            Console.WriteLine("(Main Thread) Press any button to continue...");
            Console.ReadLine();

        }



        private static void runAsyncIncrement()
        {
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(doWork);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Field1: {incrementNumbers.Field1} \nField2: {incrementNumbers.Field2}");
            //Console.WriteLine($"Num: {num1}");
            //Console.WriteLine($"Num1: {num1} \nNum2: {num2}");

        }

        private static void doWork()
        {
            for (int i = 0; i < 100000; i++)
            {
                incrementNumbers.Field1++;
                //Interlocked.Increment(ref num1);

                if (i % 2 == 0)
                {
                    incrementNumbers.Field2++;
                    //Interlocked.Increment(ref num2);
                }
            }
        }



        private static void runMonitor()
        {
            RunMonitor runMonitor = new RunMonitor();
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(runMonitor.Run);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Field1: {runMonitor.Field1} \nField2: {runMonitor.Field2}");
        }


        private static void runLock()
        {
            RunLock runLock = new RunLock();
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(runLock.Run);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Field1: {runLock.Field1} \nField2: {runLock.Field2}");
        }


        private static void runMutex()
        {
            RunMutex runMutex = new RunMutex();
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(runMutex.RunNameMutex);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"Field1: {runMutex.Field1} \nField2: {runMutex.Field2}");
        }
        
        
        private static void runSemaphore()
        {
            RunSemaphore runSemaphore = new RunSemaphore();
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(runSemaphore.Run);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
        }
    }
}
