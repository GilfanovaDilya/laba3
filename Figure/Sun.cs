using System;
using System.Drawing;

namespace Figure
{
    public class Sun : Figure
    {
        public Circle centerCircle;
        public Triangle[] Triangles;

        public Sun()
        {
            centerCircle = null;
            Triangles = null;
        }

        public Sun(double x, double y, double w)
        {
            centerCircle = new Circle(x -0.7 * w/2.0, y - 0.7 * w / 2.0, 0.7 * w);
            Triangles = new[]
            {
                CreateTriangle(-0.5, 0, -0.37, 0.26 / 3.0, -0.37, -0.26 / 3.0,x,y,w),
                CreateTriangle(
                    -1 / Math.Sqrt(2) * 0.5,
                    -1 / Math.Sqrt(2) * 0.5,
                    -Math.Sin(Math.PI/4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI/4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI/4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Sin(Math.PI/4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    x,y,w),
                CreateTriangle(0, -0.5, 0.26 / 3, -0.37, -0.26 / 3, -0.37,x,y,w),
                CreateTriangle(
                    1 / Math.Sqrt(2) * 0.5,
                    -1 / Math.Sqrt(2) * 0.5,
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    x,y,w),
                CreateTriangle(0.5, 0, 0.37, 0.26 / 3.0, 0.37, -0.26 / 3.0,x,y,w),
                CreateTriangle(
                    1 / Math.Sqrt(2) * 0.5,
                    1 / Math.Sqrt(2) * 0.5,
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    x,y,w),
                CreateTriangle(0, 0.5, 0.26 / 3, 0.37, -0.26 / 3, 0.37,x,y,w),
                CreateTriangle(
                    -1 / Math.Sqrt(2) * 0.5,
                    1 / Math.Sqrt(2) * 0.5,
                    -Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    -Math.Cos(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    Math.Sin(Math.PI / 4.0 - Math.Atan(0.26 / (3 * 0.37))) * Math.Sqrt(Math.Pow(0.37, 2.0) + Math.Pow(0.26 / 3.0, 2.0)),
                    x,y,w)
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
            if (!OutOfBoundsCheck(x, y)) return;
            centerCircle.MoveTo(x,y);
        }

        public Triangle CreateTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3, double x, double y, double w)
        {
            return new Triangle(new[]
            {
                new PointF((float) (x + X1 * w), (float) (y + Y1 * w)),
                new PointF((float) (x + X2 * w), (float) (y + Y2 * w)),
                new PointF((float) (x + X3 * w), (float) (y + Y3 * w))
            });
        }
    }
}