namespace Figure
{
    public class Square : Rectangle
    {
        public static int numberOfSquare = 0;
        public Square()
        { }

        public Square(float[] coordinatesF) : base(coordinatesF)
        {
            Name = "Square " + numberOfSquare;
            numberOfSquare++;
        }
    }
}