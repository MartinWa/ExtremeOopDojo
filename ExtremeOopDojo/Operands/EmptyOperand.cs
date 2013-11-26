namespace ExtremeOopDojo.Operands
{
    public class EmptyOperand : BaseOperand
    {
        public override string Execute(IVariableList variables)
        {
            return "";
        }
    }
}