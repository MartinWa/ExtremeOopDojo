using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using ExtremeOopDojo.Command;
using ExtremeOopDojo.Operands;

namespace ExtremeOopDojo
{
    public class UserInput
    {
        private readonly string _input;

        public UserInput(string input)
        {
            _input = input;
        }

        public IEnumerable<BaseCommand> Parse()
        {
            var expressions = _input.Split(new[] { ';' }, StringSplitOptions.None);
            return expressions.Select(ParseExpression).ToList();
        }

        private BaseCommand ParseExpression(string expression)
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
                return new PrintCommand(ParsePrintOperand(operand.Value));
            }
            if (variableOperator.Success)
            {
                var variableName = variableOperator.Groups["variable"];
                var variableValue = variableOperator.Groups["value"];
                return VariableCommand.FromString(variableName.Value, variableValue.Value);
            }
            throw new InvalidExpressionException(String.Format("{0} is not a valid expression", expression));
        }

        private BaseOperand ParsePrintOperand(string operand)
        {
            var stringOperand = Regex.Match(operand, @"""(?<string>.*)""");
            var integerOperand = Regex.Match(operand, @"\s*(?<integer>-*\d+)\s*");
            var variableOperand = Regex.Match(operand, @"\s*(?<variable>[a-zA-Z]+)\s*");
            if (string.IsNullOrEmpty(operand))
            {
                return new EmptyOperand();
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
    }
}