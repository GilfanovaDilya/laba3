using System;
using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Polygon : Figure
    {
        public static int numberOfPolygon = 0;

        public Polygon(bool isTriangle = false)
        {
            Points = new List<PointF> { };
            if (isTriangle) return;
            Name = "Polygon " + numberOfPolygon;
            numberOfPolygon++;
        }

        public Polygon(List<PointF> points)
        {
            Points = points;
            Name = "Polygon " + numberOfPolygon;
            numberOfPolygon++;
        }

        public override void Draw()
        {
            if (Name != null && Points.Count < (Name.StartsWith("Triangle") ? 3 : 2)) return;
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawPolygon(new Pen(color, weight), Points.ToArray());
            Init.pictureBox.Image = Init.bitmap;
        }

        public void AddDot(PointF _point)
        {
            if (OutOfBoundCheckForCreation(new[] { _point.X, _point.Y })) throw new ArgumentException("Invalid input");
            Points.Add(_point);
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }
    }
}