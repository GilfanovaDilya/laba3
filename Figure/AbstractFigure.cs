using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Figure
{
    public static class Init
    {
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
        public static Color color = Color.Black;
        public static int weight = 2;
    }

    public abstract class Figure
    {
        public List<PointF> Points { get; set; } = new List<PointF>();
        public Color color = Color.Black;
        public int weight = 2;
        public string Name { get; set; }
        public abstract void Draw();

        public virtual void MoveTo(float[] fForChange)
        {
            if (OutOfBoundsCheck(fForChange[0], fForChange[1])) throw new Exception("Invalid input");

            for (var i = 0; i < Points.Count; i++)
            {
                var point = Points[i];
                point.X += fForChange[0];
                point.Y += fForChange[1];
                Points[i] = point;
            }

            DeleteF(this, Init.pictureBox, false);
            this.Draw();
        }

        public void DeleteF(Figure deletedFigure, PictureBox pictureBox, bool flag = true)
        {
            var graphics = Graphics.FromImage(Init.bitmap);
            ShapeContainer.figures.Remove(deletedFigure);
            graphics.Clear(Color.White);
            pictureBox.Image = Init.bitmap;
            foreach (var f in ShapeContainer.figures.Where(f => !(f is APoints)))
            {
                f.Draw();
            }

            if (!flag) ShapeContainer.figures.Add(deletedFigure);
        }

        public static float[] ErrorClearParse(string[] inputStrings)
        {
            var result = new float[inputStrings.Length];
            for (var i = 0; i < result.Length; i++)
            {
                if (!float.TryParse(inputStrings[i], out result[i]))
                {
                    throw new ArgumentException("Invalid input");
                }
            }

            return result;
        }

        public bool OutOfBoundCheckForCreation(float[] coordFloats)
        {
            float x = coordFloats[0];
            float y = coordFloats[1];
            float w = coordFloats.Length == 2 ? 0 : coordFloats[2];
            float h = coordFloats.Length <= 3 ? w : coordFloats[3];
            return x < 0 || y < 0 || x + w > Init.pictureBox.Width || y + h > Init.pictureBox.Height;
        }

        public bool OutOfBoundsCheck(float x, float y)
        {
            return Points.Any(point =>
                (point.X + x < 0) || (point.Y + y < 0) || (point.X + x > Init.pictureBox.Width) ||
                (point.Y + y > Init.pictureBox.Height));
        }
    }
}