using System;
using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace TapTheDot
{ 
    public partial class GameScreen : ContentPage
    {
        //SKBitmap helloBitmap;
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
            StrokeWidth = 5
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

        public GameScreen()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromMilliseconds(1f / 60), () =>
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
            // dropping to width/20f makes it extremely large
            canvas.Scale(width / 400f);

            // draw the circle fill
            canvas.DrawCircle(0, 0, 100, circleFill);

            // draw the circle border
            canvas.DrawCircle(0, 0, 150, circleBorder);

            // Instantiate Date/Time
            DateTime dateTime = DateTime.Now;

            // Line Rotation
            canvas.Save();
            float seconds = dateTime.Millisecond;

            // Divide by some number n depending on level
            canvas.RotateDegrees(seconds);
            canvas.DrawLine(0, -100, 0, -150, playerLine);
            // DrawLine from X1, Y1, to X2, Y2
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

    }

}
