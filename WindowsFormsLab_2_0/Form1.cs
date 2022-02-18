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
            var figure1 = new Square(x - w / 2.0, y - w / 2.0, w);
            var figure2 = new MPoint(x, y);
            Sun figureSun = new Sun(x, y, w);
            figureSun.Draw();
            ShapeContainer.AddFigure(figureSun);
            figure1.Draw();
            ShapeContainer.AddFigure(figure1);
            figure2.Draw();
            ShapeContainer.AddFigure(figure2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            foreach (Figure.Figure sFigure in ShapeContainer.figures.ToList())
            {
                sFigure.MoveTo(x,y);
            }
        }
    }
}