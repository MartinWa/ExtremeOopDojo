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

            if (IsEmpty())
            {
                return "";
            }
            if (IsPrint())
            {
                return Environment.NewLine;
            }
            var stringOperand = _input.Remove(0, 6);
            

            return stringOperand.Replace("\"","")+Environment.NewLine;
        }
    }
}