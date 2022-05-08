using Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsLab_2_0
{
    public partial class Form1 : Form
    {
        private List<string> Log = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new
                Bitmap(pictureBox1.ClientSize.Width,
                    pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
            Init.pen = new Pen(Init.color, Init.weight);
        }

        private Stack<Operator> operators = new
            Stack<Operator>();

        private Stack<Operand> operands = new
            Stack<Operand>();

        private bool IsNotOperation(char item)
        {
            if (operators.Count != 0 && operators.Peek().symbolOperator == '(')
            {
                return !(item == ',' ||
                         item == '(' ||
                         item == ')' ||
                         item == ' ' );
            }

            return !(item == 'E' || 
                     item == 'M' || 
                     item == 'D' || 
                     item == ',' || 
                     item == '(' || 
                     item == ')' || 
                     item == ' ' );
        }

        private void SelectingPerformingOperation(Operator op)
        {
            switch (op.symbolOperator)
            {
                case 'E':
                    if (operands.Count != 5) throw new Exception($"Invalid input in {input_TB.Text}");
                    var h = Figure.Figure.ErrorClearParse(new[] { operands.Pop().value.ToString() })[0];
                    var w = Figure.Figure.ErrorClearParse(new[] { operands.Pop().value.ToString() })[0];
                    var y = Figure.Figure.ErrorClearParse(new[] { operands.Pop().value.ToString() })[0];
                    var x = Figure.Figure.ErrorClearParse(new[] { operands.Pop().value.ToString() })[0];
                    var name = operands.Pop().value.ToString();
                    if (ShapeContainer.figures.FirstOrDefault(figure => figure.Name == name) != null)
                    {
                        throw new Exception($"Invalid input in {input_TB.Text}");
                    }

                    var EllipseF = new Ellipse(new[] {x, y, w, h}, name);
                    EllipseF.Draw();
                    ShapeContainer.AddFigure(EllipseF);
                    Log.Add($@"Ellipse {EllipseF.Name} is drawn successfully");
                    break;
                case 'M':
                    if (operands.Count != 3) throw new Exception($"Invalid input in {input_TB.Text}");
                    var dy = Figure.Figure.ErrorClearParse(new[] {operands.Pop().value.ToString()})[0];
                    var dx = Figure.Figure.ErrorClearParse(new[] {operands.Pop().value.ToString()})[0];
                    var nameM = operands.Pop().value.ToString();
                    if (ShapeContainer.figures.All(figure => figure.Name != nameM))
                    {
                        throw new Exception($"Invalid input in {input_TB.Text}");
                    }
                    foreach (var figure in ShapeContainer.figures.Where(figure => figure.Name == nameM))
                    {
                        figure.MoveTo(new[] {dx, dy});
                    }

                    Log.Add($@"Polygon {nameM} is moved successfully");
                    break;
                case 'D':
                    if (operands.Count != 1) throw new Exception($"Invalid input in {input_TB.Text}");
                    var nameD = operands.Pop().value.ToString();
                    if (ShapeContainer.figures.All(figure => figure.Name != nameD))
                    {
                        throw new Exception($"Invalid input in {input_TB.Text}");
                    }
                    foreach (var figure in ShapeContainer.figures.Where(figure => figure.Name == nameD))
                    {
                        figure.DeleteF(figure, Init.pictureBox);
                    }

                    Log.Add($@"Polygon {nameD} is deleted successfully");
                    break;
            }
        }

        private void input_TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                foreach (var inputChar in input_TB.Text)
                {
                    if (IsNotOperation(inputChar))
                    {
                        operands.Push(new Operand(operands.Pop().value.ToString() + inputChar));
                    }
                    else if (operands.Count == 0 || operands.Peek().value.ToString() != string.Empty)
                    {
                        operands.Push(new Operand(""));
                    }

                    switch (inputChar)
                    {
                        case 'E':
                        case 'M':
                        case 'D':
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(inputChar));
                            }

                            break;
                        }

                        case '(':
                            operators.Push(OperatorContainer.FindOperator(inputChar));
                            break;
                        case ')':
                        {
                            do
                            {
                                if (operators.Peek().symbolOperator == '(')
                                {
                                    operators.Pop();
                                    break;
                                }

                                if (operators.Count == 0)
                                {
                                    break;
                                }
                            } while (operators.Peek().symbolOperator != '(');

                            if (operators.Peek() != null)
                            {
                                operands.Pop();
                                SelectingPerformingOperation(operators.Peek());
                            }
                            else
                            {
                                Log.Add(@"Wrong operator");
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Add(exception.Message);
            }

            Log_L.Text = "";
            for (var i = Log.Count - 1; i >= 0; i--)
            {
                Log_L.Text += Log[i] + "\n";
            }

            input_TB.Text = "";
            operands = new Stack<Operand>();
            operators = new Stack<Operator>();
        }
    }
}