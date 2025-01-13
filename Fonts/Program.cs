using nanoFramework.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace nf_Fonts
{
    public class Program
    {
        public static void Main()
        {
          //  Bitmap fullScreenBitmap = DisplayControl.FullScreen;

            Bitmap fullScreenBitmap = new Bitmap(DisplayControl.ScreenWidth,DisplayControl.ScreenHeight);

            Font DisplayFont = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            fullScreenBitmap.Clear();

            FontExample fe = new FontExample(fullScreenBitmap, DisplayFont);
        }
    }
}
