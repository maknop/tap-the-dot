using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;

namespace TapTheDot
{
    
    public partial class GameScreen : ContentPage
    {
       
        float randEnemy = 80;
        float currentRotation = 720;
        public static bool reverse = false;
        public static int score = 0;
        public static int tracker = 0;
        public static int level = 1;
        public static int speed = 1;
        public static int lives = 10;
        
        
        // create the paint for the filled circle
        SKPaint circleFill = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };

        // create the paint for the circle border
        SKPaint circleBorder = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 6,
            StrokeCap = SKStrokeCap.Round
        };

        SKPaint playerLine = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.DarkRed,
            StrokeWidth = 8,
            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
            // the strokeWidth is subject to the scale and transforms
            // antialias makes it look nice
        };

        SKPaint enemy = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            Color = SKColors.Orange
        };

        public GameScreen()
        {
            
            InitializeComponent();
            
          
            // In order for the player to continually move, we need to ensure the paint surface event handler is repeatedly executed
            // We want the timer to refresh 60 times per second, since that is the typical refresh rate of most monitors
            Device.StartTimer(TimeSpan.FromSeconds(1f / 144), () =>
              {
                  canvasView.InvalidateSurface();
                  return true;
              });
        }

        private float randValue()
        {
            Random cRand = new Random();
            return (float)cRand.NextDouble();
        }

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            // we get the current surface from the event args
            SKSurface surface = e.Surface;
            // then we get the canvas that we can draw on
            SKCanvas canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.Silver);

            int width = e.Info.Width;
            int height = e.Info.Height;

            // Set transforms
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 400f);

            // draw the circle fill and border
            canvas.DrawCircle(0, 0, 100, circleFill);
            canvas.DrawCircle(0, 0, 150, circleBorder);
            // Since we are making this game for 60 frames per second, we want it to update 60 times per second
            // the sleep function tells the computer how many milliseconds to wait before updating again. We want this to be 1000 milliseconds / 60 fps ~ 17 milliseconds
            Thread.Sleep(1000/60);
            MainLabel.Text = "Score: " + score.ToString();
            LevelLabel.Text = "Level: " + level.ToString();
            DebugLabel.Text = " Lives: " + lives.ToString();
            // Make sure the current rotation never becomes negative, because a negative value would mess up the "hit detection" in the button feature
            if (currentRotation <= 0)
            {
                currentRotation += 360;
            }
            // Make sure the randEnemy location never becomes negative, because a negative value would mess up the "hit detection" in the button feature
            if (randEnemy <= 0)
            {
                randEnemy += 360;
            }
            
            // If the player line passes over the enemy without tapping, the player loses a life
            if (reverse == false && currentRotation % 360 > randEnemy + 21 && currentRotation % 360 < randEnemy + 30)
            {
                tracker += 1;
                lives -= 1;
                reverse = true;
                randEnemy -= 50 + (randMovement() * 130);
            }
            if (reverse == true && currentRotation % 360 < randEnemy - 21 && currentRotation % 360 > randEnemy - 30)
            {
                tracker += 1;
                lives -= 1;
                reverse = false;
                randEnemy += 50 + (randMovement() * 130);
            }
            // The next 2 if statements solves a bug where the player can't tap on the dot near the 0 position
            // by ensuring the Enemy never spawns within 20 degrees of the "0" degree position
            if (randEnemy % 360 > 335)
            {
                randEnemy -= 25;
            }

            if (randEnemy % 360 < 25)
            {
                randEnemy += 25;
            }

            // Make sure the randEnemy location never goes above 360, because it would mess up the "hit detection"
            if (randEnemy >= 360)
            {
                randEnemy %= 360;
            }

            // We want to call the canvas.Save() method before the rotating the player line and then the canvas.Restore() method after
            canvas.Save();
            if (reverse == false)
            {
                currentRotation += speed * 2;
            }
            if (reverse == true)
            {
                currentRotation -= speed * 2;
            }
            
            if (lives == 0)
            {
                App.Current.MainPage = new EndScreen();
            }

            // Canvas.Rotate Degrees will rotate the canvas by the specified number of degrees. We want this number to count up to exactly 360 for a full circle
            canvas.RotateDegrees(currentRotation);
            // DrawLine will draw a line from from X1, Y1, to X2, Y2
            canvas.DrawLine(0, -100, 0, -150, playerLine);
            canvas.Restore();
            
            canvas.Save();
            canvas.RotateDegrees(randEnemy);
            canvas.DrawCircle(0, -125, 18, enemy);
            canvas.Restore();

        }
        private void Button_ClickedBack(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePage();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Notification", "Do you want to save this item?", "Save", "Don't Save");
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            _ = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.DarkRed.ToSKColor(),
                StrokeWidth = 25
            };
        }
        private float randMovement()
        {
            float enemyMovement = randValue();
            return enemyMovement;
        }

        //GameScreen(int thescore)
        //{
        //    thescore = score;
        //}
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if ((currentRotation%360 )+ 20 > randEnemy && (currentRotation%360) - 20 < randEnemy)
            {
                //randEnemy = randMovement() * 360;
                score += 1;
                tracker += 1;
                if (score % 5 == 0)
                {
                    level += 1;
                }
                if (score % 10 == 0)
                {
                    speed += 1;
                }
                if (tracker%2 == 1)
                {
                    reverse = true;
                    randEnemy -= 50 + (randMovement() * 130);

                }

                if (tracker%2 == 0)
                {
                    reverse = false;
                    randEnemy += 50 + (randMovement() * 130);
                }
            }
            else
            {
                lives -= 1;
            }
        }
    }
}
