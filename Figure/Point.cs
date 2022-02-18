using System.Drawing;

namespace Figure
{
    public class MPoint : Figure
    {
        public MPoint()
        {
            x = 0;
            y = 0;
        }

        public MPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override void Draw()
        {
            var graphic = Graphics.FromImage(Init.bitmap);
            graphic.DrawLine(Init.pen, (float) x, (float) y, (float) (x+1), (float) (y+1));
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