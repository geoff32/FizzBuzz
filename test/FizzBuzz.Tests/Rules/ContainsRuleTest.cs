using FizzBuzz.Rules;
using Xunit;

namespace FizzBuzz.Tests.Rules
{
    public class MultipleRuleTest
    {
        [Theory]
        [InlineData(3, 3)]
        [InlineData(3, 6)]
        [InlineData(3, 9)]
        [InlineData(3, 12)]
        [InlineData(3, 15)]
        [InlineData(5, 5)]
        [InlineData(5, 10)]
        [InlineData(5, 15)]
        [InlineData(5, 20)]
        public void Match_Multiple_ShouldReturnTrue(int divisor, int input)
        {
            var rule = new MultipleRule(divisor, "Default");

            var match = rule.Match(input);

            Assert.True(match);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(3, 5)]
        [InlineData(3, 8)]
        [InlineData(3, 32)]
        [InlineData(5, 3)]
        [InlineData(5, 6)]
        [InlineData(5, 51)]
        [InlineData(5, 52)]
        public void Match_NotMultiple_ShouldReturnFalse(int divisor, int input)
        {
            var rule = new MultipleRule(divisor, "Default");

            var match = rule.Match(input);

            Assert.False(match);
        }
    }
}