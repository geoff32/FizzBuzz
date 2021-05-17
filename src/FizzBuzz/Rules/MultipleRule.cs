using FizzBuzz.Abstractions;

namespace FizzBuzz.Rules
{
    public class MultipleRule : IRule
    {
        public MultipleRule(int divisor, string label)
        {
            Divisor = divisor;
            Label = label;
        }

        internal int Divisor { get; }
        public string Label { get; }

        public bool Match(int i) => i % Divisor == 0;
    }
}