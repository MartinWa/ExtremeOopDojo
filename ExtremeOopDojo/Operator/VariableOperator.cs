using System;
using System.Data;
using System.Globalization;

namespace ExtremeOopDojo.Operator
{
    public class VariableOperator : BaseOperator
    {
        private readonly string _name;
        private readonly int _value;

        public VariableOperator(string name, int value)
        {
            _name = name;
            _value = value;
        }

        public static VariableOperator FromString(string name, string stringValue)
        {
            int value;
            try
            {
                value = Int32.Parse(stringValue);
            }
            catch (Exception)
            {

                throw new InvalidExpressionException(String.Format("{0} is not a valid value", stringValue));
            }
            return new VariableOperator(name, value);
        }

        public override string ToString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }
    }
}