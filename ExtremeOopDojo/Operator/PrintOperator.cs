using System;

namespace ExtremeOopDojo.Operator
{
    public class PrintOperator : BaseOperator
    {
        private readonly BaseOperator _operand;

        public PrintOperator(BaseOperator operand)
        {
            _operand = operand;
        }

        public override string ToString()
        {
            return _operand + Environment.NewLine;
        }
    }
}