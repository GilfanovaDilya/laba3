using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Figure
{
    public class Polygon : Figure
    {
        public static int numberOfPolygon = 0;

        public Polygon(bool single = true)
        {
            Points = new List<PointF>{};
            if (!single) return;
            name = "Polygon " + numberOfPolygon;
            numberOfPolygon++;
        }

        public Polygon(List<PointF> points, bool single = true)
        {
            Points = points;
            if (!single) return;
            name = "Polygon " + numberOfPolygon;
            numberOfPolygon++;
        }
        public override void Draw()
        {
            if (name != null && Points.Count < (name.StartsWith("Triangle") ? 3 : 2)) return;
            if (OutOfBoundsCheck(0,0))
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawPolygon(Init.pen, Points.ToArray());
            Init.pictureBox.Image = Init.bitmap;
        }

        //public override void MoveTo(int x, int y)
        //{
        //    if (OutOfBoundsCheck(x, y))
        //    {
        //        Messages.Add("You enter invalid values. Try one more time)");
        //        return;
        //    }
        //    for (var i = 0; i < Points.Count; i++)
        //    {
        //        var point = Points[i];
        //        point.X += x;
        //        point.Y += y;
        //        Points[i] = point;
        //    }
        //    DeleteF(this, Init.pictureBox, false);
        //    this.Draw();
        //}

        public void AddDot(PointF _point)
        {
            Points.Add(_point);
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }
    }
}