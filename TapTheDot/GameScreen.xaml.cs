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


            //Title = "Simple Circle";
            /*
            _ = new SKCanvasView
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.FillAndExpand,   // stretch the view
                HorizontalOptions = LayoutOptions.FillAndExpand, // stretch the view
            };
            */
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
        */
    }

}
