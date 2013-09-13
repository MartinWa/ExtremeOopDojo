using System;

namespace ExtremeOopDojo
{
    public class CommodoreC64
    {
        public string Interpret(UserInput input)
        {
            if (input.IsEmpty())
            {
                return "";
            }
            if (input.IsPrint())
            {
                return Environment.NewLine;
            }
            return null;
        }
    }
}