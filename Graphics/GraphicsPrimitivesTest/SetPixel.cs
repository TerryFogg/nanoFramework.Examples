using System;
using System.Drawing;
using nanoFramework.UI;

namespace Colours
{
    internal class SetPixel
    {
        internal void SetPixelTest(Bitmap fullScreenBitmap)
        {
            for (int ypos = 0; ypos< 10; ypos++)
            {
                for (int i = 0; i<fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Red);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 10; ypos< 20; ypos++)
            {
                for (int i = 0; i<fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Red);
                }
            }
            fullScreenBitmap.Flush();
            
            for (int ypos = 20; ypos< 30; ypos++)
            {
                for (int i = 0; i<fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.GreenYellow);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 30; ypos< 40; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Blue);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos =40; ypos< 50; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.LightGoldenrodYellow);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 50; ypos< 60; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.LightGray);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 60; ypos< 70; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.LightCoral);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 70; ypos< 80; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Magenta);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 80; ypos< 90; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.MediumAquamarine);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 90; ypos< 100; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.PapayaWhip);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 100; ypos< 110; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Peru);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 110; ypos< 120; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Snow);
                }
            }
            fullScreenBitmap.Flush();

            for (int ypos = 120; ypos< 135; ypos++)
            {
                for (int i = 0; i < fullScreenBitmap.Width; i++)
                {
                    fullScreenBitmap.SetPixel(i, ypos, Color.Violet);
                }
            }
            fullScreenBitmap.Flush();

        }
    }
}