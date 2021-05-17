using FizzBuzz.Abstractions;

namespace FizzBuzz.Rules
{
    public class ContainsRule : IRule
    {
        public ContainsRule(int digit, string label)
        {
            Digit = digit;
            Label = label;
        }

        public int Digit { get; }
        public string Label { get; }

        public bool Match(int i) => i.ToString().Contains(Digit.ToString());
    }
}