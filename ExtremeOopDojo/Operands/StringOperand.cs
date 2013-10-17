using ExtremeOopDojo.Operator;

namespace ExtremeOopDojo.Operands
{
    public class StringOperand : BaseOperator
    {
        private readonly string _statement;

        public StringOperand(string statement)
        {
            _statement = statement;
        }

        public override string ToString()
        {
            return _statement;
        }
    }
}