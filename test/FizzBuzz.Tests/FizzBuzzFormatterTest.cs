using System.Collections.Generic;
using System.Linq;
using FizzBuzz.Abstractions;
using NSubstitute;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzFormatterTest
    {
        [Fact]
        public void Compute_MatchSingleRule_ShouldReturnRuleLabel()
        {
            var i = 11;
            var expected = "Fizz";
            var ruleProvider = Substitute.For<IRuleProvider>();
            var fizzRule = Substitute.For<IRule>();
            fizzRule.Label.Returns(expected);
            ruleProvider.Match(i).Returns(new[] { fizzRule });

            var formatter = new FizzBuzzFormatter(ruleProvider);

            var output = formatter.Compute(i);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Compute_MatchMultipleRuleWithSameLabel_ShouldReturnSingleRuleLabel()
        {
            var i = 11;
            var expected = "Fizz";
            var ruleProvider = Substitute.For<IRuleProvider>();
            var fizzRules = new List<IRule> { Substitute.For<IRule>(), Substitute.For<IRule>() };
            fizzRules.ForEach(rule => rule.Label.Returns(expected));

            ruleProvider.Match(i).Returns(fizzRules);

            var formatter = new FizzBuzzFormatter(ruleProvider);

            var output = formatter.Compute(i);

            Assert.Equal(expected, output);
        }

        [Fact]
        public void Compute_MatchMultipleRuleWithDifferentLabel_ShouldReturnAggregateRuleLabel()
        {
            var i = 11;
            var expected1 = "Fizz";
            var expected2 = "Buzz";
            var expected = expected1 + expected2;

            var ruleProvider = Substitute.For<IRuleProvider>();

            var fizzRule1 = Substitute.For<IRule>();
            fizzRule1.Label.Returns(expected1);
            var fizzRule2 = Substitute.For<IRule>();
            fizzRule2.Label.Returns(expected2);

            ruleProvider.Match(i).Returns(new[] { fizzRule1, fizzRule2 });

            var formatter = new FizzBuzzFormatter(ruleProvider);

            var output = formatter.Compute(i);

            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void Compute_NoMatchRule_ShouldReturnInput(int input)
        {
            var ruleProvider = Substitute.For<IRuleProvider>();
            ruleProvider.Match(input).Returns(Enumerable.Empty<IRule>());

            var formatter = new FizzBuzzFormatter(ruleProvider);

            var output = formatter.Compute(input);

            Assert.Equal(input.ToString(), output);
        }
    }
}