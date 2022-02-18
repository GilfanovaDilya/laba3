using System.Drawing;

namespace Figure
{
    public class Rectangle : Figure
    {
        public Rectangle()
        {
            x = 0;
            y = 0;
            w = 0;
            h = 0;
        }

        public Rectangle(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public override void Draw()
        {
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawRectangle(Init.pen, (float)x, (float)y, (float)w, (float)h);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
            if (!OutOfBoundsCheck(x, y)) return;
            this.x += x;
            this.y += y;
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }

        public void ChangeLineDim(int _w, int _h)
        {
            if ((w + _w) < Init.pictureBox.Width || (h + _h) < Init.pictureBox.Height) return;
            w += _w;
            h += _h;
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }
    }
}