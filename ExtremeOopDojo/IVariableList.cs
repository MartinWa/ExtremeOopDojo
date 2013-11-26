using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeOopDojo
{
    public interface IVariableList
    {
        void Add(string name, int value);
        int Get(string variableName);
    }
}
