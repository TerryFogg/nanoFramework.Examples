using System;
using System.Diagnostics;
using System.Threading;

namespace nf_TimerTests
{
    public class Program
    {
        public static void Main()
        {
            var x = 10.3;
            Debug.WriteLine("Hello from nanoFramework!");

            Thread.Sleep(1000);


            Thread.Sleep(5000);
            object SomeState = new object();
            Timer timer = new Timer(new TimerCallback(OnTimer), x, 0, 500);

            Thread.Sleep(5000);

            timer.Change(0, 2000);

            Thread.Sleep(Timeout.Infinite);

        }
        private static void OnTimer(object state)
        {
            Debug.WriteLine("Timer" + state.ToString());

        }
    }
}
