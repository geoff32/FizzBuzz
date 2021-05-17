using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Abstractions;

namespace FizzBuzz
{
    public class FizzBuzzFormatter : IFormatter
    {
        private readonly IRuleProvider _ruleProvider;

        public FizzBuzzFormatter(IRuleProvider ruleProvider) => _ruleProvider = ruleProvider;

        public string Compute(int i)
        {
            var matches = _ruleProvider.Match(i);

            return matches.Any() ? string.Join("", matches.Select(match => match.Label).Distinct()) : i.ToString();
        }
    }
}