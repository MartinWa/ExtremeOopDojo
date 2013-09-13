

namespace ExtremeOopDojo
{
    public class CommodoreC64
    {
        public string Interpret(BaseExpression[] expressions)
        {
            var returnString = "";
            foreach (var baseExpression in expressions)
            {
                returnString += baseExpression.Parse();
            }
            return returnString;
        }
    }
}