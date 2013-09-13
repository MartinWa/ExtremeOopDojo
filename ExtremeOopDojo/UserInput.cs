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

        public bool IsEmpty()
        {
            return _input != null && _input.Length == 0;
        }

        public bool IsPrint()
        {
            return _input == "PRINT";
        }

        public string Parse()
        {
            var returnValue = "";
            var statements = _input.Split(new[]{';'}, StringSplitOptions.None);
            foreach (var statement in statements)
            {
                if (IsEmpty())
                {
                    returnValue = returnValue + "";
                    continue;
                }

                if (IsPrint())
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