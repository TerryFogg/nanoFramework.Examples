﻿using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System.Drawing;

namespace nf_RotateImage
{
    public enum InfoBarPosition
    {
        Top,
        bottom
    }
    public static class InformationBar
    {
        public static void DrawInformationBar(Bitmap theBitmap, Font DisplayFont, InfoBarPosition pos, string TextToDisplay)
        {
            theBitmap.DrawRectangle(Color.White, 0, 0, theBitmap.Height - 20, 320, 22, 0, 0, Color.White,
                0, theBitmap.Height - 20, Color.White, 0, theBitmap.Height, Bitmap.OpacityOpaque);
            theBitmap.DrawText(TextToDisplay, DisplayFont, Color.Black, 0, theBitmap.Height - 20);
        }

    }
}
