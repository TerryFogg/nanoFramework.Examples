using System;
using System.Diagnostics;
using System.Threading;

namespace NFApp2
{
    public class Program
    {
        public class baseClass1
        {
            public int intValue { get; set; }
            public int stringValue { get; set; }
        }

        public class  inhertBaseClass1 : baseClass1        {
            
        }



        public static void Main()
        {




            throw new Exception("Unknown touch event.");

            Debug.WriteLine("Hello from nanoFramework!");

            long NumberOfTicks = DateTimeTest();
            Debug.WriteLine("Number of ticks ${NumberOfTicks}");

            Thread.Sleep(Timeout.Infinite);

        }
        private static long DateTimeTest()
        {
            DateTime dt = new DateTime();
            long NumberOfTicks = dt.Ticks;
            return NumberOfTicks;
        }
    }
}