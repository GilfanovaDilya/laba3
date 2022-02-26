using System.Drawing;

namespace Figure
{
    public class Circle : Ellipse
    {
        public static int numberOfCircle = 0;

        public Circle(bool single = true) : base(false)
        {
            if (!single) return;
            Name = "Circle " + numberOfCircle;
            numberOfCircle++;
        }

        public Circle(float[] coordinatesF, bool single = true) : base(coordinatesF, false)
        {
            if (!single) return;
            Name = "Circle " + numberOfCircle;
            numberOfCircle++;
        }
    }
}