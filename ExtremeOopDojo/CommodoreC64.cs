using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using ExtremeOopDojo.Operator;

namespace ExtremeOopDojo
{
    public class CommodoreC64
    {
        public string Interpret(UserInput input)
        {
            var returnString = "";
            IEnumerable<BaseOperator> expressions;
            try
            {
                expressions = input.Parse();
            }
            catch (InvalidExpressionException ex)
            {
                return String.Format("Error: {0}", ex.Message);
            }
            
            foreach (var expression in expressions)
            {
                returnString += expression.ToString();
            }
            return returnString;
        }
    }
}