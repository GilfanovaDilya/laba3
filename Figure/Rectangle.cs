using System;
using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Rectangle : Figure
    {
        public static int numberOfRectangle = 0;
        public Rectangle()
        {
            Points = new List<PointF>();
        }

        public Rectangle(float[] coordinatesF)
        {
            Points = new List<PointF> {new PointF(coordinatesF[0], coordinatesF[1]), new PointF((coordinatesF[0] + coordinatesF[2]), (coordinatesF[1] +
                (coordinatesF.Length == 3 ? coordinatesF[2] : coordinatesF[3])))};
            Name = "Rectangle " + numberOfRectangle;
            numberOfRectangle++;
        }

        public override void Draw()
        {
            if (OutOfBoundsCheck(0,0))
            {
                throw new Exception("Your enter invalid values)");
            }
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawRectangle(new Pen(color, weight), new System.Drawing.Rectangle(Point.Round(Points[0]), Size.Round(new SizeF(Points[1] - new SizeF(Points[0])))));
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}