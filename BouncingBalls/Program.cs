using BouncingBalls;
using nanoFramework.Presentation.Media;
using nanoFramework.UI;
using System;
using System.Drawing;

namespace nf_BouncingBalls
{
    public class Program
    {
        public static void Main()
        {
            Bitmap fullScreenBitmap = new Bitmap(240, 135);
        //    Bitmap fullScreenBitmap = new Bitmap(480, 272);
            //DisplayControl.FullScreen;
            fullScreenBitmap.Clear();
            BouncingBalls bb = new BouncingBalls(fullScreenBitmap);
        }

        public class BouncingBalls
        {
            Bitmap soccerBall { get; set; }
            Bitmap AFLFootball { get; set; }

            struct Rectangle
            {
                public int X;
                public int Y;
                public int Width;
                public int Height;
                public Rectangle(int x, int y, int width, int height)
                {
                    this.X = x;
                    this.Y = y;
                    this.Width = width;
                    this.Height = height;
                }
            }
            struct Point { public int X; public int Y; };
            private Rectangle[] BallLocation;
            private Point[] BallVelocity;
            private Bitmap ScreenBitmap { get; set; }

            public BouncingBalls(Bitmap fullScreenBitmap)
            {

                ScreenBitmap = fullScreenBitmap;
                
                soccerBall = Resources.GetBitmap(Resources.BitmapResources.SoccerBall);
                // Make the background of the soccer ball transparent
                soccerBall.MakeTransparent(soccerBall.GetPixel(0, 0));

                AFLFootball = Resources.GetBitmap(Resources.BitmapResources.Football);
                // Make the background of the Football ball transparent
                AFLFootball.MakeTransparent(AFLFootball.GetPixel(0, 0));


                SetupBalls(soccerBall);

                while (true)
                {
                    MoveBalls();
                    DrawGifBall(soccerBall);
                }
            }
            private void SetupBalls(Bitmap gifBall)
            {
                Random rand = new Random();
                const int num_balls = 12;
                int vx = 0;
                int vy = 0;

                BallLocation = new Rectangle[num_balls];
                BallVelocity = new Point[num_balls];

                Random r = new Random();
                int Width = gifBall.Width;
                int Height = gifBall.Height;
                Double ballScale = r.NextDouble();

                for (int iBall = 0; iBall < num_balls; iBall++)
                {
                    ballScale = r.NextDouble();
                    BallLocation[iBall] = new Rectangle
                    {
                        X = rand.Next(0, ScreenBitmap.Width - 2 * Width),
                        Y = rand.Next(0, ScreenBitmap.Height - 2 * Height),
                        Width = (int)(gifBall.Width * ballScale),
                        Height = (int)(gifBall.Height * ballScale)
                };
                //// Setup 1/2 the balls with different speeds
                //if (iBall % 2 == 0)
                //{
                    vx = rand.Next(2, 8);
                    vy = rand.Next(2, 8);
                //}
                //else
                //{
                //    vx = rand.Next(12, 25);
                //    vy = rand.Next(12, 25);
                //}
                // Setup random directions
                if (rand.Next(0, 2) == 0) vx = -vx;
                if (rand.Next(0, 2) == 0) vy = -vy;
                BallVelocity[iBall] = new Point { X = vx, Y = vy };
            }
        }
        private void MoveBalls()
        {
            for (int ball_num = 0;
                ball_num < BallLocation.Length;
                ball_num++)
            {
                // Move the ball.
                int new_x = BallLocation[ball_num].X + BallVelocity[ball_num].X;
                int new_y = BallLocation[ball_num].Y + BallVelocity[ball_num].Y;
                if (new_x < 0)
                {
                    BallVelocity[ball_num].X = -BallVelocity[ball_num].X;
                }
                else if (new_x + BallLocation[ball_num].Width > ScreenBitmap.Width)
                {
                    BallVelocity[ball_num].X = -BallVelocity[ball_num].X;
                }
                if (new_y < 0)
                {
                    BallVelocity[ball_num].Y = -BallVelocity[ball_num].Y;
                }
                else if (new_y + BallLocation[ball_num].Height > ScreenBitmap.Height)
                {
                    BallVelocity[ball_num].Y = -BallVelocity[ball_num].Y;
                }
                BallLocation[ball_num] = new Rectangle(new_x, new_y, BallLocation[ball_num].Width, BallLocation[ball_num].Height);
            }
        }
        private void DrawGifBall(Bitmap gifBall)
        {
            ScreenBitmap.Clear();
            for (int i = 0; i < BallLocation.Length; i++)
            {
                ScreenBitmap.StretchImage(BallLocation[i].X, BallLocation[i].Y, gifBall, BallLocation[i].Width, BallLocation[i].Height, Bitmap.OpacityOpaque);
            }
            ScreenBitmap.Flush();

        }
    }
}
}