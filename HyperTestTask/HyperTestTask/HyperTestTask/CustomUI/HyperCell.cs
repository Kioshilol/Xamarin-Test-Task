using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace HyperTestTask.CustomUI
{
    public class HyperCell : SKCanvasView
    {
        private const int StrokeWidth = 4;
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int _circleRadius;
        
        public HyperCell(int circleRadius)
        {
            _circleRadius = circleRadius;
            PaintSurface += OnCanvasViewPaintSurface;
        }
         
        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Black.ToSKColor(),
                StrokeWidth = StrokeWidth,
                PathEffect = SKPathEffect.CreateDash(new float[] { 10, 6}, 20)
            };
            
            canvas.DrawCircle(info.Width / 2, info.Height / 2, _circleRadius, paint);

            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Gray.WithAlpha(0x90);
            canvas.DrawCircle(info.Width / 2, info.Height / 2, _circleRadius, paint);
        }
    }
}