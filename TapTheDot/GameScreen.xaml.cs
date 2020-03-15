using System;
using System.Collections.Generic;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace TapTheDot
{
    public partial class GameScreen : ContentPage
    {
        SKBitmap helloBitmap;

        public GameScreen()
        {
            InitializeComponent();

            SKBitmap bitmap = new SKBitmap();
            SKCanvas canvas = new SKCanvas(bitmap);


            using (canvas = new SKCanvas(bitmap))
            {
                // call drawing function
            }

        }

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            // we get the current surface from the event args
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.White);
            // create the paint for the filled circle
            var circleFill = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.NavajoWhite
            };

            // draw the circle fill
            canvas.DrawCircle(100, 100, 100, circleFill);

            // create the paint for the circle border
            var circleBorder = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 5
            };

            // draw the circle border
            canvas.DrawCircle(100, 100, 100, circleBorder);
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
