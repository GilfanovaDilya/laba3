using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace Figure
{
    public class Triangle : Polygon
    {
        public static int numberOfTriangle = 0;

        public Triangle() : base()
        {

        }

        public Triangle(List<PointF> triFs) : base(triFs)
        {
            name = "Triangle " + numberOfTriangle;
            numberOfTriangle++;
        }
    }
}