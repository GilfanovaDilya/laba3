using System;
using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Sun : Figure
    {
        public static int numberOfSun = 0;
        private double _x { get; set; }
        private double _y { get; set; }
        private double _w { get; set; }
        public Circle centerCircle = new Circle();
        public Triangle[] Triangles = { new Triangle() };

        public Sun()
        {
            _x = 0;
            _y = 0;
            _w = 0;
            centerCircle = new Circle();
            Triangles = new[] {new Triangle()};
        }

        public Sun(double x, double y, double w)
        {
            _x = x;
            _y = y;
            _w = w;
            if (OutOfBoundsCheck(0,0))
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }

            centerCircle = new Circle((float) (_x - 0.7 * _w / 2.0), (float) (_y - 0.7 * _w / 2.0), (float) (0.7 * _w), false);
            Triangles = new[]
            {
                CreateTriangle(-0.5, 0, -0.37, 0.26 / 3.0, -0.37, -0.26 / 3.0),
                CreateTriangle(
                    -1 / Math.Sqrt(2) * 0.5,
                    -1 / Math.Sqrt(2) * 0.5,
                    -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0))),
                CreateTriangle(0, -0.5, 0.26 / 3, -0.37, -0.26 / 3, -0.37),
                CreateTriangle(
                    1 / Math.Sqrt(2) * 0.5,
                    -1 / Math.Sqrt(2) * 0.5,
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0))),
                CreateTriangle(0.5, 0, 0.37, 0.26 / 3.0, 0.37, -0.26 / 3.0),
                CreateTriangle(
                    1 / Math.Sqrt(2) * 0.5,
                    1 / Math.Sqrt(2) * 0.5,
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0))),
                CreateTriangle(0, 0.5, 0.26 / 3, 0.37, -0.26 / 3, 0.37),
                CreateTriangle(
                    -1 / Math.Sqrt(2) * 0.5,
                    1 / Math.Sqrt(2) * 0.5,
                    -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) *
                    Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)))
            };
            name = "Sun " + numberOfSun.ToString();
            numberOfSun++;
        }

        public override void Draw()
        {
            centerCircle.Draw();
            foreach (var triangle in Triangles)
            {
                triangle.Draw();
            }

            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
            if (OutOfBoundsCheck(x, y)) return;
            _x += x;
            _y += y;
            for (var i = 0; i < centerCircle.Points.Count; i++)
            {
                var centerCirclePoint = centerCircle.Points[i];
                centerCirclePoint.X += x;
                centerCirclePoint.Y += y;
                centerCircle.Points[i] = centerCirclePoint;
            }
            foreach (var triangle in Triangles)
            {
                for (var i = 0; i < triangle.Points.Count; i++)
                {
                    var triangl = triangle.Points[i];
                    triangl.X += x;
                    triangl.Y += y;
                    triangle.Points[i] = triangl;
                }
            }

            DeleteF(this, Init.pictureBox, false);
            Draw();
        }

        public Triangle CreateTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            return new Triangle(new List<PointF>()
            {
                new PointF((float) (_x + X1 * _w), (float) (_y + Y1 * _w)),
                new PointF((float) (_x + X2 * _w), (float) (_y + Y2 * _w)),
                new PointF((float) (_x + X3 * _w), (float) (_y + Y3 * _w))
            }, false);
        }

        private new bool OutOfBoundsCheck(int x, int y)
        {
            return ((_x - 0.5 * _w + x < 0) || (_y - 0.5 * _w + y < 0) || (_x + 0.5 * _w + x > Init.pictureBox.Width) ||
                    (_y + 0.5 * _w + y > Init.pictureBox.Height));
        }
    }
}