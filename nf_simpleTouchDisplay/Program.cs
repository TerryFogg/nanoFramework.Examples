using nanoFramework.Runtime.Events;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_simpleTouchDisplay
{
    public class Program
    {
        public static void Main()
        {
            ApplicationMain.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
