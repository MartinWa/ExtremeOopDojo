using System;
using System.Data;
using System.Globalization;
using ExtremeOopDojo.Helpers;

namespace ExtremeOopDojo.Operands
{
    public class IntegerOperand : BaseOperand
    {
        private readonly int _value;

        public IntegerOperand(int value)
        {
            _value = value;
        }

        public override string Execute(IVariableList variableList)
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }

        public static IntegerOperand FromString(string stringValue)
        {
            int value;
            try
            {
                value = Int32.Parse(stringValue);
            }
            catch (Exception)
            {

                throw new InvalidExpressionException(String.Format("{0} is not a valid stringValue", stringValue));
            }
            return new IntegerOperand(value);
        }

        public static IntegerOperand operator +(IntegerOperand left, IntegerOperand right)
        {
            return new IntegerOperand(left._value + right._value);
        }

        public static IntegerOperand operator -(IntegerOperand left, IntegerOperand right)
        {
            return new IntegerOperand(left._value - right._value);
        }
    }
}