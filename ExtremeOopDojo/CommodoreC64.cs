using System;
using System.Collections.Generic;
using System.Data;
using ExtremeOopDojo.Command;
using ExtremeOopDojo.Operands;

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

            var variables = new Dictionary<string, int>();
            foreach (var expression in expressions)
            {
                var command = expression as VariableCommand;
                if (command != null)
                {
                    var variable = command;
                    variables.Add(variable.GetName(), variable.GetValue());
                }
                else returnString += expression.ToString();
            }
            return returnString;
        }
    }
}