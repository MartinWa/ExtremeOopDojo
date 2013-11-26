namespace ExtremeOopDojo.Operands
{
    public class StringOperand : BaseOperand
    {
        private readonly string _statement;

        public StringOperand(string statement)
        {
            _statement = statement;
        }

        public override string Execute(IVariableList variables)
        {
            return _statement;
        }
    }
}