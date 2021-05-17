using FizzBuzz.Rules;
using Xunit;

namespace FizzBuzz.Tests.Rules
{
    public class ContainsRuleTest
    {
        [Theory]
        [InlineData(3, 3)]
        [InlineData(3, 13)]
        [InlineData(3, 23)]
        [InlineData(3, 30)]
        [InlineData(3, 33)]
        [InlineData(5, 5)]
        [InlineData(5, 15)]
        [InlineData(5, 25)]
        [InlineData(5, 50)]
        [InlineData(5, 51)]
        public void Match_Contains_ShouldReturnTrue(int digit, int input)
        {
            var rule = new ContainsRule(digit, "Default");

            var match = rule.Match(input);

            Assert.True(match);
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(3, 5)]
        [InlineData(3, 6)]
        [InlineData(3, 8)]
        [InlineData(5, 3)]
        [InlineData(5, 10)]
        [InlineData(5, 14)]
        [InlineData(5, 20)]
        public void Match_NotMultiple_ShouldReturnFalse(int digit, int input)
        {
            var rule = new ContainsRule(digit, "Default");

            var match = rule.Match(input);

            Assert.False(match);
        }
    }
}