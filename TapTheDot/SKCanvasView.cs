using System;
using Xamarin.Forms;

namespace TapTheDot
{
    internal class SKCanvasView
    {
        public int PaintSurface { get; internal set; }

        public static implicit operator View(SKCanvasView v)
        {
            throw new NotImplementedException();
        }
    }
}