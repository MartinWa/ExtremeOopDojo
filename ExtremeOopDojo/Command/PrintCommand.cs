using System;
using ExtremeOopDojo.Operands;

namespace ExtremeOopDojo.Command
{
    public class PrintCommand : BaseCommand
    {
        private readonly BaseOperand _operand;

        public PrintCommand(BaseOperand operands)
        {
            _operand = operands;
        }

        public override string ToString()
        {
            return _operand + Environment.NewLine;
        }
    }
}