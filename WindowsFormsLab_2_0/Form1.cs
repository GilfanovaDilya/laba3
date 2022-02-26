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
            Init.pen = new Pen(Init.color, Init.weight);
            ChangeColor_tb.BackColor = Init.color;
            ChangeWeight_tb.Text = Init.weight.ToString();
            colorDialog1.FullOpen = true;
            colorDialog1.Color = Init.color;
        }



        private void Rectangle_C_Click(object sender, EventArgs e)
        {
            try
            {
                var rectangle = new Figure.Rectangle(Figure.Figure.ErrorClearParse(new string[]{Rectangle_X.Text, Rectangle_Y.Text,
                    Rectangle_W.Text, Rectangle_H.Text}));
                rectangle.Draw();
                ShapeContainer.AddFigure(rectangle);
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
        }

        private void Square_C_Click(object sender, EventArgs e)
        {
            try
            {
                var square = new Square(Figure.Figure.ErrorClearParse(new string[]{Square_X.Text, Square_Y.Text,
                    Square_W.Text}));
                square.Draw();
                ShapeContainer.AddFigure(square);
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
        }

        private void ChangeLinearDimensions_GB_Enter(object sender, EventArgs e)
        {
            ChangeLinearDimensions_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures.Where(figure => figure.Name.StartsWith("Rectangle") || figure.Name.StartsWith("Square")))
            {
                ChangeLinearDimensions_CB.Items.Add(figure.Name);
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

            try
            {
                foreach (var figure in ShapeContainer.figures.Where(
                             figure => figure.Name == ChangeLinearDimensions_CB.SelectedItem.ToString()))
                {
                    ((Figure.Rectangle)figure).ChangeLineDim(Figure.Figure.ErrorClearParse(new string[] {ChangeLinearDimensions_W.Text, ChangeLinearDimensions_H.Text}));
                    ChangeRadius_GB.SelectedIndex = -1;
                    ChangeRadius_GB.Text = "";
                    ChangeRadius_R.Text = "";
                    return;
                }
                ChangeRadius_GB.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
        }

        private void Ellipse_C_Click(object sender, EventArgs e)
        {
            try
            {
                var ellipse = new Ellipse(Figure.Figure.ErrorClearParse(new string[]{Ellipse_X.Text, Ellipse_Y.Text,
                    Ellipse_W.Text, Ellipse_H.Text}));
                ellipse.Draw();
                ShapeContainer.AddFigure(ellipse);
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
        }

        private void Circle_C_Click(object sender, EventArgs e)
        {
            try
            {
                var circle = new Circle(Figure.Figure.ErrorClearParse(new string[]{Circle_X.Text, Circle_Y.Text,
                    Circle_W.Text}));
                circle.Draw();
                ShapeContainer.AddFigure(circle);
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
        }

        private void ChangeRadius_Enter(object sender, EventArgs e)
        {
            ChangeRadius_GB.Items.Clear();
            foreach (var figure in ShapeContainer.figures.Where(figure => figure.Name.StartsWith("Circle")))
            {
                ChangeRadius_GB.Items.Add(figure.Name);
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
            try
            {
                foreach (var figure in ShapeContainer.figures.Where(
                             figure => figure.Name == ChangeRadius_GB.SelectedItem.ToString()))
                {
                    ((Circle)figure).ChangeLineDim(Figure.Figure.ErrorClearParse(new string[] { ChangeRadius_R.Text }));
                    ChangeRadius_GB.SelectedIndex = -1;
                    ChangeRadius_GB.Text = "";
                    ChangeRadius_R.Text = "";
                    return;
                }
                ChangeRadius_GB.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
        }

        private void Sun_C_Click(object sender, EventArgs e)
        {
            try
            {
                var sun = new Sun(Figure.Figure.ErrorClearParse(new string[]{Sun_X.Text, Sun_Y.Text,
                    Sun_W.Text}));
                sun.Draw();
                ShapeContainer.AddFigure(sun);
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
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
            try
            {
                var polygon = ShapeContainer.figures.Last();
                var coord = Figure.Figure.ErrorClearParse(new string[] {Polygon_X.Text, Polygon_Y.Text});
                ((Polygon) polygon).AddDot(new PointF(coord[0], coord[1]));
                Polygon_X.Text = "";
                Polygon_Y.Text = "";
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
            Message();
        }

        private void Polygon_Leave(object sender, EventArgs e)
        {
            Polygon_X.Enabled = false;
            Polygon_Y.Enabled = false;
            Polygon_Add.Enabled = false;
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
            try
            {
                var triangle = ShapeContainer.figures.Last();
                var coord = Figure.Figure.ErrorClearParse(new[] { Triangle_X.Text, Triangle_Y.Text });
                ((Triangle)triangle).AddDot(new PointF(coord[0], coord[1]));
                Triangle_X.Text = "";
                Triangle_Y.Text = "";
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
            Message();
        }

        private void Triangle_Leave(object sender, EventArgs e)
        {
            Triangle_X.Enabled = false;
            Triangle_Y.Enabled = false;
            Triangle_Add.Enabled = false;
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
                Move_CB.Items.Add(figure.Name);
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

            try
            {
                foreach (var figure in ShapeContainer.figures.Where(
                             figure => figure.Name == Move_CB.SelectedItem.ToString()))
                {
                    figure.MoveTo(Figure.Figure.ErrorClearParse(new []{ Move_X.Text , Move_Y.Text }));
                    Move_CB.SelectedIndex = -1;
                    Move_CB.Text = "";
                    Move_X.Text = "";
                    Move_Y.Text = "";
                    return;
                }

                Move_CB.SelectedIndex = -1;
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
                Message();
            }
            
        }

        private void Delete_Enter(object sender, EventArgs e)
        {
            Delete_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures)
            {
                Delete_CB.Items.Add(figure.Name);
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
                         figure.Name == Delete_CB.SelectedItem.ToString()))
            {
                figure.DeleteF(figure, Init.pictureBox);
                Delete_CB.SelectedIndex = -1;
                Delete_CB.Text = "";
                return;
            }

            Delete_CB.SelectedIndex = -1;
        }

        private void ChangeColor_Enter(object sender, EventArgs e)
        {
            ChangeColor_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures)
            {
                ChangeColor_CB.Items.Add(figure.Name);
            }
        }

        private void ChangeColor_tb_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ChangeColor_tb.BackColor = colorDialog1.Color;
        }

        private void ChangeColor_B_Click(object sender, EventArgs e)
        {
            if (ChangeColor_CB.SelectedIndex == -1)
            {
                Init.pen = new Pen(ChangeColor_tb.BackColor, Init.weight);
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(figure =>
                         figure.Name == ChangeColor_CB.SelectedItem.ToString()))
            {
                figure.ChangeColor(figure, ChangeColor_tb.BackColor);
                ChangeColor_CB.SelectedIndex = -1;
                return;
            }
        }

        private void ChangeWeight_Enter(object sender, EventArgs e)
        {
            ChangeWeight_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures)
            {
                ChangeWeight_CB.Items.Add(figure.Name);
            }
        }

        private void ChangeWeight_B_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ChangeWeight_tb.Text, out var newWeight))
            {
                Figure.Figure.Messages.Add("Your enter invalid number. Try one more time)");
                Message();
                return;
            }
            if (ChangeWeight_CB.SelectedIndex == -1)
            {
                Init.pen = new Pen(Init.color, newWeight);
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(figure =>
                         figure.Name == ChangeWeight_CB.SelectedItem.ToString()))
            {
                figure.ChangeWeight(figure, newWeight);
                ChangeWeight_CB.SelectedIndex = -1;
                return;
            }
        }
    }
}