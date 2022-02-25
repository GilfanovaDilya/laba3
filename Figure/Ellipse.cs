using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Ellipse : Figure
    {
        public static int numberOfEllipse = 0;
        public Ellipse()
        {
            Points = new List<PointF>();
        }

        public Ellipse(float x, float y, float w, float h)
        {
            Points = new List<PointF> { new PointF(x, y), new PointF((x + w), (y + h)) };
            name = "Ellipse " + numberOfEllipse;
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
            graphic.DrawEllipse(Init.pen, new System.Drawing.Rectangle(Point.Round(Points[0]), Size.Round(new SizeF(Points[1] - new SizeF(Points[0])))));
            Init.pictureBox.Image = Init.bitmap;
        }

        //public override void MoveTo(int x, int y)
        //{
        //    if (OutOfBoundsCheck(x, y))
        //    {
        //        Messages.Add("You enter invalid values. Try one more time)");
        //        return;
        //    }
        //    this.x += x;
        //    this.y += y;
        //    DeleteF(this, Init.pictureBox, false);
        //    this.Draw();
        //}
    }
}