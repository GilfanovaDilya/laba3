using System.Collections.Generic;

namespace Figure
{
    public class ShapeContainer
    {
        public static List<Figure> figures;

        static ShapeContainer()
        {
            figures = new List<Figure>();
        }

        public static void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }
    }
}