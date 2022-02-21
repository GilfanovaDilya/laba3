using System.Drawing;

namespace Figure
{
    public class Ellipse : Figure
    {
        public static int numberOfEllipse = 0;
        public Ellipse()
        {
            x = 0;
            y = 0;
            w = 0;
            h = 0;
        }

        public Ellipse(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            name = "Ellipse " + numberOfEllipse;
            numberOfEllipse++;
        }
        public override void Draw()
        {
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawEllipse(Init.pen, (float)x, (float)y, (float)w, (float)h);
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
    }
}