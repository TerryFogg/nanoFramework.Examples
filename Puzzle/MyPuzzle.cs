using nanoFramework.Presentation;
using nanoFramework.Presentation.Controls;
using nanoFramework.UI;
using nanoFramework.UI.Input;
using System;

namespace Puzzle
{
    /// <summary>
    /// Puzzle demonstrating a touch panel.
    /// </summary>
    public class MyPuzzle : Application
    {
        /// <summary>
        /// The main window class, based on the standard Window.
        /// </summary>
        protected class MyWindow : Window
        {
            Panel panel = new Panel();
            PuzzleBoard puzzleBoard = null;
            Button button = null;
            Button button2 = null;
            Text text = null;

            /// <summary>
            /// The default constructor.
            /// </summary>
            public MyWindow()
            {
                int screenWidth = DisplayControl.ScreenWidth;
                int screenHeight = DisplayControl.ScreenHeight;

                // Create the puzzle board.  Default to square, because all of 
                // the images fit in a square.
                puzzleBoard = new PuzzleBoard(240, 240);
                puzzleBoard.TouchGestureChanged +=  new TouchGestureEventHandler(puzzleBoard_Gesture);

                // Create the Reset button.
                button = new Button("Reset", Resources.GetFont(Resources.FontResources.small));
                button.HorizontalAlignment = HorizontalAlignment.Right;
                button.VerticalAlignment = VerticalAlignment.Top;
                button.Click += new EventHandler(button_Click);

                // Create the Solve button.
                button2 = new Button("Solve", Resources.GetFont(Resources.FontResources.small));
                button2.HorizontalAlignment = HorizontalAlignment.Right;
                button2.VerticalAlignment = VerticalAlignment.Center;
                button2.Click += new EventHandler(button2_Click);

                if (screenWidth < screenHeight)
                {
                    button.HorizontalAlignment = HorizontalAlignment.Left;
                    button.VerticalAlignment = VerticalAlignment.Bottom;

                    button2.HorizontalAlignment = HorizontalAlignment.Center;
                    button2.VerticalAlignment = VerticalAlignment.Bottom;
                }

                // Create a text element to display the action the user just 
                // performed.
                text = new Text();
                text.Font = Resources.GetFont(Resources.FontResources.small);
                text.TextContent = " ";
                text.HorizontalAlignment =HorizontalAlignment.Right;
                text.VerticalAlignment = VerticalAlignment.Bottom;

                // Add a panel to hold the other controls.
                this.Child = panel;

                // Add the puzzle, buttons and text controls to the panel.
                panel.Children.Add(puzzleBoard);
                panel.Children.Add(button);
                panel.Children.Add(button2);
                panel.Children.Add(text);

                //// Set the drawing attributes to a default set.
                //DrawingAttributes da = new DrawingAttributes();
                //puzzleBoard.DefaultDrawingAttributes = da;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void puzzleBoard_Gesture(object sender, TouchGestureEventArgs e)
            {
                string gesture = "Unknown";

                switch (e.Gesture)
                {
                    case TouchGesture.Right:
                        gesture = "Right";
                        break;
                    case TouchGesture.UpRight:
                        gesture = "UpRight";
                        break;
                    case TouchGesture.Up:
                        gesture = "Up";
                        break;
                    case TouchGesture.UpLeft:
                        gesture = "UpLeft";
                        break;
                    case TouchGesture.Left:
                        gesture = "Left";
                        break;
                    case TouchGesture.DownLeft:
                        gesture = "DownLeft";
                        break;
                    case TouchGesture.Down:
                        gesture = "Down";
                        break;
                    case TouchGesture.DownRight:
                        gesture = "DownRight";
                        break;
                    case TouchGesture.Tap:
                        gesture = "Tap";
                        break;
                    case TouchGesture.DoubleTap:
                        gesture = "DoubleTap";
                        break;

                    case TouchGesture.Zoom:
                        gesture = "Zoom";
                        break;
                    case TouchGesture.Pan:
                        gesture = "Pan";
                        break;
                    case TouchGesture.Rotate:
                        gesture = "Rotate: " + e.Angle.ToString();
                        break;
                    case TouchGesture.TwoFingerTap:
                        gesture = "TwoFingerTap";
                        break;
                    case TouchGesture.Rollover:
                        gesture = "Rollover";
                        break;
                }

                text.TextContent = gesture;
            }

            /// <summary>
            /// Handles the Reset button click.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void button_Click(object sender, EventArgs e)
            {
                puzzleBoard.Reset();
            }

            /// <summary>
            /// Handles the Solve button click.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void button2_Click(object sender, EventArgs e)
            {
                puzzleBoard.Solve();
            }
        }


        /// <summary>
        /// The executable entry point.
        /// </summary>

        private MyWindow mainWindow;

        /// <summary>
        /// Create a window with button focus.
        /// </summary>
        /// <returns></returns>
        public Window CreateWindow()
        {
            /// Create a window and set its size to the size of the display.
            mainWindow = new MyWindow();
            mainWindow.Height = DisplayControl.ScreenHeight;
            mainWindow.Width = DisplayControl.ScreenWidth;

            // Set the window visibility to visible.
            mainWindow.Visibility = Visibility.Visible;

            // Attach the button focus to the window.
            Buttons.Focus(mainWindow);

            return mainWindow;
        }
    }
}
