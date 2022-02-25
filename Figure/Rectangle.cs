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

        public Rectangle(float x, float y, float w, float h)
        {
            Points = new List<PointF> {new PointF(x, y), new PointF((x + w), (y + h))};
            name = "Rectangle " + numberOfRectangle;
            numberOfRectangle++;
        }

        public override void Draw()
        {
            if (OutOfBoundsCheck(0,0))
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawRectangle(Init.pen,new System.Drawing.Rectangle(Point.Round(Points[0]), Size.Round(new SizeF(Points[1] - new SizeF(Points[0])))));
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

        //public void ChangeLineDim(int _w, int _h)
        //{
        //    if ((Points[1].X + _w < Points[0].X) || (Points[1].Y + _h < Points[0].Y) || (Points[1].X + _w) > Init.pictureBox.Width || (Points[1].Y + _h) > Init.pictureBox.Height)
        //    {
        //        Messages.Add("You enter invalid values. Try one more time)");
        //        return;
        //    }

        //    var point = Points[1];
        //    point.X += _w;
        //    point.Y += _h;
        //    Points[1] = point;
        //    DeleteF(this, Init.pictureBox, false);
        //    Draw();
        //}
    }
}