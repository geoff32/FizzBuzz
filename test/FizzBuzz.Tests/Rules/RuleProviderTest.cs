using System.Linq;
using FizzBuzz.Rules;
using Xunit;

namespace FizzBuzz.Tests.Rules
{
    public class RuleProviderTest
    {
        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(7, "Boom")]
        public void Rules_ShouldHaveMultipleRule(int divisor, string label)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();

            var rules = ruleProvider.Rules.OfType<MultipleRule>().Where(rule => rule.Divisor == divisor);

            var rule = Assert.Single(rules);
            Assert.Equal(label, rule.Label);
        }

        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(7, "Boom")]
        public void Rules_ShouldHaveContainsRule(int digit, string label)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();

            var rules = ruleProvider.Rules.OfType<ContainsRule>().Where(rule => rule.Digit == digit);

            var rule = Assert.Single(rules);
            Assert.Equal(label, rule.Label);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(20)]
        public void Match_SingleMultiple_ShouldReturnSingleMultipleRule(int input)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();

            var rules = ruleProvider.Match(input);

            Assert.Single(rules.OfType<MultipleRule>());
        }

        [Theory]
        [InlineData(13)]
        [InlineData(31)]
        [InlineData(52)]
        [InlineData(54)]
        public void Match_SingleContains_ShouldReturnSingleContainsRule(int input)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();

            var rules = ruleProvider.Match(input);

            Assert.Single(rules.OfType<ContainsRule>());
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void Match_MoreThanOneMultiple_ShouldReturnMoreThanOneMultipleRule(int input)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();

            var rules = ruleProvider.Match(input);

            Assert.NotNull(rules);
            Assert.True(rules.OfType<MultipleRule>().Count() > 1, "Rules must contain more than 2 multiple rule");
        }

        [Theory]
        [InlineData(53)]
        [InlineData(253)]
        [InlineData(352)]
        [InlineData(523)]
        [InlineData(532)]
        public void Match_MoreThanOneContains_ShouldReturnMoreThanOneContainsRule(int input)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();

            var rules = ruleProvider.Match(input);

            Assert.NotNull(rules);
            Assert.True(rules.OfType<ContainsRule>().Count() > 1, "Rules must contain more than 1 contains rule");
        }
    }
}