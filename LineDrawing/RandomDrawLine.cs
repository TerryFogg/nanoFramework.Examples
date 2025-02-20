﻿using System;
using System.Drawing;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;

namespace nf_LineDrawing
{
    public class RandomDrawLine
    {
        public RandomDrawLine(Bitmap fullScreenBitmap,  Font DisplayFont)
        {
            Random random = new Random();
            fullScreenBitmap.Clear();
            fullScreenBitmap.Flush();
            fullScreenBitmap.DrawText("Random Line Drawing", DisplayFont, Color.AliceBlue, 0, 0);

            while (true)
            {
                for (int i = 1000; i > 0; i--)
                {
                    int thickness = random.Next(8);
                    fullScreenBitmap.DrawLine(Color.FromArgb(random.Next(0xFFFFFF)),
                                               thickness,
                                               random.Next(fullScreenBitmap.Width),
                                               random.Next(fullScreenBitmap.Height - 22),
                                               random.Next(fullScreenBitmap.Width),
                                               random.Next(fullScreenBitmap.Height));
                    InformationBar.DrawInformationBar(fullScreenBitmap, DisplayFont, InfoBarPosition.bottom, $"Line Number {i}");
                    fullScreenBitmap.Flush();
                }
                fullScreenBitmap.Clear();
            }
        }
    }
}
