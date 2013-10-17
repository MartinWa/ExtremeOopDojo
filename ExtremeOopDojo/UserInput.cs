using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
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
                if (string.IsNullOrEmpty(expression))
                {
                    operators.Add(new EmptyOperator());
                }
                else if (Regex.IsMatch(expression, @"PRINT"))
                {
                    var operand = Regex.Match(@"PRINT(?<operand>.*)", expression).Groups["operand"].Value;
                    if (string.IsNullOrEmpty(operand))
                    {
                        operators.Add(new PrintOperator(new EmptyOperator()));
                    }
                    else if (Regex.IsMatch(@".*"))
                    {
                        

                    }
                }
                else if (Regex.IsMatch(expression, @"\w+\s*=\s*"))
                {
                    var valueString = Regex.Match(@"\w+\s*=\s*", expression).Groups["value"].Value;
                    int value;
                    try
                    {
                        value = Int32.Parse(valueString);
                    }
                    catch (Exception)
                    {

                        throw new InvalidExpressionException(String.Format("{0} is not a valid value", valueString));
                    }
                    operators.Add(new VariableOperator(value));
                }
                else throw new InvalidExpressionException(String.Format("{0} is not a valid expression", expression));
            }
            return operators;
        }
    }
}

//    public IEnumerable<BaseOperator> Parse()
//    {
//        var expressions = new List<BaseOperator>();
//        var statements = _input.Split(new[] { ';' }, StringSplitOptions.None);
//        var variableRegexp = new Regex(@"\w+\s*=\s*(?<value>/d+)");
//        var printRegexp = new Regex(@"PRINT\s*(?<operand>.*)");
//        foreach (var statement in statements)
//        {
//            // If the string is null
//            if (string.IsNullOrEmpty(statement))
//            {
//                expressions.Add(new EmptyOperator());
//            }
//            // If the string starts with PRINT
//            else if (printRegexp.Match(statement).Success)
//            {
//                // Handle the arguments to PRINT
//                expressions.Add(new PrintOperator(new StringOperand(printRegexp.Match(statement).Groups["operand"].Value)));
//            }
//            // If the string starts with a variable and then an equal sign
//            else if (variableRegexp.Match(statement).Success)
//            {
//                // Handle the argument to Variable
//                expressions.Add(new VariableOperator(variableRegexp.Match(statement).Groups["value"].Value));
//            }
//            // Not a valid expression
//            else throw new InvalidExpressionException(String.Format(">{0}< is not a valid expression", statement));
//        }
//        return expressions;
//    }
//}
