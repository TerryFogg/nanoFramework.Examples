using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;
using System.Threading;

namespace nf_Fonts
{
    internal class FontExample
    {
        public FontExample(Bitmap fullScreenBitmap, Font DisplayFont)
        {
            Font fntCourierRegular10 = Resources.GetFont(Resources.FontResources.courierregular10);
            Font fntComicSansMS16 = Resources.GetFont(Resources.FontResources.comicsansms16);
            Font fntNinaB = Resources.GetFont(Resources.FontResources.ninab);
            Font fntSegoeUIRegular12 = Resources.GetFont(Resources.FontResources.segoeuiregular12);
            Font fntSmall = Resources.GetFont(Resources.FontResources.small);


            string strSmallFont = Resources.GetString(Resources.StringResources.strnSmallFont);
            string strNinaFont = Resources.GetString(Resources.StringResources.strNinaFont);
            string strComicSansMS16 = Resources.GetString(Resources.StringResources.strComicSansMS16);
            string strCourierRegular10 = Resources.GetString(Resources.StringResources.strCourierRegular10);
            string strSegoeUIRegular12 = Resources.GetString(Resources.StringResources.strSegoeUIRegular12);
            Random rand = new Random();

            Color randomColor1 = ColorUtility.ColorFromRGB((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor2 = ColorUtility.ColorFromRGB((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor3 = ColorUtility.ColorFromRGB((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor4 = ColorUtility.ColorFromRGB((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor5 = ColorUtility.ColorFromRGB((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColorBack = ColorUtility.ColorFromRGB((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));

            fullScreenBitmap.FillRectangle(0, 0, 480, 272, randomColorBack, 60);
            fullScreenBitmap.DrawText(strSmallFont, fntSmall, randomColor1, 10, 80);
            fullScreenBitmap.DrawText(strSegoeUIRegular12, fntSegoeUIRegular12, randomColor2, 10, 100);
            fullScreenBitmap.DrawText(strNinaFont, fntNinaB, randomColor3, 10, 120);
            fullScreenBitmap.DrawText(strComicSansMS16, fntComicSansMS16, randomColor4, 10, 140);
            fullScreenBitmap.DrawText(strCourierRegular10, fntCourierRegular10, randomColor5, 10, 160);
            fullScreenBitmap.Flush();

        }
    }
}
