using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FizzBuzz.Abstractions;
using FizzBuzz.Rules.Attributes;

namespace FizzBuzz.Rules
{
    public class RuleProvider<TRules> : IRuleProvider
    {
        public RuleProvider()
        {
            if (!typeof(TRules).IsEnum)
            {
                throw new System.NotSupportedException($"Type {typeof(TRules).FullName} is not an enum");
            }
            
            Rules = GetRules();
        }

        public IEnumerable<IRule> Rules { get; }

        public IEnumerable<IRule> Match(int input) => Rules.Where(rule => rule.Match(input)).ToList();

        private IEnumerable<IRule> GetRules()
            => typeof(TRules).GetEnumValues()
                .Cast<TRules>()
                .OrderBy(fizzBuzz => fizzBuzz)
                .SelectMany(GetRulesFromAttributes);

        private IEnumerable<IRule> GetRulesFromAttributes(TRules fizzBuzz)
            => GetMultipleRulesFromAttributes(fizzBuzz)
                .Concat(GetContainsRulesFromAttributes(fizzBuzz));

        private IEnumerable<IRule> GetMultipleRulesFromAttributes(TRules fizzBuzz)
            => fizzBuzz.GetType().GetMember(fizzBuzz.ToString()).First()
                .GetCustomAttributes<MultipleOfAttribute>()
                .Select(attribute => new MultipleRule(attribute.Divisor, fizzBuzz.ToString()));

        private IEnumerable<IRule> GetContainsRulesFromAttributes(TRules fizzBuzz)
            => fizzBuzz.GetType().GetMember(fizzBuzz.ToString()).First()
                .GetCustomAttributes<ContainsAttribute>()
                .Select(attribute => new ContainsRule(attribute.Digit, fizzBuzz.ToString()));
    }
}