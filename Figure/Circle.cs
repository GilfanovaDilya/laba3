using System.Drawing;

namespace Figure
{
    public class Circle : Ellipse
    {
        public static int numberOfCircle = 0;
        public Circle()
        { }

        public Circle(float x, float y, float w, bool single = true) : base(x, y, w, w)
        {
            if (!single) return;
            name = "Circle " + numberOfCircle;
            numberOfCircle++;
        }

        //public void ChangeRadius(int _w)
        //{
        //    if ((Points[1].X + _w < Points[0].X) || (Points[1].X + _w) > Init.pictureBox.Width || (Points[1].Y + _w) > Init.pictureBox.Height)
        //    {
        //        Messages.Add("You enter invalid values. Try one more time)");
        //        return;
        //    }
        //    var point = Points[1];
        //    point.X += _w;
        //    point.Y += _w;
        //    Points[1] = point;
        //    DeleteF(this, Init.pictureBox, false);
        //    Draw();
        //}
    }
}