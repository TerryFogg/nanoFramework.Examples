using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace AnalogueClock
{
    public class Program
    {
        public static void Main()
        {
            Font DisplayFont = Resources.GetFont(Resources.FontResources.ninab);
            Bitmap fullScreenBitmap = new Bitmap(480, 272);
            fullScreenBitmap.Clear();


            fullScreenBitmap.FillRectangle(0, 0, 480, 272, Color.Yellow, 60);
            fullScreenBitmap.DrawText("Hello there", DisplayFont, Color.Black, 10, 80);
            fullScreenBitmap.Flush();

        }
    }
}
