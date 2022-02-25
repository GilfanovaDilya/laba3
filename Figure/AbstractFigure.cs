using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figure
{
    public static class Init
    {
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
    }

    public abstract class Figure
    {
        public static List<string> Messages { get; set; } = new List<string>();
        public List<PointF> Points { get; set; } = new List<PointF>();
        //public double x { get; set; }
        //public double y { get; set; }
        //public double w { get; set; }
        //public double h { get; set; }
        public string name { get; set; }
        public abstract void Draw();

        public virtual void MoveTo(int x, int y)
        {
            if (OutOfBoundsCheck(x, y))
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }
            for (var i = 0; i < Points.Count; i++)
            {
                var point = Points[i];
                point.X += x;
                point.Y += y;
                Points[i] = point;
            }
            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }

        public void DeleteF(Figure deletedFigure, PictureBox pictureBox, bool flag = true)
        {
            if (flag == true)
            {
                var graphics = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figures.Remove(deletedFigure);
                this.Clear();
                Init.pictureBox.Image = Init.bitmap;
                foreach (var f in ShapeContainer.figures)
                {
                    f.Draw();
                }
            }
            else
            {
                var graphics = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figures.Remove(deletedFigure);
                this.Clear();
                pictureBox.Image = Init.bitmap;
                foreach (var f in ShapeContainer.figures)
                {
                    f.Draw();
                }

                ShapeContainer.figures.Add(deletedFigure);
            }
        }

        public void Clear()
        {
            var g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

        public void ChangeLineDim(int _w, int _h = default)
        {
            if (_h == default) _h = _w;
            if ((Points[1].X + _w < Points[0].X) || (Points[1].Y + _h < Points[0].Y) || (Points[1].X + _w) > Init.pictureBox.Width || (Points[1].Y + _h) > Init.pictureBox.Height)
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }

            var point = Points[1];
            point.X += _w;
            point.Y += _h;
            Points[1] = point;
            DeleteF(this, Init.pictureBox, false);
            Draw();
        }

        public bool OutOfBoundsCheck(int x, int y)
        {
            return Points.Any(point => (point.X + x < 0) || (point.Y + y < 0) || (point.X + x > Init.pictureBox.Width) || (point.Y + y > Init.pictureBox.Height));
        }
    }
}