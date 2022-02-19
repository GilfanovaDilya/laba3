using System.Drawing;

namespace Figure
{
    public class Circle : Ellipse
    {
        public Circle()
        { }
        public Circle(double x, double y, double w) : base(x,  y,  w,  w) { }

        public void ChangeRadius(int _w)
        {
            if ((w + _w < 0) || (x + w + _w) > Init.pictureBox.Width || (y + w + _w) > Init.pictureBox.Height) return;
            w += _w;
            DeleteF(this, Init.pictureBox, false);
            Draw();
        }
    }
}