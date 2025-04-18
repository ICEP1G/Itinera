using Itinera.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Shapes
{
    public class ReviewDetailModal_WithoutImage_Shape : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            Color backgroundColor = ResourceHelper.GetColor("White");
            float circleRadius = 50;
            float rectX = 0;
            float rectY = circleRadius;
            float rectWidth = dirtyRect.Width - rectX;
            float rectHeight = dirtyRect.Height;

            // Draw the Circle
            canvas.FillColor = backgroundColor;
            canvas.StrokeColor = Color.FromRgba(0, 0, 0, 0);
            canvas.StrokeSize = 0;
            canvas.DrawCircle(circleRadius, circleRadius, circleRadius);
            canvas.FillCircle(circleRadius, circleRadius, circleRadius);

            // raw the Rectangle
            canvas.FillColor = backgroundColor;
            canvas.DrawRoundedRectangle(rectX, rectY, rectWidth, rectHeight, 0, 16, 0, 0);
            canvas.FillRoundedRectangle(rectX, rectY, rectWidth, rectHeight, 0, 16, 0, 0);
        }
    }
}
