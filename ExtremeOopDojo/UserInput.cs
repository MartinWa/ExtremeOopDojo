using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using ExtremeOopDojo.Operands;
using ExtremeOopDojo.Operator;

namespace ExtremeOopDojo
{
    public class UserInput
    {
        private readonly string _input;

        public UserInput(string input)
        {
            _input = input;
        }

        public IEnumerable<BaseOperator> Parse()
        {
            var expressions = _input.Split(new[] { ';' }, StringSplitOptions.None);
            var operators = new List<BaseOperator>();
            foreach (var expression in expressions)
            {
                var printOperand = Regex.Match(expression, @"PRINT(?<operand>.*)");
                var variableOperand = Regex.Match(expression, @"(?<variable>[a-zA-Z]+)\s*=\s*(?<value>.+)");
                if (string.IsNullOrEmpty(expression))
                {
                    operators.Add(new EmptyOperator());
                }
                else if (printOperand.Success)
                {
                    var operand = printOperand.Groups["operand"].Value;
                    var stringOperand = Regex.Match(operand, @"""(?<string>.*)""");
                    var integerOperand = Regex.Match(operand, @"\s*(?<integer>\d+)\s*");
                    if (string.IsNullOrEmpty(operand))
                    {
                        operators.Add(new PrintOperator(new EmptyOperand()));
                    }
                    else if (stringOperand.Success)
                    {
                        operators.Add(new PrintOperator(new StringOperand(stringOperand.Groups["string"].Value)));
                    }
                    else if (integerOperand.Success)
                    {
                        operators.Add(new PrintOperator(IntegerOperand.FromString(integerOperand.Groups["integer"].Value)));
                    }
                    else
                    {
                        throw new InvalidExpressionException(String.Format("{0} is not a valid operand", operand));
                    }
                }
                else if (variableOperand.Success)
                {
                    operators.Add(VariableOperator.FromString(variableOperand.Groups["variable"].Value,
                                                              variableOperand.Groups["value"].Value));
                }
                else throw new InvalidExpressionException(String.Format("{0} is not a valid expression", expression));
            }
            return operators;
        }
    }
}