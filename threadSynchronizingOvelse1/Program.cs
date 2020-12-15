using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threadSynchronizingOvelse1
{
    class Program
    {
        // Shared variable Counter for both threads to access
        static int Counter = 0;
        // Shared lock for both Threads to access
        static object Lock = new object();
        static void Main(string[] args)
        {
            // new thread was made with the method CountIncrement
            Thread tIncrement = new Thread(CounterIncrement);
            // new thread was made with the method CounterDecrement
            Thread tDecrement = new Thread(CounterDecrement);
            // start tIncrement thread 
            tIncrement.Start();
            // sleep main Thread for 500ms
            Thread.Sleep(500);
            // start tDecrement thread 
            tDecrement.Start();
        }

        // CounterIncrement method increments the Counter variable with 2.
        static void CounterIncrement()
        {
            while (true)
            {
                // gets the Lock object
                Monitor.Enter(Lock);
                {
                    // increment the variable with 2
                    try
                    {
                        Counter = Counter + 2;
                        Console.WriteLine($"thread id :[{Thread.CurrentThread.ManagedThreadId}] + incremented to : {Counter}");
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        // release the Lock object
                        Monitor.Exit(Lock);
                    }
                   
                }
               
            }
        }
        // CounterDecrement method decrements the Counter variable with 1.
        static void CounterDecrement()
        {
            while (true)
            {
                // gets the Lock
                Monitor.Enter(Lock);

                // decrement the Counter variable with 1
                try
                {
                    Counter--;
                    Console.WriteLine($"thread id :[{Thread.CurrentThread.ManagedThreadId}] + decremented to : {Counter}");
                    Thread.Sleep(1000);
                }
                finally
                {
                    // Release the Lock object
                    Monitor.Exit(Lock);
                }
               
            }
        }
    }
}
