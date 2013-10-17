using System;
using ExtremeOopDojo.Operands;

namespace ExtremeOopDojo.Operator
{
    public class PrintOperator : BaseOperator
    {
        private readonly BaseOperand _operand;

        public PrintOperator(BaseOperand operand)
        {
            _operand = operand;
        }

        public override string ToString()
        {
            return _operand + Environment.NewLine;
        }
    }
}