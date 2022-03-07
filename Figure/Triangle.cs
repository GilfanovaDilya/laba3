using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class Triangle : Polygon
    {
        public static int numberOfTriangle = 0;

        public Triangle() : base(true)
        {
            Name = "Triangle " + numberOfTriangle;
            numberOfTriangle++;
        }

        public Triangle(List<PointF> triFs) : base(triFs)
        {
            Name = "Triangle " + numberOfTriangle;
            numberOfTriangle++;
        }
    }
}