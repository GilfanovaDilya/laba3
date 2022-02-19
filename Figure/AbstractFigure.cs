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
        public double x { get; set; }
        public double y { get; set; }
        public double w { get; set; }
        public double h { get; set; }
        public abstract void Draw();
        public abstract void MoveTo(int x, int y);

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

        public bool OutOfBoundsCheck(int x, int y)
        {
            return !((this.x + x < 0) || (this.y + y < 0) || (this.x + this.w + x > Init.pictureBox.Width) ||
                     (this.y + this.h + y > Init.pictureBox.Height));
        }
    }
}