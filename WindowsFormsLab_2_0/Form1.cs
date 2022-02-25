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



        private void Rectangle_C_Click(object sender, EventArgs e)
        {
            var rectangle = new Figure.Rectangle(float.Parse(Rectangle_X.Text), float.Parse(Rectangle_Y.Text),
                float.Parse(Rectangle_W.Text), float.Parse(Rectangle_H.Text));
            rectangle.Draw();
            ShapeContainer.AddFigure(rectangle);
            Message();
        }

        private void Square_C_Click(object sender, EventArgs e)
        {
            var square = new Square(float.Parse(Square_X.Text), float.Parse(Square_Y.Text),
                float.Parse(Square_W.Text));
            square.Draw();
            ShapeContainer.AddFigure(square);
            Message();
        }

        private void ChangeLinearDimensions_GB_Enter(object sender, EventArgs e)
        {
            ChangeLinearDimensions_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures.Where(figure => figure.name.StartsWith("Rectangle") || figure.name.StartsWith("Square")))
            {
                ChangeLinearDimensions_CB.Items.Add(figure.name);
            }
        }

        private void ChangeLinearDimensions_B_Click(object sender, EventArgs e)
        {
            if (ChangeLinearDimensions_CB.SelectedIndex == -1)
            {
                Figure.Figure.Messages.Add("The figure to change is not selected. Try one more time)");
                Message();
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(
                         figure => figure.name == ChangeLinearDimensions_CB.SelectedItem.ToString()))
            {
                ((Figure.Rectangle) figure).ChangeLineDim(int.Parse(ChangeLinearDimensions_W.Text), int.Parse(ChangeLinearDimensions_H.Text));
                ChangeLinearDimensions_CB.SelectedIndex = -1;
                ChangeLinearDimensions_CB.Text = "";
                ChangeLinearDimensions_W.Text = "";
                ChangeLinearDimensions_H.Text = "";
                return;
            }
            ChangeLinearDimensions_CB.SelectedIndex = -1;
        }

        private void Ellipse_C_Click(object sender, EventArgs e)
        {
            var ellipse = new Figure.Ellipse(float.Parse(Ellipse_X.Text), float.Parse(Ellipse_Y.Text),
                float.Parse(Ellipse_W.Text), float.Parse(Ellipse_H.Text));
            ellipse.Draw();
            ShapeContainer.AddFigure(ellipse);
            Message();
        }

        private void Circle_C_Click(object sender, EventArgs e)
        {
            var circle = new Circle(float.Parse(Circle_X.Text), float.Parse(Circle_Y.Text),
                float.Parse(Circle_W.Text));
            circle.Draw();
            ShapeContainer.AddFigure(circle);
            Message();
        }

        private void ChangeRadius_Enter(object sender, EventArgs e)
        {
            ChangeRadius_GB.Items.Clear();
            foreach (var figure in ShapeContainer.figures.Where(figure => figure.name.StartsWith("Circle")))
            {
                ChangeRadius_GB.Items.Add(figure.name);
            }
        }

        private void ChangeRadius_B_Click(object sender, EventArgs e)
        {
            if (ChangeRadius_GB.SelectedIndex == -1)
            {
                Figure.Figure.Messages.Add("The circle to change is not selected. Try one more time)");
                Message();
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(
                         figure => figure.name == ChangeRadius_GB.SelectedItem.ToString()))
            {
                ((Circle) figure).ChangeLineDim(int.Parse(ChangeRadius_R.Text));
                ChangeRadius_GB.SelectedIndex = -1;
                ChangeRadius_GB.Text = "";
                ChangeRadius_R.Text = "";
                return;
            }
            ChangeRadius_GB.SelectedIndex = -1;
        }

        private void Sun_C_Click(object sender, EventArgs e)
        {
            var sun = new Sun(double.Parse(Sun_X.Text), double.Parse(Sun_Y.Text),
                double.Parse(Sun_W.Text));
            sun.Draw();
            ShapeContainer.AddFigure(sun);
            Message();
        }

        private void Polygon_N_Click(object sender, EventArgs e)
        {
            Polygon_X.Text = "";
            Polygon_Y.Text = "";
            Polygon_X.Enabled = true;
            Polygon_Y.Enabled = true;
            Polygon_Add.Enabled = true;
            ShapeContainer.AddFigure(new Polygon());
            Message();
        }

        private void Polygon_Add_Click(object sender, EventArgs e)
        {
            var polygon = ShapeContainer.figures.Last();
            ((Polygon) polygon).AddDot(new PointF(float.Parse(Polygon_X.Text), float.Parse(Polygon_Y.Text)));
            Polygon_X.Text = "";
            Polygon_Y.Text = "";
            Message();
        }

        private void Triangle_N_Click(object sender, EventArgs e)
        {
            Triangle_X.Text = "";
            Triangle_Y.Text = "";
            Triangle_X.Enabled = true;
            Triangle_Y.Enabled = true;
            Triangle_Add.Enabled = true;
            ShapeContainer.AddFigure(new Triangle());
            Message();
        }

        private void Triangle_Add_Click(object sender, EventArgs e)
        {
            var triangle = ShapeContainer.figures.Last();
            ((Triangle) triangle).AddDot(new PointF(float.Parse(Triangle_X.Text), float.Parse(Triangle_Y.Text)));
            Triangle_X.Text = "";
            Triangle_Y.Text = "";
            Message();
        }

        private void Message()
        {
            label1.Text = "";
            if (Figure.Figure.Messages == null) return;
            foreach (var mess in Figure.Figure.Messages)
            {
                label1.Text += mess + "\n";
            }

            Figure.Figure.Messages.Clear();
        }


        private void Move_GB_Enter(object sender, EventArgs e)
        {
            Move_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures)
            {
                Move_CB.Items.Add(figure.name);
            }
        }

        private void Move_B_Click(object sender, EventArgs e)
        {
            if (Move_CB.SelectedIndex == -1)
            {
                Figure.Figure.Messages.Add("The figure to move is not selected. Try one more time)");
                Message();
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(
                         figure => figure.name == Move_CB.SelectedItem.ToString()))
            {
                figure.MoveTo(Convert.ToInt32(Move_X.Text), Convert.ToInt32(Move_Y.Text));
                Move_CB.SelectedIndex = -1;
                Move_CB.Text = "";
                Move_X.Text = "";
                Move_Y.Text = "";
                return;
            }

            Move_CB.SelectedIndex = -1;
        }

        private void Delete_Enter(object sender, EventArgs e)
        {
            Delete_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures)
            {
                Delete_CB.Items.Add(figure.name);
            }
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if (Delete_CB.SelectedIndex == -1)
            {
                Figure.Figure.Messages.Add("The figure to delete is not selected. Try one more time)");
                Message();
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(figure =>
                         figure.name == Delete_CB.SelectedItem.ToString()))
            {
                figure.DeleteF(figure, Init.pictureBox);
                Delete_CB.SelectedIndex = -1;
                Delete_CB.Text = "";
                return;
            }

            Delete_CB.SelectedIndex = -1;
        }


    }
}