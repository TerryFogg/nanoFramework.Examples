using nanoFramework.Presentation.Media;
using nanoFramework.Presentation;
using nanoFramework.UI;
using System;
using System.Drawing;
using System.Threading;
namespace Colours
{
    internal class PolygonTest
    {
        internal void PolygonTest1(Bitmap fullScreenBitmap)
        {
            int width = fullScreenBitmap.Width;
            int height = fullScreenBitmap.Height;
            int midX = width / 2;
            int midY = height / 2;
            int min = System.Math.Min(width, height);
            int s = min / 3;
            int s2 = s / 2;
            double h = (double)s / System.Math.Sqrt(2);
            int len = s2 + (int)h;

            DrawingContext dc = new DrawingContext(fullScreenBitmap);

            int[] pts = new int[] {
                        midX - s2 , midY - len,
                        midX + s2 , midY - len,
                        midX + len, midY - s2,
                        midX + len, midY + s2,
                        midX + s2 , midY + len,
                        midX - s2 , midY + len,
                        midX - len, midY + s2,
                        midX - len, midY - s2 };

            Brush brush = new SolidColorBrush(Color.Yellow);
            Pen pen = new Pen(Color.Red);
            dc.DrawPolygon(brush, pen, pts);

            fullScreenBitmap.Flush();


            Thread.Sleep(20);
            brush = new SolidColorBrush(Color.AliceBlue);
            pen = new Pen(Color.Yellow,4);
            dc.DrawPolygon(brush, pen, pts);
            fullScreenBitmap.Flush();


        }
    }
}
