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
        public Form1()
        {
            InitializeComponent();
            Init.bitmap = new
                Bitmap(pictureBox1.ClientSize.Width,
                    pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
            Init.pen = new Pen(Init.color, Init.weight);
            colorDialog1.FullOpen = true;
            colorDialog1.Color = Init.color;
        }

        private Stack<Operator> operators = new
            Stack<Operator>();

        private Stack<Operand> operands = new
            Stack<Operand>();

        private bool IsNotOperation(char item)
        {
            if (operators.Count != 0 && operators.Peek().symbolOperator == '(')
            {
                return !(item == ',' || item == '(' ||
                         item == ')' || item == ' ');
            }

            return !(item == 'A' || item == 'P' || item == 'M' || item
                     == 'D' || item == ',' || item == '(' ||
                     item == ')' || item == ' ');
        }

        private void SelectingPerformingOperation(Operator op)
        {
            switch (op.symbolOperator)
            {
                case 'A':
                    var stackOperand = operands.Select(operand => operand.value.ToString()).ToList();
                    stackOperand.Reverse();
                    var aPoints = new APoints(stackOperand[0]);
                    var length = Figure.Figure.ErrorClearParse(new[] {stackOperand[1]})[0] * 2;
                    for (var i = 0; i < length; i += 2)
                    {
                        aPoints.AddDot(new[] {stackOperand[i + 2], stackOperand[i + 3]});
                    }

                    ShapeContainer.AddFigure(aPoints);
                    //op.operatorMethod();
                    break;
                case 'P':
                    if (operands.Count != 3) throw new Exception("Invalid input");
                    var points = new List<PointF>();
                    foreach (var figure in ShapeContainer.figures.Where(figure =>
                                 figure.Name == operands.Peek().value.ToString()))
                    {
                        points.AddRange(figure.Points);
                        operands.Pop();
                    }

                    if (points.Count == 0)
                    {
                        throw new Exception("Invalid input");
                    }

                    var polygon = new Polygon(operands.Pop().value.ToString(), points);
                    polygon.Draw();
                    ShapeContainer.AddFigure(polygon);
                    //op.operatorMethod();
                    break;
                case 'M':

                    break;
                case 'D':

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
                        if (!char.IsDigit(inputChar))
                        {
                            operands.Push(new Operand(operands.Pop().value.ToString() + inputChar));
                        }
                        else
                        {
                            operands.Push(new Operand(operands.Pop().value.ToString() + inputChar));
                        }
                    }
                    else if (operands.Count == 0 || operands.Peek().value.ToString() != "")
                    {
                        operands.Push(new Operand(""));
                    }

                    switch (inputChar)
                    {
                        case 'A':
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(inputChar));
                            }

                            break;
                        }
                        case 'P':
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(inputChar));
                            }

                            break;
                        }
                        case 'M':
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(inputChar));
                            }

                            break;
                        }
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
                                operands = new Stack<Operand>();
                                operators = new Stack<Operator>();
                            }
                            else
                            {
                                Log_L.Text += @"Wrong operator";
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log_L.Text += exception.Message;
            }

            input_TB.Text = "";
        }
    }
}