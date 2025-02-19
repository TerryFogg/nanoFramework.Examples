using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;
using System.Diagnostics;
using System.Drawing;

namespace TouchExample1
{
    public class Program : Application
    {
        public static void Main()
        {
            Program myApplication = new Program();

            Window mainWindow = myApplication.CreateWindow();

            try
            {
                Touch.Initialize(myApplication);
            }
            catch (NotSupportedException)
            {
                Debug.WriteLine("Touch displays not supported on the device.");
            }

            // Start the application
            myApplication.Run(mainWindow);
        }

        private Window mainWindow;

        public Window CreateWindow()
        {
            // Create a window object and set its size to the
            // size of the display.
            mainWindow = new Window();
            mainWindow.Height = DisplayControl.ScreenHeight;
            mainWindow.Width = DisplayControl.ScreenWidth;

            // Create a single text control.
            Text text = new Text();
            text.Font = Resources.GetFont(Resources.FontResources.small);
            text.TextContent = "Touch me!";
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;

            // Subscribe to touch events
            text.TouchDown+=Text_TouchDown;
            text.TouchMove+=Text_TouchMove;
            text.TouchUp +=Text_TouchUp;

            // Add the text control to the window.
            mainWindow.Child = text;

            // Set the window visibility to visible.
            mainWindow.Visibility = Visibility.Visible;

            return mainWindow;
        }
        private void Text_TouchDown(object sender, TouchEventArgs e)
        {
            Text txt = (Text)sender;
            TouchCapture.Capture(txt, TouchCaptureMode.Element);
            int xrel, yrel;
            int touchIndex=0;
            e.GetPosition(txt, touchIndex,out xrel, out yrel);
            txt.TextContent = "Down, screen={" + e.Touches[0].X + "," + e.Touches[0].Y + "}, relative={" + xrel + "," + yrel + "}";
        }
        private void Text_TouchMove(object sender, TouchEventArgs e)
        {
            Text txt = (Text)sender;
            int xrel, yrel;
            int touchIndex = 0;
            e.GetPosition(txt, touchIndex,out xrel, out yrel);
            txt.TextContent = "Move, screen={" + e.Touches[0].X + "," + e.Touches[0].Y + "}, relative={" + xrel + "," + yrel + "}";
        }
        private void Text_TouchUp(object sender, TouchEventArgs e)
        {
            Text txt = (Text)sender;
            TouchCapture.Capture(txt, TouchCaptureMode.None);
            int xrel, yrel;
            int touchIndex = 0;
            e.GetPosition(txt, touchIndex,out xrel, out yrel);
            txt.TextContent = "Up, screen={" + e.Touches[0].X + "," + e.Touches[0].Y + "}, relative={" + xrel + "," + yrel + "}";
        }
    }
}
