using ExtremeOopDojo.Helpers;

namespace ExtremeOopDojo.Operands
{
    public class StringOperand : BaseOperand
    {
        private readonly string _statement;

        public StringOperand(string statement)
        {
            _statement = statement;
        }

        public override string Execute(IVariableList variableList)
        {
            return _statement;
        }
    }
}