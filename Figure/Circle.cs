namespace Figure
{
    public class Circle : Ellipse
    {
        public static int numberOfCircle = 0;

        public Circle() : base() { }

        public Circle(float[] coordinatesF) : base(coordinatesF, true)
        {
            Name = "Circle " + numberOfCircle;
            numberOfCircle++;
        }
    }
}