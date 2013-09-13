using System;

namespace ExtremeOopDojo
{
    public class UserInput
    {
        private readonly string _input;

        public UserInput(string input)
        {
            _input = input;
        }

        public string Parse()
        {
            var returnValue = "";
            var statements = _input.Split(new[]{';'}, StringSplitOptions.None);
            foreach (var statement in statements)
            {
                if (statement != null && statement.Length == 0)
                {
                    returnValue = returnValue + "";
                    continue;
                }

                if (statement == "PRINT")
                {
                    returnValue = returnValue + Environment.NewLine;
                    continue;
                }
                var stringOperand = statement.Remove(0, 6);


                returnValue += stringOperand.Replace("\"", "") + Environment.NewLine;  
            }
          
            return returnValue;
        }
    }
}