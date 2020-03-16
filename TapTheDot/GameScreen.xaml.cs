using System;
using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace TapTheDot
{ 
    public partial class GameScreen : ContentPage
    {
        // create the paint for the filled circle
        
        SKPaint circleFill = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };
        // create the paint for the circle border
        SKPaint circleBorder = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 5,
            StrokeCap = SKStrokeCap.Round
        };

        SKPaint playerLine = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Red,
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

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            // we get the current surface from the event args
            SKSurface surface = e.Surface;
            // then we get the canvas that we can draw on
            SKCanvas canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.CornflowerBlue);

            int width = e.Info.Width;
            int height = e.Info.Height;

            // Set transforms
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 400f);

            // draw the circle fill and border
            canvas.DrawCircle(0, 0, 100, circleFill);
            canvas.DrawCircle(0, 0, 150, circleBorder);
            canvas.DrawCircle(0, -125, 18, enemy);


            // Instantiate Date/Time
            DateTime dateTime = DateTime.Now;
            float milliseconds = dateTime.Millisecond;
            float seconds = dateTime.Second;
            
            // formula: (seconds % [# rotations per second] * [360 / # rotations per second]) + (milliseconds / (float)[1000 / (360 / # rotations per second)]
            // rotates once per second
            //float Rotation = milliseconds / (float)2.77777778;
            // rotates once every 2 seconds
            float fastRotation = (seconds % 2 * 180) + (milliseconds / (float)5.5555556);
            // rotates once every 3 seconds
            float mediumRotation = (seconds % 3 * 120) + (milliseconds / (float)8.333333333);
            // rotates once every 4 seconds
            float slowRotation = (seconds % 4 * 90) + (milliseconds / (float)11.11111111);
            // rotates once every 5 seconds
            float slowestRotation = (seconds % 5 * 72) + (milliseconds / (float)13.88888889);
            
            // enemy movement
            // float enemyMovement = 


            // We want to call the canvas.Save() method before the rotating the player line and then the canvas.Restore() method after
            canvas.Save();
            // Canvas.Rotate Degrees will rotate the canvas by the specified number of degrees. We want this number to count up to exactly 360 for a full circle
            canvas.RotateDegrees(slowestRotation);
            // DrawLine will draw a line from from X1, Y1, to X2, Y2
            canvas.DrawLine(0, -100, 0, -150, playerLine);
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
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };

        }

        int score = 0;
        private void Button_Clicked_2(object sender, EventArgs e)
        {

            score += 1;
            MainLabel.Text = "Score: " + score.ToString();
        }
    }

}
