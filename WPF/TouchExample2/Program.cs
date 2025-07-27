using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;
using System.Diagnostics;
using System.Drawing;

namespace TouchExample2
{
    public class Program : Application
    {
        private Bitmap lcd;

        public static void Main()
        {
            Program app = new Program();
            app.Run();
        }

        public Program()
        {
            this.lcd = new Bitmap(DisplayControl.ScreenWidth, DisplayControl.ScreenHeight);
            Touch.Initialize(this);
            this.MainWindow = new Window();
            this.MainWindow.TouchDown += MainWindow_TouchDown;
            this.MainWindow.TouchUp += MainWindow_TouchUp;
            this.MainWindow.TouchMove += MainWindow_TouchMove;

            this.MainWindow.TouchGestureChanged+=MainWindow_TouchGestureChanged;
        }

        private void MainWindow_TouchGestureChanged(object sender, TouchGestureEventArgs e)
        {
            switch (e.Gesture)
            {
                case TouchGesture.DownRight:
                    Debug.WriteLine("Down Right: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.Down:
                    Debug.WriteLine("Down: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.DownLeft:
                    Debug.WriteLine("Down Left: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.Left:
                    Debug.WriteLine("Left: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.UpLeft:
                    Debug.WriteLine("Up left: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.Up:
                    Debug.WriteLine("Up: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.UpRight:
                    Debug.WriteLine("Up Right: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;
                case TouchGesture.Right:
                    Debug.WriteLine("Right: (" + e.X.ToString() + ", " + e.Y.ToString() + ")");
                    break;

            }
        }

        private void MainWindow_TouchMove(object sender, TouchEventArgs e)
        {
            Debug.WriteLine("Touch move at (" + e.Touches[0].X.ToString() + ", " + e.Touches[0].Y.ToString() + ")");
        }
        private void MainWindow_TouchUp(object sender, TouchEventArgs e)
        {
            Debug.WriteLine("Touch up at (" + e.Touches[0].X.ToString() + ", " + e.Touches[0].Y.ToString() + ")");
        }
        private void MainWindow_TouchDown(object sender, TouchEventArgs e)
        {
            Debug.WriteLine("Touch down at (" + e.Touches[0].X.ToString() + ", " + e.Touches[0].Y.ToString() + ")");
        }
    }
}
