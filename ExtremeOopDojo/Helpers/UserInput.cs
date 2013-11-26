using System;
using System.Collections.Generic;
using System.Linq;
using ExtremeOopDojo.Command;

namespace ExtremeOopDojo.Helpers
{
    public class UserInput
    {
        private readonly string _input;

        public UserInput(string input)
        {
            _input = input;
        }

        public IEnumerable<BaseCommand> Parse()
        {
            var expressions = _input.Split(new[] { ';' }, StringSplitOptions.None);
            return expressions.Select(BaseCommand.FromExpression).ToList();   // Using eager ToList() to avoid lazy evaluation giving parsing exceptions later
        }
    }
}