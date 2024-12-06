using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using nanoFramework.UI;

namespace ColourTests
{
    public static class ColourTests
    {
        //
        // Testing notes : 
        //
        // 1. A selection of 9 ARGB colours to test operation
        // 2. 16-bit RGB565 values expected to be in the native bitmap for
        //    presentation to the display controller to properly send to the
        //    display device.
        // 3. RGB565 format is commonly called "native" format in the C++/C code
        // 3. JPEG test was created using Paint.net to set the 9 pixels to the ARGB colours
        //    then saved to disk and re-read. The values re-read from the disk are "compressed"
        //    so are slightly different. The expected values were found using the eye-dropper tool
        //    of paint.net to get the hex colour values.
        // 4. Bitmaps saved in the resource file are all converted to RGB565 format before being
        //    embedded into the assembly and deployed to flash. 
        // 5. The graphics code supports reading in bitmaps of 32-bit, 24-bit and 8-bit indexed,
        //    usually from file. For this test the bitmaps are setup as a C# byte array to eliminate
        //    the need to have a file system.
        // 6. Restoring RGB565 to ARGB results in inexact values due to the loss of 3 bits red,
        //    2 bits green and 3 bits blue. The restoration code uses an algorithm (included below)
        //    to approximate the original colour
        //    It is unknown if this a good algorith and is the one used in .netMF
        // 7. Gif values should be the same as SetPixel, GetPixel, unlike jpeg there
        //    is no change from compression.
        //
        // |-------------------|---------------|----------------|---------------|--------------| 
        // |     Colours       | 32-bit ARGB   |   Set Pixel    |  Get Pixel    |      JPEG    |
        // |                   |  Source       | 16-bit RGB565  | Restored ARGB | Restored RGB |
        // |-------------------|---------------|----------------|---------------|--------------|
        // | Color.DarkRed     |  0xFF8B0000   |    0x8800      |  0xFF8F0000   |   0x8F0000   |
        // | Color.Red         |  0xFFFF0000   |    0xF800      |  0xFFFF0000   |   0xFE0000   |
        // | Color.LightPink   |  0xFFFFB6C1   |    0xFDB8      |  0xFFFFB7C0   |   0xFFB6C1   |
        // | Color.LightGreen  |  0xFF90EE90   |    0x9772      |  0xFF90EF90   |   0x90EE90   |
        // | Color.Green       |  0xFF008000   |    0x0400      |  0xFF008000   |   0x008001   |
        // | Color.DarkGreen   |  0xFF006400   |    0x0320      |  0xFF006700   |   0x006401   |
        // | Color.LightBlue   |  0xFFADD8E6   |    0xAEDC      |  0xFFAFD8E0   |   0xAFD9E6   |
        // | Color.Blue        |  0xFF0000FF   |    0x001F      |  0xFF0000FF   |   0x0000FE   |
        // | Color.DarkBlue);  |  0xFF00008B   |    0x0011      |  0xFF00008F   |   0x01008C   |
        // |-------------------|---------------|----------------|---------------|--------------|

        public static byte[] expectedDataReturned = new byte[]
            {
                0x00,0x00,0x8F,0xFF,
                0x00,0x00,0xFF,0xFF,
                0xC0,0xB7,0xFF,0xFF,
                0x90,0xEF,0x90,0xFF,
                0x00,0x80,0x00,0xFF,
                0x00,0x67,0x00,0xFF,
                0xE0,0xD8,0xAF,0xFF,
                0xFF,0x00,0x00,0xFF,
                0x8F,0x00,0x00,0xFF
            };
        // JPEG data is a bit different to compression loss
        private static byte[] expected_JPEG_GIF_DataReturned = new byte[]
            {
                0x00,0x00,0x8F,0xFF,
                0x00,0x07,0xFF,0xFF,
                0xC0,0xB0,0xFF,0xFF,
                0x90,0xE8,0x90,0xFF,
                0x00,0x7F,0x00,0xFF,
                0x00,0x67,0x00,0xFF,
                0xE0,0xD7,0xA0,0xFF,
                0xFF,0x08,0x00,0xFF,
                0x8F,0x00,0x00,0xFF
            };
        private static byte[] expectedDataBitmapFromResourcesReturned = new byte[]
            {
                0x00,0x00,0x8F,0xFF,
                0x00,0x00,0xFF,0xFF,
                0xC0,0xB7,0xFF,0xFF,
                0x90,0xF0,0x90,0xFF,
                0x00,0x80,0x00,0xFF,
                0x00,0x67,0x00,0xFF,
                0xE0,0xD8,0xAF,0xFF,
                0xFF,0x00,0x00,0xFF,
                0x8F,0x00,0x00,0xFF
            };
        public static void StartColourTests()
        {
            Font DisplayFont = Resources.GetFont(Resources.FontResources.small);
            SetPixelGetPixelTest();
            JPegTest(expected_JPEG_GIF_DataReturned);
            GifTest(expected_JPEG_GIF_DataReturned);
            BitmapFromEmbeddedResourceTest(expectedDataBitmapFromResourcesReturned);
            BitmapFromBytesTest();
            DisplayGraphics(DisplayFont);
        }
        private static void SetPixelGetPixelTest()
        {
            // Set Pixel colour test
            // ---------------------

            Bitmap testBitmap = new Bitmap(9, 1);
            testBitmap.Clear();

            testBitmap.SetPixel(0, 0, Color.DarkRed);
            testBitmap.SetPixel(1, 0, Color.Red);
            testBitmap.SetPixel(2, 0, Color.LightPink);
            testBitmap.SetPixel(3, 0, Color.LightGreen);
            testBitmap.SetPixel(4, 0, Color.Green);
            testBitmap.SetPixel(5, 0, Color.DarkGreen);
            testBitmap.SetPixel(6, 0, Color.LightBlue);
            testBitmap.SetPixel(7, 0, Color.Blue);
            testBitmap.SetPixel(8, 0, Color.DarkBlue);

            // Look at the RAW binary data.
            // The data should be RGB565 ( short = RRRRRGGGGGGBBBBB)
            // in little endian order    ( byte0 = GGGBBBB, byte1 = RRRRRGGG)

            byte[] resultantBitmapData = testBitmap.GetBitmap();
            AssertBitmapIsRGB565(resultantBitmapData);

            // GetPixel colour test
            // --------------------

            long Pixel0 = testBitmap.GetPixel(0, 0).ToArgb();
            long Pixel1 = testBitmap.GetPixel(1, 0).ToArgb();
            long Pixel2 = testBitmap.GetPixel(2, 0).ToArgb();
            long Pixel3 = testBitmap.GetPixel(3, 0).ToArgb();
            long Pixel4 = testBitmap.GetPixel(4, 0).ToArgb();
            long Pixel5 = testBitmap.GetPixel(5, 0).ToArgb();
            long Pixel6 = testBitmap.GetPixel(6, 0).ToArgb();
            long Pixel7 = testBitmap.GetPixel(7, 0).ToArgb();
            long Pixel8 = testBitmap.GetPixel(8, 0).ToArgb();

            long Pixel0Expected = ARGB_TO_RGB565_TO_ARGB(Color.DarkRed);
            long Pixel1Expected = ARGB_TO_RGB565_TO_ARGB(Color.Red);
            long Pixel2Expected = ARGB_TO_RGB565_TO_ARGB(Color.LightPink);
            long Pixel3Expected = ARGB_TO_RGB565_TO_ARGB(Color.LightGreen);
            long Pixel4Expected = ARGB_TO_RGB565_TO_ARGB(Color.Green);
            long Pixel5Expected = ARGB_TO_RGB565_TO_ARGB(Color.DarkGreen);
            long Pixel6Expected = ARGB_TO_RGB565_TO_ARGB(Color.LightBlue);
            long Pixel7Expected = ARGB_TO_RGB565_TO_ARGB(Color.Blue);
            long Pixel8Expected = ARGB_TO_RGB565_TO_ARGB(Color.DarkBlue);

            Debug.Assert(Pixel0 == Pixel0Expected);
            Debug.Assert(Pixel1 == Pixel1Expected);
            Debug.Assert(Pixel2 == Pixel2Expected);
            Debug.Assert(Pixel3 == Pixel3Expected);
            Debug.Assert(Pixel4 == Pixel4Expected);
            Debug.Assert(Pixel5 == Pixel5Expected);
            Debug.Assert(Pixel6 == Pixel6Expected);
            Debug.Assert(Pixel7 == Pixel7Expected);
            Debug.Assert(Pixel8 == Pixel8Expected);

            testBitmap.Dispose();
        }
        private static void DisplayGraphics(Font DisplayFont)
        {
            int boxSize = 16;
            int fontleft = 165;

            Bitmap fullScreen = DisplayControl.FullScreen;
            if (fullScreen == null)
            {
                fullScreen = new Bitmap(DisplayControl.ScreenWidth, DisplayControl.ScreenHeight);
            }


            // Set pixels
            fullScreen.DrawText("Set Pixel", DisplayFont, Color.DarkRed, fontleft, 2);
            Color[] colours = new Color[]
            {
                Color.DarkRed,
                Color.Red,
                Color.LightPink,
                Color.LightGreen,
                Color.Green,
                Color.DarkGreen,
                Color.LightBlue,
                Color.Blue,
                Color.DarkBlue
             };
            int xSetPixelOffset = 0;
            foreach (Color colour in colours)
            {
                for (int y = 0; y<boxSize; y++)
                {
                    for (int x = xSetPixelOffset; x < xSetPixelOffset + boxSize; x++)
                    {
                        fullScreen.SetPixel(x, y, colour);
                    }
                }
                xSetPixelOffset+=boxSize;
            }

            Bitmap JpegColourTest = Resources.GetBitmap(Resources.BitmapResources.JpegTest);
            Bitmap GifColourTest = Resources.GetBitmap(Resources.BitmapResources.JpegTest);
            Bitmap Bitmap24bitTest = Resources.GetBitmap(Resources.BitmapResources.Bitmap24bitTest);
            Bitmap Bitmap8bitTest = Resources.GetBitmap(Resources.BitmapResources.Bitmap8bitTest);
            Bitmap Bmp24Bit_ARGB = new Bitmap(ImageFromBytes.BitmapBytes24bitTest, Bitmap.BitmapImageType.Bmp);
            Bitmap Bmp8Bit_ARGB = new Bitmap(ImageFromBytes.BitmapBytes8bitTest, Bitmap.BitmapImageType.Bmp);

            int xoffset = 0;

            BitmapAndName[] bmns = new BitmapAndName[]
            {
                new BitmapAndName{name= "JPEG",bitmap=JpegColourTest },
                new BitmapAndName{name= "GIF",bitmap=GifColourTest },
                new BitmapAndName{name= "24 bit From Resource",bitmap=Bitmap24bitTest },
                new BitmapAndName{name= "8 bit From Resourc",bitmap=Bitmap8bitTest },
                new BitmapAndName{name= "Bmp24Bit_ARGB",bitmap=Bmp24Bit_ARGB },
                new BitmapAndName{name= "Bmp8Bit_ARGB",bitmap=Bmp8Bit_ARGB }
            };

            int yoffset = boxSize + 1;
            int colourChange = 0;
            Color fontColour = Color.White;
            foreach (BitmapAndName bmn in bmns)
            {
                colourChange++;
                for (int pixel = 0; pixel< 9; pixel++)
                {
                    for (int y = 0; y<boxSize; y++)
                    {
                        for (int x = 0; x<boxSize; x++)
                        {
                            fullScreen.DrawImage(x+xoffset, y+yoffset, bmn.bitmap, pixel, 0, 1, 1);
                        }
                    }
                    switch (colourChange)
                    {
                        case 0:
                            fontColour= Color.Red;
                            break;
                        case 1:
                            fontColour= Color.LightPink;
                            break;
                        case 2:
                            fontColour= Color.LightGreen;
                            break;
                        case 3:
                            fontColour= Color.Green;
                            break;
                        case 4:
                            fontColour= Color.DarkGreen;
                            break;
                        case 5:
                            fontColour= Color.LightBlue;
                            break;
                        case 6:
                            fontColour= Color.Blue;
                            break;
                        case 7:
                            fontColour= Color.DarkBlue;
                            break;
                    }
                    fullScreen.DrawText(bmn.name, DisplayFont, fontColour, fontleft, yoffset);
                    xoffset += boxSize;
                }
                xoffset = 0;
                yoffset += boxSize + 1;
            }

            //// Draw some Gradients
            int rectangleHeight = 20;
            int rectangleWidth = 180;
            int outlineWidth = 2;
            int newsectionY = yoffset;
            // red gradient
            fullScreen.DrawRectangle(Color.White, outlineWidth, 0, yoffset,
                                     rectangleWidth, rectangleHeight, 0, 0, Color.FromArgb(255, 0, 0),
                                     0, yoffset,
                                     Color.FromArgb(1, 0, 0),
                                     rectangleWidth, rectangleHeight, 255);
            // green gradient
            yoffset += (rectangleHeight + 2*outlineWidth);
            fullScreen.DrawRectangle(Color.White, outlineWidth, 0, yoffset,
                                     rectangleWidth, rectangleHeight, 0, 0, Color.FromArgb(0, 255, 0),
                                     0, yoffset,
                                     Color.FromArgb(0, 1, 0),
                                     rectangleWidth, rectangleHeight, 255);

            // blue gradient
            yoffset += (rectangleHeight + 2*outlineWidth);
            fullScreen.DrawRectangle(Color.White, outlineWidth, 0, yoffset,
                                     rectangleWidth, rectangleHeight, 0, 0, Color.FromArgb(0, 0x81, 0xC8),
                                     0, yoffset,
                                     Color.FromArgb(0, 0, 1),
                                     rectangleWidth, rectangleHeight, 255);
            // Olympic Rings
            fullScreen.FillRectangle(190, newsectionY, 130, 130, Color.White, 255);
            fullScreen.DrawEllipse(Color.FromArgb(0, 0x81, 0xC8), outlineWidth, 220, newsectionY + 30,
                                     20, 20, Color.Gray,
                                     10, 10,
                                     Color.Gray,
                                     15, 15, 255);

            fullScreen.DrawEllipse(Color.FromArgb(0, 0, 0), outlineWidth, 260, newsectionY + 30,
                                     20, 20, Color.Purple,
                                     10, 10,
                                     Color.Purple,
                                     15, 15, 255);

            fullScreen.DrawEllipse(Color.FromArgb(0xEE, 0x33, 0x4E), outlineWidth, 290, newsectionY + 30,
                                      20, 20, Color.Wheat,
                                      10, 10,
                                      Color.Wheat,
                                      15, 15, 255);
            fullScreen.DrawEllipse(Color.FromArgb(0xFC, 0xB1, 0x31), outlineWidth, 240, newsectionY + 60,
                                     20, 20, Color.Turquoise,
                                     10, 10,
                                     Color.Turquoise,
                                     15, 15, 255);

            fullScreen.DrawEllipse(Color.FromArgb(0, 0xA6, 0x51), outlineWidth, 270, newsectionY + 60,
                                     20, 20, Color.Salmon,
                                     10, 10,
                                      Color.Salmon,
                                     15, 15, 255);

            // Transparency
            Bitmap soccerBall = Resources.GetBitmap(Resources.BitmapResources.SoccerBall);
            // Make the background of the jupiter image transparent
            soccerBall.MakeTransparent(soccerBall.GetPixel(0, 0));
            fullScreen.DrawImage(225, 178, soccerBall, 0, 0, soccerBall.Width, soccerBall.Height, Bitmap.OpacityOpaque);

            // Transparency
            Bitmap Jupiter = Resources.GetBitmap(Resources.BitmapResources.Jupiter1);
            // Make the background of the jupiter image transparent
            Jupiter.MakeTransparent(Jupiter.GetPixel(0, 0));
            fullScreen.DrawImage(35, 150, Jupiter, 0, 0, Jupiter.Width, Jupiter.Height, Bitmap.OpacityOpaque);

            fullScreen.Flush();
            Thread.Sleep(2000);

            fullScreen.RotateImage(25, 35, 150, Jupiter, 0, 0, Jupiter.Width, Jupiter.Height, Bitmap.OpacityOpaque);
            fullScreen.Flush();
            Thread.Sleep(2000);

            fullScreen.RotateImage(50, 35, 150, Jupiter, 0, 0, Jupiter.Width, Jupiter.Height, Bitmap.OpacityOpaque);
            fullScreen.Flush();
            Thread.Sleep(2000);

            fullScreen.RotateImage(75, 35, 150, Jupiter, 0, 0, Jupiter.Width, Jupiter.Height, Bitmap.OpacityOpaque);
            fullScreen.Flush();

            for(int i=0;i<10;i++)
            {
                fullScreen.RotateImage(i*5, 225, 178, soccerBall, 0, 0, soccerBall.Width, soccerBall.Height, Bitmap.OpacityOpaque);
                Thread.Sleep(500);
                fullScreen.Flush();
            }

        }
        private static void BitmapFromBytesTest()
        {
            //  Bmp24Bit_RGB
            {
                Bitmap Bmp24Bit_ARGB = new Bitmap(ImageFromBytes.BitmapBytes24bitTest, Bitmap.BitmapImageType.Bmp);
                byte[] resultantBitmapData = Bmp24Bit_ARGB.GetBitmap();
                AssertBitmapIsRGB565(resultantBitmapData);
                Bmp24Bit_ARGB.Dispose();
            }

            //  Bmp8Bit_Indexed
            {
                Bitmap Bmp8Bit_ARGB = new Bitmap(ImageFromBytes.BitmapBytes8bitTest, Bitmap.BitmapImageType.Bmp);
                byte[] resultantBitmapData = Bmp8Bit_ARGB.GetBitmap();
                AssertBitmapIsRGB565(resultantBitmapData);
                Bmp8Bit_ARGB.Dispose();
            }
        }
        private static void AssertBitmapIsRGB565(byte[] resultantBitmapData)
        {
            Debug.Assert((short)((resultantBitmapData[1] << 8) & resultantBitmapData[0]) == ToRGB565(Color.DarkRed));
            Debug.Assert((short)((resultantBitmapData[3] << 8) & resultantBitmapData[2]) == ToRGB565(Color.Red));
            Debug.Assert((short)((resultantBitmapData[5] << 8) & resultantBitmapData[4]) == ToRGB565(Color.LightPink));
            Debug.Assert((short)((resultantBitmapData[7] << 8) & resultantBitmapData[6]) == ToRGB565(Color.LightGreen));
            Debug.Assert((short)((resultantBitmapData[9] << 8) & resultantBitmapData[8]) == ToRGB565(Color.Green));
            Debug.Assert((short)((resultantBitmapData[11] << 8) & resultantBitmapData[10]) == ToRGB565(Color.DarkGreen));
            Debug.Assert((short)((resultantBitmapData[13] << 8) & resultantBitmapData[12]) == ToRGB565(Color.LightBlue));
            Debug.Assert((short)((resultantBitmapData[15] << 8) & resultantBitmapData[14]) == ToRGB565(Color.Blue));
            Debug.Assert((short)((resultantBitmapData[17] << 8) & resultantBitmapData[16]) == ToRGB565(Color.DarkBlue));
        }
        private static long ARGB_TO_RGB565_TO_ARGB(Color color)
        {
            // Convert ARGB colour to RGB565
            // Note: we lose some bits
            // Lower 3 bits of the red
            // Lower 2 bits of the green
            // Lower 3 bits of the blue

            UInt32 ARGB_Value = (UInt32)color.ToArgb();

            UInt32 Color_RGB565 = ((((ARGB_Value & 0xFF0000) >> 16) >> 3) <<11) | ((((ARGB_Value & 0x00FF00) >> 8) >> 2) << 5) | ((ARGB_Value & 0x0000FF) >> 3);
            // Convert the RGB565 to ARGB
            // Note: Some colours are exact,
            //       other colours are an approximation due to the
            //       loss of bits in the conversion
            //
            // Algorithm sets lower bits if condition met
            // Not sure if this is a good algorithm
            // This is the original .NetMF algorithm

            long ARGB_Red = ((Color_RGB565 & 0b1111100000000000) >> 11) << 3;
            if ((ARGB_Red & 0x8) != 0)
                ARGB_Red |= 0x7; // Copy LSB
            long ARGB_Green = ((Color_RGB565 & 0b0000011111100000) >> 5) << 2;
            if ((ARGB_Green & 0x4) != 0)
                ARGB_Green |= 0x3; // Copy LSB
            long ARGB_Blue = (Color_RGB565 & 0b0000000000011111) << 3;
            if ((ARGB_Blue & 0x8) != 0)
                ARGB_Blue |= 0x7; // Copy LSB
            long opaque = 0xFF000000;

            long ARGB_Converted = (ARGB_Red << 16) | (ARGB_Green << 8) | ARGB_Blue |opaque;
            return ARGB_Converted;
        }
        private static void JPegTest(byte[] expectedDataReturned)
        {
            Bitmap JpegColourTest = Resources.GetBitmap(Resources.BitmapResources.JpegTest);
            // Returned as a ARGB bitmap
            byte[] resultantBitmapData = JpegColourTest.GetBitmap();
            Debug.Assert(resultantBitmapData.Length == expectedDataReturned.Length);
            for (int i = 0; i < expectedDataReturned.Length; i++)
            {
                Debug.Assert(resultantBitmapData[i] == expectedDataReturned[i]);
            }
        }
        private static void GifTest(byte[] expectedDataReturned)
        {
            Bitmap GifColourTest = Resources.GetBitmap(Resources.BitmapResources.JpegTest);
            // Returned as a ARGB bitmap
            byte[] resultantBitmapData = GifColourTest.GetBitmap();
            Debug.Assert(resultantBitmapData.Length == expectedDataReturned.Length);
            for (int i = 0; i < expectedDataReturned.Length; i++)
            {
                Debug.Assert(resultantBitmapData[i] == expectedDataReturned[i]);
            }
        }
        private static void BitmapFromEmbeddedResourceTest(byte[] expectedDataReturned)
        {
            {
                Bitmap Bitmap24bitTest = Resources.GetBitmap(Resources.BitmapResources.Bitmap24bitTest);
                byte[] resultantBitmapData = Bitmap24bitTest.GetBitmap();
                Debug.Assert(resultantBitmapData.Length == expectedDataReturned.Length);
                for (int i = 0; i < expectedDataReturned.Length; i++)
                {
                    Debug.Assert(resultantBitmapData[i] == expectedDataReturned[i]);
                }
                Bitmap24bitTest.Dispose();
            }
            {
                Bitmap Bitmap8bitTest = Resources.GetBitmap(Resources.BitmapResources.Bitmap8bitTest);
                byte[] resultantBitmapData = Bitmap8bitTest.GetBitmap();
                Debug.Assert(resultantBitmapData.Length == expectedDataReturned.Length);
                for (int i = 0; i < expectedDataReturned.Length; i++)
                {
                    Debug.Assert(resultantBitmapData[i] == expectedDataReturned[i]);
                }
                Bitmap8bitTest.Dispose();
            }
        }
        private static short ToRGB565(Color color)
        {
            byte Red5bits = (byte)(color.R & 0b11111000);
            byte Green6bits = (byte)(color.G & 0b11111100);
            byte Blue5bits = (byte)(color.B & 0b11111000);
            short RGB565 = (short)((Red5bits << 16) & (Green6bits << 8) & Blue5bits);
            return RGB565;
        }
    }
    struct BitmapAndName
    {
        public string name;
        public Bitmap bitmap;
    }
}

