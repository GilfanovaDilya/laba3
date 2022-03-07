namespace Figure
{
    public class Square : Rectangle
    {
        public static int numberOfSquare = 0;
        public Square() : base() { }

        public Square(float[] coordinatesF) : base(coordinatesF, true)
        {
            Name = "Square " + numberOfSquare;
            numberOfSquare++;
        }
    }
}