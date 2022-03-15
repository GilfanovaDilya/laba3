using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsLab_2_0
{
    public static class OperatorContainer
    {
        public static List<Operator> operators = new
            List<Operator>();

        static OperatorContainer()
        {
            operators.Add(new Operator('A'));
            operators.Add(new Operator('P'));
            operators.Add(new Operator('M'));
            operators.Add(new Operator('D'));
            operators.Add(new Operator(','));
            operators.Add(new Operator('('));
            operators.Add(new Operator(')'));
        }

        public static Operator FindOperator(char s)
        {
            return operators.FirstOrDefault(op => op.symbolOperator == s);
        }
    }
}