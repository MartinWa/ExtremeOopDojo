using System;
using System.Data;
using System.Text.RegularExpressions;
using ExtremeOopDojo.Helpers;

namespace ExtremeOopDojo.Operands
{
    public abstract class BaseOperand
    {
        public static BaseOperand FromOperand(string operand)
        {
            var additionOperand = Regex.Match(operand, @"\s*(?<integer1>-*\d+)\s+\+\s+(?<integer2>-*\d+)\s*");
            var subtractionOperand = Regex.Match(operand, @"\s*(?<integer1>-*\d+)\s+-\s+(?<integer2>-*\d+)\s*");
            var stringOperand = Regex.Match(operand, @"""(?<string>.*)""");
            var integerOperand = Regex.Match(operand, @"\s*(?<integer>-*\d+)\s*");
            var variableOperand = Regex.Match(operand, @"\s*(?<variable>[a-zA-Z]+)\s*");
            if (string.IsNullOrEmpty(operand))
            {
                return new EmptyOperand();
            }
            if (additionOperand.Success)
            {
                var integer1 = additionOperand.Groups["integer1"];
                var integer2 = additionOperand.Groups["integer2"];
                return new AdditionOperand(IntegerOperand.FromString(integer1.Value), IntegerOperand.FromString(integer2.Value));
            }
            if (subtractionOperand.Success)
            {
                var integer1 = subtractionOperand.Groups["integer1"];
                var integer2 = subtractionOperand.Groups["integer2"];
                return new SubtractionOperand(IntegerOperand.FromString(integer1.Value), IntegerOperand.FromString(integer2.Value));
            }
            if (stringOperand.Success)
            {
                var str = stringOperand.Groups["string"];
                return new StringOperand(str.Value);
            }
            if (integerOperand.Success)
            {
                var integer = integerOperand.Groups["integer"];
                return IntegerOperand.FromString(integer.Value);
            }
            if (variableOperand.Success)
            {
                var variable = variableOperand.Groups["variable"];
                return new VariableOperand(variable.Value);
            }
            throw new InvalidExpressionException(String.Format("{0} is not a valid operand", operand));
        }
        public abstract string Execute(IVariableList variableList);
    }
}