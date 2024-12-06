using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace Colours
{
    public class Program
    {
        public static void Main()
        {
            Bitmap fullScreenBitmap = new Bitmap(240, 135);
            fullScreenBitmap.Clear();

            //SetPixel sp = new SetPixel();
            //sp.SetPixelTest(fullScreenBitmap);
            PolygonTest polygonTest = new PolygonTest();
            polygonTest.PolygonTest1(fullScreenBitmap);

        }
    }
}
