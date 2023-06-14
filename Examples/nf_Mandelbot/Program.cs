using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_Mandelbrot
{
    public class Program
    {
        public static void Main()
        {
            int iterations = 8;
            Bitmap fullScreenBitmap = new Bitmap(240, 135);
            Mandelbrot mb = new Mandelbrot(fullScreenBitmap,iterations);

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
