using System;
using System.Collections.Generic;
using System.Data;
using ExtremeOopDojo.Command;

namespace ExtremeOopDojo
{
    public class CommodoreC64
    {
        public string Interpret(UserInput input)
        {
            var returnString = "";
            IEnumerable<BaseCommand> expressions;
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
                returnString += expression.Execute();
            }
            return returnString;
        }
    }
}