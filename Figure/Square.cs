namespace Figure
{
    public class Square : Rectangle
    {
        public static int numberOfSquare = 0;
        public Square()
        { }

        public Square(float x, float y, float w) : base(x, y, w, w)
        {
            name = "Square " + numberOfSquare;
            numberOfSquare++;
        }
    }
}