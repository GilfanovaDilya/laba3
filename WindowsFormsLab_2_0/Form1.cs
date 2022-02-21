using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Figure;

namespace WindowsFormsLab_2_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new
                Bitmap(pictureBox1.ClientSize.Width,
                    pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
            Init.pen = new Pen(Color.Black, 2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double x = 500.0;
            double y = 500.0;
            double w = 500.0;
            var figure1 = new Sun(x, y, w);
            figure1.Draw();
            ShapeContainer.AddFigure(figure1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Square_X.Text);
            int y = int.Parse(Square_Y.Text);
            throw new NotImplementedException();
        }

        public Triangle CreateTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3, double x,
            double y, double w)
        {
            return new Triangle(new List<PointF>()
            {
                new PointF((float) (x + X1 * w), (float) (y + Y1 * w)),
                new PointF((float) (x + X2 * w), (float) (y + Y2 * w)),
                new PointF((float) (x + X3 * w), (float) (y + Y3 * w))
            });
        }

        private void Square_C_Click(object sender, EventArgs e)
        {
            var square = new Square(double.Parse(Square_X.Text), double.Parse(Square_Y.Text),
                double.Parse(Square_W.Text));
            square.Draw();
            ShapeContainer.AddFigure(square);
        }

        private void Rectangle_C_Click(object sender, EventArgs e)
        {
            var rectangle = new Figure.Rectangle(double.Parse(Rectangle_X.Text), double.Parse(Rectangle_Y.Text),
                double.Parse(Rectangle_W.Text), double.Parse(Rectangle_H.Text));
            rectangle.Draw();
            ShapeContainer.AddFigure(rectangle);
        }

        private void Ellipse_C_Click(object sender, EventArgs e)
        {
            var ellipse = new Figure.Ellipse(double.Parse(Ellipse_X.Text), double.Parse(Ellipse_Y.Text),
                double.Parse(Ellipse_W.Text), double.Parse(Ellipse_H.Text));
            ellipse.Draw();
            ShapeContainer.AddFigure(ellipse);
        }

        private void Circle_C_Click(object sender, EventArgs e)
        {
            var circle = new Circle(double.Parse(Circle_X.Text), double.Parse(Circle_Y.Text),
                double.Parse(Circle_W.Text));
            circle.Draw();
            ShapeContainer.AddFigure(circle);
        }

        private void Sun_C_Click(object sender, EventArgs e)
        {
            var sun = new Sun(double.Parse(Sun_X.Text), double.Parse(Sun_Y.Text),
                double.Parse(Sun_W.Text));
            sun.Draw();
            ShapeContainer.AddFigure(sun);
        }

        private void Polygon_N_Click(object sender, EventArgs e)
        {
            Polygon_X.Text = "";
            Polygon_Y.Text = "";
            Polygon_X.Enabled = true;
            Polygon_Y.Enabled = true;
            Polygon_Add.Enabled = true;
            ShapeContainer.AddFigure(new Polygon());
        }

        private void Polygon_Add_Click(object sender, EventArgs e)
        {
            var polygon = ShapeContainer.figures.Last();
            ((Polygon) polygon).AddDot(new PointF(float.Parse(Polygon_X.Text), float.Parse(Polygon_Y.Text)));
            Polygon_X.Text = "";
            Polygon_Y.Text = "";
        }

        private void Triangle_N_Click(object sender, EventArgs e)
        {
            Triangle_X.Text = "";
            Triangle_Y.Text = "";
            Triangle_X.Enabled = true;
            Triangle_Y.Enabled = true;
            Triangle_Add.Enabled = true;
            ShapeContainer.AddFigure(new Triangle());
        }

        private void Triangle_Add_Click(object sender, EventArgs e)
        {
            var triangle = ShapeContainer.figures.Last();
            ((Triangle)triangle).AddDot(new PointF(float.Parse(Triangle_X.Text), float.Parse(Triangle_Y.Text)));
            Triangle_X.Text = "";
            Triangle_Y.Text = "";
        }
    }
}