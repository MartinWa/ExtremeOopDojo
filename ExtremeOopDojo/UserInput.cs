namespace ExtremeOopDojo
{
    public class UserInput
    {
        private readonly string _empty;

        public UserInput(string empty)
        {
            _empty = empty;
        }

        public bool IsEmpty()
        {
            return _empty != null && _empty.Length == 0;
        }
    }
}