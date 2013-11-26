﻿using System.Globalization;

namespace ExtremeOopDojo.Operands
{
    public class VariableOperand : BaseOperand
    {
        private readonly string _variableName;

        public VariableOperand(string variableName)
        {
            _variableName = variableName;
        }
        public override string Execute(IVariableList variables)
        {
            return variables.Get(_variableName).ToString(CultureInfo.InvariantCulture);
        }
    }
}
