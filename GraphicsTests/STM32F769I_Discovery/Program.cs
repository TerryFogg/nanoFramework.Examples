using System.Threading;
using ct= ColourTests.ColourTests; 

namespace GraphicsTest
{
    public class Program
    {
        public static void Main()
        {
            ct.StartColourTests();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
