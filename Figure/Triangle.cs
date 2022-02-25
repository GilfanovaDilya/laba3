using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Figure
{
    public class Triangle : Polygon
    {
        public static int numberOfTriangle = 0;

        public Triangle(bool single = true) : base(false)
        {
            if (!single) return;
            name = "Triangle " + numberOfTriangle;
            numberOfTriangle++;
        }

        public Triangle(List<PointF> triFs, bool single = true) : base(triFs, false)
        {
            if (!single) return;
            name = "Triangle " + numberOfTriangle;
            numberOfTriangle++;
        }
    }
}