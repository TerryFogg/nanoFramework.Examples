﻿using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System.Drawing;

namespace nf_simpleTouchDisplay
{
    public class ApplicationMain : Application
    {
        static ApplicationMain myApplication;
        //private WindowTouchButtons touchButtonWindow;
        private static WindowInkDrawing windowInkDrawing;

        public static void Start()
        {
            myApplication = new ApplicationMain();
            Touch.Initialize(myApplication);

            // Window mainWindow = myApplication.CreateInkDrawingWindow();
            // Window touchButtonWindow = myApplication.CreateTouchButtonsWindow();
            CreateInkDrawingWindow();
            //     myApplication.Run(mainWindow);
            myApplication.Run(windowInkDrawing);
        }

        public static Window CreateInkDrawingWindow()
        {
            // Create a window object and set its size to the size of the 
            // display.
            windowInkDrawing = new WindowInkDrawing();
            windowInkDrawing.Height = DisplayControl.ScreenHeight;
            windowInkDrawing.Width = DisplayControl.ScreenWidth;

            // Set the window visibility to Visible.
            windowInkDrawing.Visibility = Visibility.Visible;

            // Attach the button focus to the window.
            Buttons.Focus(windowInkDrawing);

            return windowInkDrawing;
        }

        /// <summary>
        /// Main window class, based on the standard Window.
        /// </summary>
        public class WindowInkDrawing : Window
        {
            SolidColorBrush brush = new SolidColorBrush(Color.Black);
            Pen pen = new Pen(Color.FromArgb(255, 0, 0));
            Pen pen2 = new Pen(Color.FromArgb(0, 0, 255));
            Text text = new Text();
            Panel panel = new Panel();
            ListBox lb = new ListBox();

            /// <summary>
            /// The default constructor.
            /// </summary>
            public WindowInkDrawing()
            {
                this.Background = new SolidColorBrush(Color.ForestGreen);
                text.Font = Resources.GetFont(Resources.FontResources.small);
                text.TextContent = "    Click Anywhere   ";
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;

                // Add the text control to the window.
                this.Child = panel;
                panel.Children.Add(text);
            }

            // Structure to hold a point.
            struct point
            {
                public ushort x;
                public ushort y;
            }

            // Create 50 points.
            const int pointCount = 50;
            point[] Points = new point[pointCount];
            int pointIndex = 0;

            int cx = 0;
            int cy = 0;
            int r = 6;
            bool drawCircle = false;

            /// <summary>
            /// Helper function to add points to the array and invalidate the 
            /// appropriate rectangle.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            void AddPoint(int x, int y)
            {
                Points[pointIndex].x = (ushort)x;
                Points[pointIndex].y = (ushort)y;
                pointIndex = (pointIndex + 1) % pointCount;

                if (pointIndex > 1)
                {
                    int x0, y0, x1, y1, t;
                    x0 = Points[pointIndex - 2].x;
                    y0 = Points[pointIndex - 2].y;
                    x1 = Points[pointIndex - 1].x;
                    y1 = Points[pointIndex - 1].y;
                    if (x1 < x0) { t = x0; x0 = x1; x1 = t; }
                    if (y1 < y0) { t = y0; y0 = y1; y1 = t; }
                    x1 = x1 - x0 + 1;
                    y1 = y1 - y0 + 1;
                    if (x1 > 0 && y1 > 0)
                    {
                        InvalidateRect(x0, y0, x1, y1);
                    }
                }
            }

            /// <summary>
            /// Handles the touch down event.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnTouchDown(TouchEventArgs e)
            {
                base.OnTouchDown(e);

                // Start at the beginning of the array and set the flag to draw 
                // a circle.
                pointIndex = 0;
                drawCircle = true;

                int x;
                int y;

                e.GetPosition((UIElement)this, 0, out x, out y);

                cx = x;
                cy = y;

                // Add the first point to the array.
                AddPoint(x, y);

                r = 10;

                // Change the text to show touch down and location.
                text.TextContent = "TouchDown (" + x.ToString() + "," +
                    y.ToString() + ")";

                // Clear the entire screen because we've erased the previous 
                // line (if any).
                Invalidate();

                e.Handled = true;
            }

            /// <summary>
            /// Handles the touch up event.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnTouchUp(TouchEventArgs e)
            {
                base.OnTouchUp(e);

                // Set the flag to draw a circle.
                drawCircle = true;
                int x;
                int y;

                e.GetPosition((UIElement)this, 0, out x, out y);

                cx = x;
                cy = y;

                // Add the last point to the array.
                AddPoint(x, y);

                r = 6;

                // Change the text to show touch up and location.
                text.TextContent = "TouchUp (" + x.ToString() + "," +  y.ToString() + ")";

                InvalidateRect(cx - r, cy - r, 2 * r, 2 * r);
            }

            /// <summary>
            /// Handles the touch move event.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnTouchMove(TouchEventArgs e)
            {
                base.OnTouchMove(e);

                int x = 0;
                int y = 0;

                e.GetPosition((UIElement)this, 0, out x, out y);

                // Add this point to the array.
                AddPoint(x, y);

                text.TextContent = "TouchMove (" + x.ToString() + "," + y.ToString() + ")";
            }

            /// <summary>
            /// Handles the render event.
            /// </summary>
            /// <param name="dc"></param>
            public override void OnRender(DrawingContext dc)
            {
                base.OnRender(dc);

                // If the flag is set, draw a circle.
                if (drawCircle)
                {
                    dc.DrawEllipse(brush, pen, cx, cy, r, r);
                }

                // If we have some points, draw lines between them to make a 
                // complete path.
                if (pointIndex > 1)
                {
                    for (int i = 1; i < pointIndex; i++)
                    {
                        dc.DrawLine(pen2, Points[i - 1].x, Points[i - 1].y,
                            Points[i].x, Points[i].y);
                    }
                }
            }
        }
    }
}
