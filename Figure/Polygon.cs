using System;
using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Polygon : Figure
    {
        public Polygon(string name, List<PointF> points)
        {
            Points = points;
            Name = name;
        }

        public override void Draw()
        {
            if (Name != null && Points.Count < (Name.StartsWith("Triangle") ? 3 : 2)) return;
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawPolygon(new Pen(color, weight), Points.ToArray());
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}