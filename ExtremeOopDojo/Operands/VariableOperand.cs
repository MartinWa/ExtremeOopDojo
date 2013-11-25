using System;

namespace ExtremeOopDojo.Operands
{
    public class VariableOperand : BaseOperand
    {
        private readonly string _variableName;

        public VariableOperand(string variableName)
        {
            _variableName = variableName;
        }
        public override string ToString()
        {
            return _variableName; // TODO, this should be converted to the value based on VariableCommands
        }
    }
}
