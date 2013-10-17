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
            var variables = new Dictionary<string,int>();
            foreach (var expression in expressions)
            {
                var printOperator = Regex.Match(expression, @"PRINT(?<operand>.*)");
                var variableOperator = Regex.Match(expression, @"(?<variable>[a-zA-Z]+)\s*=\s*(?<value>.+)");
                if (string.IsNullOrEmpty(expression))
                {
                    operators.Add(new EmptyOperator());
                }
                else if (printOperator.Success)
                {
                    var operand = printOperator.Groups["operand"].Value;
                    var stringOperand = Regex.Match(operand, @"""(?<string>.*)""");
                    var integerOperand = Regex.Match(operand, @"\s*(?<integer>-*\d+)\s*");
                    var variableOperand = Regex.Match(operand, @"\s*(?<variable>[a-zA-Z]+)\s*");
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
                    else if (variableOperand.Success)
                    {
                        var variableName = variableOperand.Groups["variable"].Value;
                        if (variables.ContainsKey(variableName))
                        {
                            operators.Add(new PrintOperator(new IntegerOperand(variables[variableName])));
                        }
                        else
                        {
                            operators.Add(new PrintOperator(new IntegerOperand(0)));
                        }
                    }
                    else
                    {
                        throw new InvalidExpressionException(String.Format("{0} is not a valid operand", operand));
                    }
                }
                else if (variableOperator.Success)
                {
                    var name = variableOperator.Groups["variable"].Value;
                    var stringValue = variableOperator.Groups["value"].Value;
                    int value;
                    try
                    {
                        value = Int32.Parse(stringValue);
                    }
                    catch (Exception)
                    {

                        throw new InvalidExpressionException(String.Format("{0} is not a valid value", stringValue));
                    }
                    variables.Add(name, value);
                }
                else throw new InvalidExpressionException(String.Format("{0} is not a valid expression", expression));
            }
            return operators;
        }
    }
}