using System;

namespace ExtremeOopDojo
{
    public class IntegerOperand : BaseExpression
    {
        private readonly int _i;

        public IntegerOperand(int i)
        {
            _i = i;
        }

        public override string Parse()
        {
            throw new NotImplementedException();
        }
    }
}