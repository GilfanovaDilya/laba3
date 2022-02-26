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
        public static Color color = Color.Black;
        public static int weight = 2;
    }

    public abstract class Figure
    {
        public static List<string> Messages { get; set; } = new List<string>();
        public List<PointF> Points { get; set; } = new List<PointF>();
        public Color color = Color.Black;
        public int weight = 2;
        public string Name { get; set; }
        public abstract void Draw();

        public virtual void MoveTo(float[] fForChange)
        {
            if (OutOfBoundsCheck(fForChange[0], fForChange[1]))
            {
                Messages.Add("You enter invalid values. Try one more time)");
                return;
            }
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
            foreach (var f in ShapeContainer.figures)
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
                    throw new Exception("Invalid input");
                }
            }
            return result;
        }
        public void ChangeColor(Figure figure, Color newColor)
        {
            figure.color = newColor;
            figure.Draw();
        }
        public void ChangeWeight(Figure figure, int newWeight)
        {
            figure.weight = newWeight;
            figure.Draw();
        }

        public void ChangeLineDim(float[] fForChange)
        {
            float _w = fForChange[0],
                _h = fForChange.Length == 1 ? 0 : fForChange[1];
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

        public bool OutOfBoundsCheck(float x, float y)
        {
            return Points.Any(point => (point.X + x < 0) || (point.Y + y < 0) || (point.X + x > Init.pictureBox.Width) || (point.Y + y > Init.pictureBox.Height));
        }
    }
}