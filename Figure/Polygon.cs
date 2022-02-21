using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Figure
{
    public class Polygon : Figure
    {
        public static int numberOfPolygon = 0;
        public List<PointF> PointFs;

        public Polygon()
        {
            PointFs = new List<PointF>{};
            name = "Polygon " + numberOfPolygon;
            numberOfPolygon++;
        }

        public Polygon(List<PointF> points)
        {
            PointFs = points;
            name = "Polygon " + numberOfPolygon;
            numberOfPolygon++;
        }
        public override void Draw()
        {
            if (PointFs.Count < 2) return;
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawPolygon(Init.pen, PointFs.ToArray());
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
            if (OutOfBoundsCheck(x, y)) return;
            for (var i = 0; i < PointFs.Count; i++)
            {
                (PointFs.ToArray())[i].X += x;
                (PointFs.ToArray())[i].Y += y;
            }
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }

        public void AddDot(PointF _point)
        {
            PointFs.Add(_point);
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }
        private new bool OutOfBoundsCheck(int x, int y)
        {
            return PointFs.Any(point => (point.X + x < 0) || (point.Y + y < 0) || (point.X + x > Init.pictureBox.Width) || (point.Y + y > Init.pictureBox.Height));
        }
    }
}