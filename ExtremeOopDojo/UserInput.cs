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
    }
}