#define WIFI_TEST
#define RP2XXX

using System;
using System.Threading;
using System.Diagnostics;

namespace Network
{
    public class Program
    {
        public static void Main()
        {
#if WIFI_TEST
            WifiTest();
#endif
        }
        private static void WifiTest()
        {
#if RP2XXX
            Cyw43 cyw = new Cyw43();
#endif

            System_Net_Tests snt = new();
            snt.Tests();

        }
    }
}
