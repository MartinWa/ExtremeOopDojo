using System;

namespace ExtremeOopDojo
{
    public class StringOperand : BaseExpression
    {
        private readonly string _statement;

        public StringOperand(string statement)
        {
            _statement = statement;
        }

        public override string Parse()
        {
            throw new NotImplementedException();
        }
    }
}