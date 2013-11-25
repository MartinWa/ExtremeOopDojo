﻿using System;
using System.Data;
using System.Globalization;

namespace ExtremeOopDojo.Command
{
    public class VariableCommand : BaseCommand
    {
        private readonly string _name;
        private readonly int _value;

        public VariableCommand(string name, int value)
        {
            _name = name;
            _value = value;
        }

        public static VariableCommand FromString(string name, string stringValue)
        {
            int value;
            try
            {
                value = Int32.Parse(stringValue);
            }
            catch (Exception)
            {

                throw new InvalidExpressionException(String.Format("{0} is not a valid value", stringValue));
            }
            return new VariableCommand(name, value);
        }

        public string GetName() // Violates rules Don't use any getters
        {
            return _name;
        }

        public int GetValue()  // Violates rules Don't use any getters
        {
            return _value;
        }

        public override string ToString()
        {
            return ""; // Requirements states that assignments are not echoed
        }
    }
}