using System;
using System.Collections.Generic;
using System.Linq;

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
            if (figures.Any(fig => fig.Name == figure.Name)) throw new Exception("Name is already exists");
            figures.Add(figure);
        }
    }
}