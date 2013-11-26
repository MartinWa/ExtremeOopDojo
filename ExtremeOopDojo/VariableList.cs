using System.Collections.Generic;

namespace ExtremeOopDojo
{
    class VariableList : IVariableList
    {
        private readonly IDictionary<string, int> _variableList;

        public VariableList()
        {
            _variableList = new Dictionary<string, int>();
        }

        public void Add(string name, int value)
        {
            _variableList.Add(name, value);
        }

        public int Get(string variableName)
        {
            int value;
            _variableList.TryGetValue(variableName, out value);
            return value;
        }
    }
}
