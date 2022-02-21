namespace Figure
{
    public class Square : Rectangle
    {
        public static int numberOfSquare = 0;
        public Square()
        { }

        public Square(double x, double y, double w) : base(x, y, w, w)
        {
            name = "Square " + numberOfSquare;
            numberOfSquare++;
        }
    }
}