using System;
using System.Diagnostics;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;

namespace nf_nPF_example1
{
    public class MessagePager
    {
        static int ScreenWidth = 240;
        static int ScreenHeight = 135;

        private string messageString = null;
        private Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
        private int relX = 0;
        private int relY = 0;
        private Font messageFont = Resources.GetFont(Resources.FontResources.ninab);
        public bool ShowMessagePage()
        {
            if (messageString == null)
            {
                return true;
            }
            myBitmap.DrawRectangle(Color.Black, 1, 20, 20, 150, 150, 0, 0, Color.Black, 0, 0, Color.Black, 150, 150, 0xff);
            relX = 0;
            relY = 0;
            bool result = myBitmap.DrawTextInRect(ref messageString, ref relX, ref relY, 20, 20, 150, 150, 1, Color.White, messageFont);
            myBitmap.Flush();
            return result;
        }
        public bool StartMessage(string message)
        {
            messageString = message;
            return ShowMessagePage();
        }
    }
    public class BitmapDemo : Application
    {
        static int ScreenWidth = 240;
        static int ScreenHeight = 135;
        private static void doPause()
        {
            System.Threading.Thread.Sleep(2000);
        }
        public static void Main()
        {
            {
                Debug.WriteLine("Simple Diagonal Line");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                myBitmap.DrawLine(Color.White, 1, 0, 0, myBitmap.Width, myBitmap.Height);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Twin Bitmaps");
                Bitmap b1 = new Bitmap(ScreenWidth, ScreenHeight);
                Bitmap b2 = new Bitmap(ScreenWidth, ScreenHeight);
                b1.DrawLine(Color.White, 1, 0, 0, ScreenWidth, ScreenHeight);
                b2.DrawLine(Color.White, 1, 0, ScreenHeight, ScreenWidth, 0);
                b1.Flush();
                b2.Flush(120, 80, 80, 80);
            }
            doPause();
            {
                Debug.WriteLine("Simple Text");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                Font myFont = Resources.GetFont(Resources.FontResources.ninab);
                myBitmap.DrawText("Hello World", myFont, Color.White, 10, 10);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Draw Rectangle");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                myBitmap.DrawRectangle(Color.White, 1, 100, 100, 200, 100, 0, 0, Color.Black, 100, 100, Color.White, 300, 200, 0xff);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Demonstrate Opacity");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                myBitmap.DrawRectangle(Color.White, 1, 0, 0, myBitmap.Width, myBitmap.Height, 0, 0, Color.White, 0, 0, Color.White, myBitmap.Width, myBitmap.Height, 0xff);
                myBitmap.DrawRectangle(Color.Red, 0, 10, 10, 200, 100, 0, 0, Color.Red, 10, 10, Color.Red, 210, 110, 0x80);
                myBitmap.DrawRectangle(Color.Blue, 0, 30, 30, 200, 100, 0, 0, Color.Blue, 100, 100, Color.Blue, 300, 200, 0x80);
                myBitmap.DrawRectangle(Color.Green, 0, 60, 60, 200, 100, 0, 0, Color.Green, 100, 100, Color.Green, 300, 200, 0x80);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Show rounded corners");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                myBitmap.DrawRectangle(Color.White, 1, 100, 100, 200, 100, 20, 10, Color.White, 100, 100, Color.White, 300, 200, 0xff);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Draw Image");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                Bitmap snowflake = Resources.GetBitmap(Resources.BitmapResources.MFsnowflake);
                myBitmap.DrawImage(10, 10, snowflake, 0, 0, snowflake.Width, snowflake.Height, 0xff);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Image Stretch");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                Bitmap snowflake = Resources.GetBitmap(Resources.BitmapResources.MFsnowflake);
                myBitmap.StretchImage(10, 10, snowflake, 200, 100, 0xff);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Elipse Drawing");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                myBitmap.DrawEllipse(Color.White, 10, 100, 100, 50, 50, Color.White, 50, 100, Color.White, 150, 100, 0xff);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Text Cropping");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                Font myFont = Resources.GetFont(Resources.FontResources.ninab);
                myBitmap.DrawText("Hello World. This is very long text which I'm pretty sure won't fit on the display. Ho ho.", myFont, Color.Blue, 0, 0);
                myBitmap.Flush();
            }
            doPause();
            // ShowStyles
            {
                Debug.WriteLine("Text Style Preview");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                for (int style = 0; style < 4; style++)
                {
                    Debug.WriteLine(" Style : " + style.ToString());
                    myBitmap.DrawRectangle(Color.White, 1, 0, 0, myBitmap.Width, myBitmap.Height, 0, 0, Color.White, 0, 0, Color.White, myBitmap.Width, myBitmap.Height, 0xff);
                    myBitmap.DrawRectangle(Color.Black, 1, 20, 20, 150, 150, 0, 0, Color.Black, 0, 0, Color.Black, 150, 150, 0xff);
                    Font myFont = Resources.GetFont(Resources.FontResources.ninab);
                    myBitmap.DrawTextInRect("Jackdaws love my big sphinx of quartz.", 20, 20, 150, 150, (uint)style, Color.White, myFont);
                    myBitmap.Flush();
                    System.Threading.Thread.Sleep(1000);
                }
            }
            doPause();
            {
                Debug.WriteLine("Draw text in rectangle");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                myBitmap.DrawRectangle(Color.White, 1, 0, 0, myBitmap.Width, myBitmap.Height, 0, 0, Color.White, 0, 0, Color.White, myBitmap.Width, myBitmap.Height, 0xff);
                myBitmap.DrawRectangle(Color.Black, 1, 20, 20, 150, 150, 0, 0, Color.Black, 0, 0, Color.Black, 150, 150, 0xff);
                Font myFont = Resources.GetFont(Resources.FontResources.ninab);
                int relX = 0;
                int relY = 0;
                string message = "The quick brown fox jumps over the lazy dog. Jackdaws love my big sphinx of quartz." +
                                 "The quick brown fox jumps over the lazy dog. Jackdaws love my big sphinx of quartz." +
                                 "The quick brown fox jumps over the lazy dog. Jackdaws love my big sphinx of quartz.";
                bool result = myBitmap.DrawTextInRect(ref message, ref relX, ref relY, 20, 20, 150, 150, 1, Color.White, myFont);
                myBitmap.Flush();
            }
            doPause();
            {
                Debug.WriteLine("Paged display of text");
                MessagePager pager = new MessagePager();
                pager.StartMessage("Many small footprint devices have no need for complex displays. " +
                                    "They can present perfectly useable interfaces by means of " +
                                    "individual LED lights or simple single digit outputs. However, " +
                                    "an increasing number of devices now have a need for more complex " +
                                    "user interactions which can only be met by more detailed text and " +
                                    "graphical displays.");
                do
                {
                    System.Threading.Thread.Sleep(2000);
                } while (pager.ShowMessagePage() == false);
            }
            doPause();
            {
                Debug.WriteLine("Text in different Color");
                Bitmap myBitmap = new Bitmap(ScreenWidth, ScreenHeight);
                Font messageFont = Resources.GetFont(Resources.FontResources.ninab);
                myBitmap.DrawRectangle(Color.White, 1, 0, 0, myBitmap.Width, myBitmap.Height, 0, 0, Color.White, 0, 0, Color.White, myBitmap.Width, myBitmap.Height, 0xff);
                myBitmap.DrawRectangle(Color.Black, 1, 20, 20, 150, 150, 0, 0, Color.Black, 0, 0, Color.Black, 150, 150, 0xff);
                string str = "hello ";
                int x = 0;
                int y = 0;
                myBitmap.DrawTextInRect(ref str, ref x, ref y, 20, 20, 150, 150, 1, Color.White, messageFont);
                str = "world";
                myBitmap.DrawTextInRect(ref str, ref x, ref y, 20, 20, 150, 150, 1, Color.Red, messageFont);
                myBitmap.Flush();
            }
            doPause();
        }
    }
}