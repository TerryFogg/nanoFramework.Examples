using System;
using System.Diagnostics;
using System.Threading;

namespace nf_TimerTests
{
    public class Program
    {
        public static void Main()
        {
            Thread.Sleep(500);
            Thread.Sleep(2000);
            Thread.Sleep(5000);
            Thread.Sleep(10000);

            Timer timer = new Timer(new TimerCallback(OnTimer), null, 0, 1500);
            Thread.Sleep(Timeout.Infinite);

        }
        private static void OnTimer(object state)
        {
            Debug.WriteLine("Timer");
        }
    }
}
