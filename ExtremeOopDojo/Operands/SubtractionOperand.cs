using ExtremeOopDojo.Helpers;

namespace ExtremeOopDojo.Operands
{
    class SubtractionOperand : BaseOperand
    {
        private readonly IntegerOperand _left;
        private readonly IntegerOperand _right;

        public SubtractionOperand(IntegerOperand left, IntegerOperand right)
        {
            _left = left;
            _right = right;
        }

        public override string Execute(IVariableList variableList)
        {
            return (_left - _right).Execute(variableList);
        }
    }
}
