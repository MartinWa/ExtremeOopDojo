using System;
using System.Data;
using System.Text.RegularExpressions;
using ExtremeOopDojo.Operands;

namespace ExtremeOopDojo.Command
{
    public abstract class BaseCommand
    {
        public static BaseCommand FromExpression(string expression)
        {
            var printOperator = Regex.Match(expression, @"PRINT(?<operand>.*)");
            var variableOperator = Regex.Match(expression, @"(?<variable>[a-zA-Z]+)\s*=\s*(?<value>.+)");
            if (string.IsNullOrEmpty(expression))
            {
                return new EmptyCommand();
            }
            if (printOperator.Success)
            {
                var operand = printOperator.Groups["operand"];
                return new PrintCommand(BaseOperand.FromOperand(operand.Value));
            }
            if (variableOperator.Success)
            {
                var variableName = variableOperator.Groups["variable"];
                var variableValue = variableOperator.Groups["value"];
                return VariableCommand.FromString(variableName.Value, variableValue.Value);
            }
            throw new InvalidExpressionException(String.Format("{0} is not a valid expression", expression));
        }

        public abstract override string ToString();
    }
}