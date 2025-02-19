using nanoFramework.Presentation.Controls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI.Threading;
using nanoFramework.UI;
using Puzzle;
using System;
using System.Drawing;
using System.Diagnostics;
using nanoFramework.Presentation;
using nanoFramework.UI.Input;

namespace Puzzle
{
    class PuzzleBoard : Canvas
    {
        Pen pen = new Pen(Color.FromArgb(0, 0, 0), 2);
        Bitmap[] _blockBitmap = new Bitmap[9];
        private DispatcherTimer _animationTimer;

        int blockDimension = 0;
        int[] _blocks = new int[9];

        /// <summary>
        /// Constructs a PuzzleBoard with the specified settings.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public PuzzleBoard(int width, int height)
        //   : base(0, 0, width, height)
        {
            blockDimension = (width > height ? height : width) / 3;

            // Use native collection and only look for gestures.
            TouchCollectorConfiguration.CollectionMethod = CollectionMethod.Native;
            TouchCollectorConfiguration.CollectionMode = CollectionMode.InkAndGesture;

            // Load all of the puzzle images.
            _blockBitmap[0] = Resources.GetBitmap(Resources.BitmapResources.b1);
            _blockBitmap[1] = Resources.GetBitmap(Resources.BitmapResources.b2);
            _blockBitmap[2] = Resources.GetBitmap(Resources.BitmapResources.b3);
            _blockBitmap[3] = Resources.GetBitmap(Resources.BitmapResources.b4);
            _blockBitmap[4] = Resources.GetBitmap(Resources.BitmapResources.b5);
            _blockBitmap[5] = Resources.GetBitmap(Resources.BitmapResources.b6);
            _blockBitmap[6] = Resources.GetBitmap(Resources.BitmapResources.b7);
            _blockBitmap[7] = Resources.GetBitmap(Resources.BitmapResources.b8);
            _blockBitmap[8] = Resources.GetBitmap(Resources.BitmapResources.b9);

            // Set up the animation timer.
            _animationTimer = new DispatcherTimer(this.Dispatcher);
            _animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            _animationTimer.Tick += new EventHandler(AnimationTimer_Tick);

            Reset();
        }

        /// <summary>
        /// Handles the animation timer tick.
        /// </summary>
        int _animationStep = 0;
        void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_animationStep >= 10)
            {
                _animationTimer.Stop();
            }
            else
            {
                _animationStep++;
                Invalidate();
            }
        }

        // Offset amounts for animation.  These values can be used to change 
        // the X or Y location.  See below for usage.
        int[] anim1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] anim2 = new int[] { -5, 0, 5, 0, -5, 0, 5, 0, -5, 0 };
        int[] anim3 = new int[] { 80, 74, 68, 58, 48, 36, 23, 12, 5, 0 };
        int[] anim4 = new int[] { -80, -74, -68, -58, -48, -36, -23, -12, -5, 0 };
        int[] anim5 = new int[] { 2, 6, 11, 15, 16, 15, 11, 6, 2, 0 };
        int[] anim6 = new int[] { -2, -6, -11, -15, -16, -15, -11, -6, -2, 0 };

        int[] activeAnimX = null;
        int[] activeAnimY = null;
        int _animationTargetBlock = -1;

        /// <summary>
        /// Handles gesture animation.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTouchGestureChanged(TouchGestureEventArgs e)
        {
            // Find the affected block.
            int x = e.X;
            int y = e.Y;
            int c = x / blockDimension;
            int r = y / blockDimension;
            int b = c + r * 3;

            int nc = c;
            int nr = r;

            int[] altAnimX = null;
            int[] altAnimY = null;

            _animationTargetBlock = b;

            // The gesture event tells us what direction the user gestured.
            // Based on the gesture, use the animation offset arrays to move 
            // the block to the appropriate location.
            switch (e.Gesture)
            {
                case TouchGesture.Left:
                    {
                        nc = nc - 1;

                        activeAnimX = anim3;
                        activeAnimY = anim1;

                        altAnimX = anim6;
                        altAnimY = anim1;

                        break;
                    }
                case TouchGesture.Right:
                    {
                        nc = nc + 1;

                        activeAnimX = anim4;
                        activeAnimY = anim1;

                        altAnimX = anim5;
                        altAnimY = anim1;

                        break;
                    }
                case TouchGesture.Up:
                    {
                        nr = nr - 1;

                        activeAnimX = anim1;
                        activeAnimY = anim3;

                        altAnimX = anim1;
                        altAnimY = anim6;

                        break;
                    }
                case TouchGesture.Down:
                    {
                        nr = nr + 1;

                        activeAnimX = anim1;
                        activeAnimY = anim4;

                        altAnimX = anim1;
                        altAnimY = anim5;

                        break;
                    }
                case TouchGesture.UpLeft:
                    {
                        nc = -1;
                        nr = -1;

                        activeAnimX = anim6;
                        activeAnimY = anim6;

                        break;
                    }
                case TouchGesture.UpRight:
                    {
                        nc = -1;
                        nr = -1;

                        activeAnimX = anim5;
                        activeAnimY = anim6;

                        break;
                    }
                case TouchGesture.DownLeft:
                    {
                        nc = -1;
                        nr = -1;

                        activeAnimX = anim6;
                        activeAnimY = anim5;

                        break;
                    }
                case TouchGesture.DownRight:
                    {
                        nc = -1;
                        nr = -1;

                        activeAnimX = anim5;
                        activeAnimY = anim5;

                        break;
                    }

                default:
                    {
                        nc = -1;
                        nr = -1;

                        activeAnimX = anim2;
                        activeAnimY = anim1;

                        break;
                    }
            }

            // Verify that the target block location is empty.
            if ((nc >= 0) && (nc < 3) && (nr >= 0) && (nr < 3))
            {
                int nb = nc + nr * 3;
                Debug.WriteLine($"blocks[nb] {_blocks[nb]}");

                if (_blocks[nb] == 8)
                {
                    /// Target location is empty.
                    _blocks[nb] = _blocks[b];
                    _blocks[b] = 8;

                    _animationTargetBlock = nb;
                }
                else
                {
                    Debug.WriteLine("else");
                    activeAnimX = altAnimX;
                    activeAnimY = altAnimY;
                }
            }
            else if (altAnimX != null)
            {
                Debug.WriteLine("else if (altAnimX != null)");
                activeAnimX = altAnimX;
                activeAnimY = altAnimY;
            }

            if (activeAnimX != null && activeAnimY != null)
            {
                Debug.WriteLine("if (activeAnimX != null && activeAnimY != null)");
                _animationStep = 0;
                _animationTimer.Start();
            }
            base.OnTouchGestureChanged(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="dc"></param>
        private void DrawBlock(int i, int x, int y, DrawingContext dc)
        {
            dc.DrawImage(_blockBitmap[i], x, y);
        }

        /// <summary>
        /// Handles the render event.
        /// </summary>
        /// <param name="dc"></param>
        public override void OnRender(DrawingContext dc)
        {
            // Loop through all the blocks except the animated block
            // and draw the associated bitmap.
            int i = 0;
            for (i = 0; i < 9; i++)
            {
                int x = (i % 3) * blockDimension;
                int y = (i / 3) * blockDimension;

                if (_animationTargetBlock != i)
                {
                    DrawBlock(_blocks[i], x, y, dc);
                }
            }

            // Draw the animated block if there is one.
            if (_animationTargetBlock >= 0)
            {
                lock (_blockBitmap)
                {
                    int x = (_animationTargetBlock % 3) * blockDimension;
                    int y = (_animationTargetBlock / 3) * blockDimension;

                    dc.DrawImage(_blockBitmap[8], x, y);

                    if (_animationStep < 9 && activeAnimX != null && activeAnimY != null)
                    {
                        x += activeAnimX[_animationStep];
                        y += activeAnimY[_animationStep];
                    }

                    DrawBlock(_blocks[_animationTargetBlock], x, y, dc);
                }
            }

            // Draw a rectangle box around the puzzle.
            dc.DrawLine(pen, 0, 0, 0, 239);
            dc.DrawLine(pen, 0, 0, 240, 0);
            dc.DrawLine(pen, 0, 239, 240, 239);
            dc.DrawLine(pen, 240, 0, 240, 239);
        }

        /// <summary>
        /// Put all of the blocks in the right place automatically for the 
        /// user.
        /// </summary>
        public void Solve()
        {
            int i = 0;
            for (i = 0; i < 9; i++)
            {
                _blocks[i] = i;
            }
            Invalidate();
        }

        /// <summary>
        /// Put all of the blocks in the starting locations.  This is always 
        /// the same, to make sure it is solvable.
        /// <para>
        /// A challenge for the reader would be to come up with an algorithm 
        /// to randomize the blocks in such a way that the puzzle is still 
        /// solvable.
        /// </para>
        /// </summary>
        public void Reset()
        {
            _blocks[0] = 3;
            _blocks[1] = 8;
            _blocks[2] = 0;
            _blocks[3] = 6;
            _blocks[4] = 2;
            _blocks[5] = 5;
            _blocks[6] = 1;
            _blocks[7] = 4;
            _blocks[8] = 7;
            Invalidate();
        }

        /// <summary>
        /// Handles the touch up event for the InkCanvas.
        /// </summary>
        /// <param name="e">The touch event arguments.</param>
        protected override void OnTouchUp(TouchEventArgs e)
        {
            Invalidate();
        }

    }
}
