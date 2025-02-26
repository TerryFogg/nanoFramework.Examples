using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;
using System.Drawing;
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

            Color randomColor1 = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor2 = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor3 = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor4 = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColor5 = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
            Color randomColorBack = Color.FromArgb((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));

            fullScreenBitmap.FillRectangle(0, 0, fullScreenBitmap.Width, fullScreenBitmap.Height, randomColorBack, 60);
            fullScreenBitmap.DrawText(strSmallFont, fntSmall, randomColor1, 0, 10);
            fullScreenBitmap.DrawText(strSegoeUIRegular12, fntSegoeUIRegular12, randomColor2, 0, 30 + fntSmall.Height);
            fullScreenBitmap.DrawText(strNinaFont, fntNinaB, randomColor3, 0, 60 + fntSmall.Height + fntSegoeUIRegular12.Height);
            fullScreenBitmap.DrawText(strComicSansMS16, fntComicSansMS16, randomColor4, 0, 90 + fntSmall.Height + fntSegoeUIRegular12.Height+fntNinaB.Height);
            fullScreenBitmap.DrawText(strCourierRegular10, fntCourierRegular10, randomColor5, 0, 120);
            fullScreenBitmap.Flush();

        }
    }
}
