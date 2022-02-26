using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Ellipse : Figure
    {
        public static int numberOfEllipse = 0;
        public Ellipse(bool single = true)
        {
            Points = new List<PointF>();
            if (!single) return;
            Name = "Ellipse " + numberOfEllipse;
            numberOfEllipse++;
        }

        public Ellipse(float[] coordinatesF, bool single = true)
        {
            Points = new List<PointF> {new PointF(coordinatesF[0], coordinatesF[1]), new PointF((coordinatesF[0] + coordinatesF[2]), (coordinatesF[1] +
                (coordinatesF.Length == 3 ? coordinatesF[2] : coordinatesF[3])))};
            if (!single) return;
            Name = "Ellipse " + numberOfEllipse;
            numberOfEllipse++;
        }
        public override void Draw()
        {
            if (OutOfBoundsCheck(0,0))
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawEllipse(new Pen(color, weight), new System.Drawing.Rectangle(Point.Round(Points[0]), Size.Round(new SizeF(Points[1] - new SizeF(Points[0])))));
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}