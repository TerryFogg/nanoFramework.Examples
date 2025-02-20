using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_LineDrawing
{
    public class Program
    {
        public static void Main()
        {
            Font DisplayFont = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            Bitmap fullScreenBitmap = new Bitmap(DisplayControl.ScreenWidth, DisplayControl.ScreenHeight);
            fullScreenBitmap.Clear();
            RandomDrawLine rdlt = new RandomDrawLine(fullScreenBitmap, DisplayFont);
        }
    }
}
