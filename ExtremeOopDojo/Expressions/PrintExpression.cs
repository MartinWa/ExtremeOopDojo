using System;

namespace ExtremeOopDojo
{
    public class PrintExpression : BaseExpression
    {
        private readonly BaseExpression _operand;

        public PrintExpression(BaseExpression operand)
        {
            _operand = operand;
        }

        public override string Parse()
        {
            return _operand.Parse() + Environment.NewLine;
        }
    }
}