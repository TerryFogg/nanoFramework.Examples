
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System.Diagnostics;


namespace nf_Mandelbrot
{
    internal class Mandelbrot
    {
        public Mandelbrot(Bitmap mandelbrotBitmap, int iterations)
        {
            int xRes = mandelbrotBitmap.Width;
            int yRes = mandelbrotBitmap.Height;
            Color outputPixelColour = Color.White;
            int outputBlockCounter = 0;


            //int redMax = ColorUtility.To16Bpp(Color.DarkRed);
            //int redMin = ColorUtility.To16Bpp(Color.LightPink);
            //int blueMax = ColorUtility.To16Bpp(Color.DarkBlue);
            //int blueMin = ColorUtility.To16Bpp(Color.LightBlue);
            //int greenMax = ColorUtility.To16Bpp(Color.DarkGreen);
            //int greenMin = ColorUtility.To16Bpp(Color.LightGreen);

            int blueMax = 0xFF0000;
            int blueMin = 0x010000;
            int greenMax = 0x00FF00;
            int greenMin = 0x000100;
            int redMax = 0x0000FF;
            int redMin = 0x000001;


            for (int i = 0; i < xRes; i++)
            {
                for (int j = 0; j < yRes; j++)
                {
                    outputBlockCounter++;
                    double x0 = (double)(i) / (double)xRes * 3.5 - 2.5;
                    double y0 = (double)(j) / (double)yRes * 2.0 - 1.0;
                    double x = 0.0;
                    double y = 0.0;
                    int iteration = 0;
                    while (x * x + y * y < 2 * 2 && iteration < iterations)
                    {
                        double xtemp = x * x - y * y + x0;
                        y = 2 * x * y + y0;
                        x = xtemp;
                        iteration++;
                    }
                    if (iteration == iterations && x * x + y * y < 2 * 2)
                    {
                        outputPixelColour = Color.Black;
                    }
                    else
                    {
                        double colorvalue = (double)iteration / (double)iterations;

                        byte rAverage = (byte)(redMin + (int)((redMax - redMin) * colorvalue));
                        byte gAverage = (byte)(greenMin + (int)((greenMax - greenMin) * colorvalue));
                        byte bAverage = (byte)(blueMin + (int)((blueMax - blueMin) * colorvalue));
                        outputPixelColour = ColorUtility.ColorFromRGB(rAverage, gAverage, bAverage);


                        //   double pixelColorValue = colorvalue * ColorUtility.To16Bpp(start_color) + (colorvalue - 1) * ColorUtility.To16Bpp(end_color);

                        //Color pixelColor = ColorUtility.ColorFromRGB((byte)(colorvalue * 255), (byte)(colorvalue * 255),
                        //    (byte)(colorvalue * 255));

                        //Color c = new Color();
                        //outputPixelColour = ColorUtility.pixelColorValue.
                    }
                    mandelbrotBitmap.SetPixel(i, j, outputPixelColour);

                }
                if (outputBlockCounter % 100 == 0)
                {
                    mandelbrotBitmap.Flush();
                }
            }
            mandelbrotBitmap.Flush();

        }
    }
}