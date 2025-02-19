using System;
using System.Diagnostics;
using System.Threading;

namespace TestCode
{
    public class Program
    {
        public static void Main()
        {
            testClass tc = new testClass
            {
                stringValue = "string Valuue",
                intValue = 2,
                floatValue = 4.5f
            };
            Debug.WriteLine(tc.stringValue);
            Debug.WriteLine(tc.intValue.ToString());
            Debug.WriteLine(tc.floatValue.ToString());

            Thread.Sleep(Timeout.Infinite);
        }
    }

    public class baseClass
    {
        public string stringValue { get; set; }
        public int intValue { get; set; }
    }
    public class testClass : baseClass
    {
        public float floatValue { get; set; }

    }


}
