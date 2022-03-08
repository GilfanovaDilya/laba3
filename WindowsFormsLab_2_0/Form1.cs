using Figure;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
            }
            Message();
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
            }
            Message();
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
                    ((Figure.Rectangle)figure).ChangeLineDim(Figure.Figure.ErrorClearParse(new string[] { ChangeLinearDimensions_W.Text, ChangeLinearDimensions_H.Text }));
                    ChangeRadius_GB.SelectedIndex = -1;
                    ChangeRadius_GB.Text = "";
                    ChangeRadius_R.Text = "";
                }
                ChangeRadius_GB.SelectedIndex = -1;
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
            }
            Message();
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
            }
            Message();
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
            }
            Message();
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
                }
                ChangeRadius_GB.SelectedIndex = -1;
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
            }
            Message();
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
            }
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
            try
            {
                var polygon = ShapeContainer.figures.Last();
                var coord = Figure.Figure.ErrorClearParse(new string[] { Polygon_X.Text, Polygon_Y.Text });
                ((Polygon)polygon).AddDot(new PointF(coord[0], coord[1]));
                Polygon_X.Text = "";
                Polygon_Y.Text = "";
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
            }
            Message();
        }

        private void Polygon_Leave(object sender, EventArgs e)
        {
            Polygon_X.Enabled = false;
            Polygon_Y.Enabled = false;
            Polygon_Add.Enabled = false;
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
            }
            Message();
        }

        private void Triangle_Leave(object sender, EventArgs e)
        {
            Triangle_X.Enabled = false;
            Triangle_Y.Enabled = false;
            Triangle_Add.Enabled = false;
            Message();
        }

        private void Changes_CB_Enter(object sender, EventArgs e)
        {
            Changes_CB.Items.Clear();
            foreach (var figure in ShapeContainer.figures)
            {
                Changes_CB.Items.Add(figure.Name);
            }
        }

        private void Move_B_Click(object sender, EventArgs e)
        {
            if (Changes_CB.SelectedIndex == -1)
            {
                Figure.Figure.Messages.Add("The figure to move is not selected. Try one more time)");
                Message();
                return;
            }

            try
            {
                foreach (var figure in ShapeContainer.figures.Where(
                             figure => figure.Name == Changes_CB.SelectedItem.ToString()))
                {
                    figure.MoveTo(Figure.Figure.ErrorClearParse(new[] { Move_X.Text, Move_Y.Text }));
                    Move_X.Text = "";
                    Move_Y.Text = "";
                }
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
            }
            Message();
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if (Changes_CB.SelectedIndex == -1)
            {
                Figure.Figure.Messages.Add("The figure to delete is not selected. Try one more time)");
                Message();
                return;
            }

            try
            {
                foreach (var figure in ShapeContainer.figures.Where(figure =>
                             figure.Name == Changes_CB.SelectedItem.ToString()))
                {
                    figure.DeleteF(figure, Init.pictureBox);
                }
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception exception)
            {
                Figure.Figure.Messages.Add(exception.Message);
            }
            Message();
        }

        private void ChangeColor_tb_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ChangeColor_tb.BackColor = colorDialog1.Color;
        }

        private void ChangeColor_B_Click(object sender, EventArgs e)
        {
            if (Changes_CB.SelectedIndex == -1)
            {
                Init.pen = new Pen(ChangeColor_tb.BackColor, Init.weight);
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(figure =>
                         figure.Name == Changes_CB.SelectedItem.ToString()))
            {
                figure.ChangeColor(figure, ChangeColor_tb.BackColor);
            }
            Message();
        }

        private void ChangeWeight_B_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(ChangeWeight_tb.Text, out var newWeight))
            {
                Figure.Figure.Messages.Add("Your enter invalid number. Try one more time)");
                Message();
                return;
            }
            if (Changes_CB.SelectedIndex == -1)
            {
                Init.pen = new Pen(Init.color, newWeight);
                return;
            }

            foreach (var figure in ShapeContainer.figures.Where(figure =>
                         figure.Name == Changes_CB.SelectedItem.ToString()))
            {
                figure.ChangeWeight(figure, newWeight);
            }
            Message();
        }

        private void Rectangle_M_B_Click(object sender, EventArgs e)
        {
            Rectangle_GB.Location = new Point(1205, 12);
            Rectangle_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Square_M_B_Click(object sender, EventArgs e)
        {
            Square_GB.Location = new Point(1205, 12);
            Square_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Ellipse_M_B_Click(object sender, EventArgs e)
        {
            Ellipse_GB.Location = new Point(1205, 12);
            Ellipse_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Circle_M_B_Click(object sender, EventArgs e)
        {
            Circle_GB.Location = new Point(1205, 12);
            Circle_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Polygon_M_B_Click(object sender, EventArgs e)
        {
            Polygon_GB.Location = new Point(1205, 12);
            Polygon_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Triangle_M_B_Click(object sender, EventArgs e)
        {
            Triangle_GB.Location = new Point(1205, 12);
            Triangle_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Sun_M_B_Click(object sender, EventArgs e)
        {
            Sun_GB.Location = new Point(1205, 12);
            Sun_GB.Visible = true;
            Menu_GB.Visible = false;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Menu_GB.Visible = true;
            Rectangle_GB.Visible = false;
            Square_GB.Visible = false;
            Ellipse_GB.Visible = false;
            Circle_GB.Visible = false;
            Polygon_GB.Visible = false;
            Triangle_GB.Visible = false;
            Sun_GB.Visible = false;
        }
    }
}