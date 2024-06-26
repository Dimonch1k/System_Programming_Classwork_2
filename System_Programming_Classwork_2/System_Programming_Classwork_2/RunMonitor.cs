using System.Net.Http.Headers;
using System.Threading;

namespace System_Programming_Classwork_2
{
    public class RunMonitor
    {
        public int Field1 { get; set; }
        public int Field2 { get; set; }

        public void Run()
        {
            for (int i = 0; i < 100000; i++)
            {
                Monitor.Enter(this);

                Field1++;
                if (i % 2 == 0)
                {
                    Field2++;
                }
                
                Monitor.Exit(this);
            }
        }
    }
}
