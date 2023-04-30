using System;
using System.Diagnostics;
using System.Threading;

namespace NFApp2
{
    public class Program
    {
        public static void Main()
        {

            int i = 10 * 5 * 9;
            double k = 10.5 * 4.5 * -3.2;

            Debug.WriteLine($"Hello from nanoFramework! {i},{k}");

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
