using System.Globalization;
using ExtremeOopDojo.Helpers;

namespace ExtremeOopDojo.Operands
{
    public class VariableOperand : BaseOperand
    {
        private readonly string _variableName;

        public VariableOperand(string variableName)
        {
            _variableName = variableName;
        }
        public override string Execute(IVariableList variableList)
        {
            return variableList.Get(_variableName).ToString(CultureInfo.InvariantCulture);
        }
    }
}
