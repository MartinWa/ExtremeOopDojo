using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExtremeOopDojo
{
    public class UserInput
    {
        private readonly string _input;

        public UserInput(string input)
        {
            _input = input;
        }

        private void xfdsrg()
        {
            var expressions = new List<BaseExpression>();
            var i = 0;
            var statements = _input.Split(new[] { ';', ' ' }, StringSplitOptions.None);
            foreach (var statement in statements)
            {
                if (string.IsNullOrEmpty(statement))
                {
                    expressions.Add(new EmptyExpression());
                }
                if (statement == "PRINT")
                {
                    return new PrintExpression(null);
                }
                if (int.TryParse(statement, out i))
                {
                    return new IntegerOperand(i);
                }
                return new StringOperand(statement);

            }
        }

        public string Parse()
        {
            var returnValue = "";
            var statements = _input.Split(new[] { ';' }, StringSplitOptions.None);
            foreach (var statement in statements)
            {
                returnValue += ExpressionBase.toString();
                //if (statement != null && statement.Length == 0)
                //{
                //    returnValue = returnValue + "";
                //    continue;
                //}

                //if (statement == "PRINT")
                //{
                //    returnValue = returnValue + Environment.NewLine;
                //    continue;
                //}
                //var stringOperand = statement.Remove(0, 6);


                //returnValue += stringOperand.Replace("\"", "") + Environment.NewLine;
            }

            return returnValue;
        }
    }
}