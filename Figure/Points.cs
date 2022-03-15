using System;
using System.Collections.Generic;
using System.Drawing;

namespace Figure
{
    public class APoints : Figure
    {
        public APoints(string name)
        {
            Points = new List<PointF>();
            Name = name;
        }

        public void AddDot(string[] dotStrings)
        {
            var dotFloat = ErrorClearParse(dotStrings);
            var _point = new PointF(dotFloat[0], dotFloat[1]);
            if (OutOfBoundCheckForCreation(new[] { _point.X, _point.Y })) throw new ArgumentException("Invalid input");
            Points.Add(_point);
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}