

using nanoFramework.UI;
using System;
using System.Threading;

namespace nf_BouncingBalls
{
    public class Program
    {
        public static void Main()
        {


            //string result = PiCalculationTests.CalculateTo(100);
            //Bitmap fullScreenBitmap = new Bitmap(480, 272);
//            Bitmap fullScreenBitmap = new Bitmap(240, 135);
            Bitmap fullScreenBitmap = new Bitmap(320, 180);
            //Bitmap fullScreenBitmap = new Bitmap(240, 240);
            //DisplayControl.FullScreen;
            fullScreenBitmap.Clear();


            BouncingBalls bb = new BouncingBalls(fullScreenBitmap);

        }

        //private static void test()
        //{
        //    Bitmap fullScreenBitmap = new Bitmap(320, 100);

        //    fullScreenBitmap.SetPixel(0, 0, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.SetPixel(10, 0, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.SetPixel(30, 0, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.SetPixel(0, 10, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.SetPixel(0, 30, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.SetPixel(10, 10, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.SetPixel(30, 30, nanoFramework.Presentation.Media.Color.White);

        //    fullScreenBitmap.Flush();
        //    Thread.Sleep(Timeout.Infinite);
        //}
    }
}
