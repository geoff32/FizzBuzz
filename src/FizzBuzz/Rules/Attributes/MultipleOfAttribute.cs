using System;

namespace FizzBuzz.Rules.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public class MultipleOfAttribute : Attribute
    {
        public MultipleOfAttribute(int divisor)
        {
            Divisor = divisor;
        }
        public int Divisor { get; }
    }
}