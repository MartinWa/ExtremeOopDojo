using System;
using System.Data;

namespace ExtremeOopDojo.Command
{
    public class VariableCommand : BaseCommand
    {
        private readonly string _name;
        private readonly int _value;

        public VariableCommand(string name, int value)
        {
            _name = name;
            _value = value;
        }

        public static VariableCommand FromString(string name, string stringValue)
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
            return new VariableCommand(name, value);
        }

        public override string Execute()
        {
            VariableList.Add(_name, _value);
            return ""; // Requirements states that assignments are not echoed
        }
    }
}