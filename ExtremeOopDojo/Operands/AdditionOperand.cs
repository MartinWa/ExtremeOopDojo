using System.Globalization;
using ExtremeOopDojo.Helpers;

namespace ExtremeOopDojo.Operands
{
    class AdditionOperand : BaseOperand
    {
        private readonly IntegerOperand _left;
        private readonly IntegerOperand _right;

        public AdditionOperand(IntegerOperand left, IntegerOperand right)
        {
            _left = left;
            _right = right;
        }

        public override string Execute(IVariableList variables)
        {
            return (_left.GetValue() + _right.GetValue()).ToString(CultureInfo.InvariantCulture);
        }
    }
}
