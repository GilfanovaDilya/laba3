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

            return !(item == 'A' || 
                     item == 'P' || 
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
                case 'A':
                    if (operands.Count < 4) throw new Exception($"Invalid input in {input_TB.Text}");
                    var stackOperand = operands.Select(operand => operand.value.ToString()).ToList();
                    stackOperand.Reverse();
                    var aPoints = new APoints(stackOperand[0]);
                    var length = Figure.Figure.ErrorClearParse(new[] {stackOperand[1]})[0] * 2;
                    if (length < stackOperand.Count - 2) throw new Exception($"Invalid input in {input_TB.Text}");
                    for (var i = 0; i < length; i += 2)
                    {
                        aPoints.AddDot(new[] {stackOperand[i + 2], stackOperand[i + 3]});
                    }

                    ShapeContainer.AddFigure(aPoints);
                    Log.Add($@"Array of points successfully added with name {aPoints.Name}");
                    //op.operatorMethod();
                    break;
                case 'P':
                    if (operands.Count != 2 ||
                        ShapeContainer.figures.All(figure => figure.Name != operands.Peek().value.ToString()))
                        throw new Exception($"Invalid input in {input_TB.Text}");
                    var points = new List<PointF>();
                    foreach (var figure in ShapeContainer.figures.Where(figure =>
                                 figure.Name == operands.Peek().value.ToString()))
                    {
                        points.AddRange(figure.Points);
                        operands.Pop();
                    }

                    var polygon = new Polygon(operands.Pop().value.ToString(), points);
                    polygon.Draw();
                    ShapeContainer.AddFigure(polygon);
                    Log.Add($@"Polygon {polygon.Name} is drawn successfully");
                    //op.operatorMethod();
                    break;
                case 'M':
                    if (operands.Count != 3) throw new Exception($"Invalid input in {input_TB.Text}");
                    var dy = Figure.Figure.ErrorClearParse(new[] {operands.Pop().value.ToString()})[0];
                    var dx = Figure.Figure.ErrorClearParse(new[] {operands.Pop().value.ToString()})[0];
                    var nameM = operands.Pop().value.ToString();
                    if (ShapeContainer.figures.All(figure => figure.Name != nameM))
                        throw new Exception($"Invalid input in {input_TB.Text}");
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
                        throw new Exception($"Invalid input in {input_TB.Text}");
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
                    else if (operands.Count == 0 || operands.Peek().value.ToString() != "")
                    {
                        operands.Push(new Operand(""));
                    }

                    switch (inputChar)
                    {
                        case 'A':
                        case 'P':
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