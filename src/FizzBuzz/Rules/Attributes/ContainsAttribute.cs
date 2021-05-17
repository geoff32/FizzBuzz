using System;

namespace FizzBuzz.Rules.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public class ContainsAttribute : Attribute
    {
        public ContainsAttribute(int digit)
        {
            Digit = digit;
        }
        public int Digit { get; }
    }
}