using System;
using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Sun : Figure
    {
        public static int numberOfSun = 0;

        public Sun()
        {
            Name = "Sun " + numberOfSun.ToString();
            numberOfSun++;
        }

        public Sun(float[] coordinatesF)
        {
            if (OutOfBoundCheckForCreation(coordinatesF)) throw new ArgumentException("Invalid input");
            float _x = coordinatesF[0];
            float _y = coordinatesF[1];
            float _w = coordinatesF[2];
            Points.AddRange(new List<PointF>()
            {
                new PointF((float) (_x - 0.7 * _w / 2.0), (float) (_y - 0.7 * _w / 2.0)),
                new PointF((float) (_x - 0.7 * _w / 2.0) + (float) (0.7 * _w),
                    (float) (_y - 0.7 * _w / 2.0) + (float) (0.7 * _w))
            });
            Points.AddRange(CreatePoints(-0.5, 0, -0.37, 0.26 / 3.0, -0.37, -0.26 / 3.0, _x, _y, _w));
            Points.AddRange(CreatePoints(
                -1 / Math.Sqrt(2) * 0.5,
                -1 / Math.Sqrt(2) * 0.5,
                -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)), _x, _y, _w));
            Points.AddRange(CreatePoints(0, -0.5, 0.26 / 3, -0.37, -0.26 / 3, -0.37, _x, _y, _w));
            Points.AddRange(CreatePoints(
                1 / Math.Sqrt(2) * 0.5,
                -1 / Math.Sqrt(2) * 0.5,
                Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)), _x, _y, _w));
            Points.AddRange(CreatePoints(0.5, 0, 0.37, 0.26 / 3.0, 0.37, -0.26 / 3.0, _x, _y, _w));
            Points.AddRange(CreatePoints(
                1 / Math.Sqrt(2) * 0.5,
                1 / Math.Sqrt(2) * 0.5,
                Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)), _x, _y, _w));
            Points.AddRange(CreatePoints(0, 0.5, 0.26 / 3, 0.37, -0.26 / 3, 0.37, _x, _y, _w));
            Points.AddRange(CreatePoints(
                -1 / Math.Sqrt(2) * 0.5,
                1 / Math.Sqrt(2) * 0.5,
                -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)), _x, _y, _w));
            Name = "Sun " + numberOfSun.ToString();
            numberOfSun++;
        }

        public override void Draw()
        {
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawEllipse(new Pen(color, weight), new System.Drawing.Rectangle(Point.Round(base.Points[0]), Size.Round(new SizeF(base.Points[1] - new SizeF(base.Points[0])))));
            for (int i = 2; i < Points.Count; i += 3)
            {
                graphic.DrawPolygon(new Pen(color, weight), Points.GetRange(i, 3).ToArray());
            }
            Init.pictureBox.Image = Init.bitmap;
        }

        public List<PointF> CreatePoints(double X1, double Y1, double X2, double Y2, double X3, double Y3, double _x,
            double _y, double _w)
        {
            return new List<PointF>()
            {
                new PointF((float) (_x + X1 * _w), (float) (_y + Y1 * _w)),
                new PointF((float) (_x + X2 * _w), (float) (_y + Y2 * _w)),
                new PointF((float) (_x + X3 * _w), (float) (_y + Y3 * _w))
            };
        }
    }
}