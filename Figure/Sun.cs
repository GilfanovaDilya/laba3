using System;
using System.Drawing;

namespace Figure
{
    public class Sun : Figure
    {
        private double _x { get; set; }
        private double _y { get; set; }
        private double _w { get; set; }
        public Circle centerCircle;
        public Triangle[] Triangles;

        public Sun()
        {
            _x = 0;
            _y = 0;
            _w = 0;
            centerCircle = new Circle();
            Triangles = new []{new Triangle()};
        }

        public Sun(double x, double y, double w)
        {
            _x = x;
            _y = y;
            _w = w;
            if (OutOfBoundsCheck(0,0))
            {
                centerCircle = new Circle();
                Triangles = new[] { new Triangle() };
                return;
            }
            centerCircle = new Circle(_x - 0.7 * _w / 2.0, _y - 0.7 * _w / 2.0, 0.7 * _w);
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
            centerCircle.x += x;
            centerCircle.y += y;
            foreach (var triangle in Triangles)
            {
                for (var i = 0; i < triangle.PointFs.Length; i++)
                {
                    triangle.PointFs[i].X += x;
                    triangle.PointFs[i].Y += y;
                }
            }

            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }

        public Triangle CreateTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            return new Triangle(new[]
            {
                new PointF((float) (_x + X1 * _w), (float) (_y + Y1 * _w)),
                new PointF((float) (_x + X2 * _w), (float) (_y + Y2 * _w)),
                new PointF((float) (_x + X3 * _w), (float) (_y + Y3 * _w))
            });
        }

        private new bool OutOfBoundsCheck(int x, int y)
        {
            return ((_x - 0.5 * _w + x < 0) || (_y - 0.5 * _w + y < 0) || (_x + 0.5 * _w + x > Init.pictureBox.Width) || (_y + 0.5 * _w + y > Init.pictureBox.Height));
        }
    }
}