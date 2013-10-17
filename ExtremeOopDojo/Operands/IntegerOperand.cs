using System.Globalization;

namespace ExtremeOopDojo.Operands
{
    public class IntegerOperand : BaseOperand
    {
        private readonly int _value;

        public IntegerOperand(int value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }
    }
}