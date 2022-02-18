using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Figure
{
    public class Polygon : Figure
    {
        public PointF[] PointFs;

        public Polygon()
        {
            PointFs = Array.Empty<PointF>();
        }

        public Polygon(PointF[] points)
        {
            PointFs = points;
        }
        public override void Draw()
        {
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawPolygon(Init.pen, PointFs);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
            if (!OutOfBoundsCheck(x, y)) return;
            for (var i = 0; i < PointFs.Length; i++)
            {
                PointFs[i].X += x;
                PointFs[i].Y += x;
            }
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }
    }
}