using System;
using FizzBuzz.Rules;

namespace FizzBuzz
{
    static class Program
    {
        static void Main(string[] args)
        {
            var ruleProvider = new RuleProvider<FizzBuzzRules>();
            var fizzBuzz = new FizzBuzzFormatter(ruleProvider);

            for (var i = 1; i < 100; i++)
            {
                Console.WriteLine(fizzBuzz.Compute(i));
            }
        }
    }
}
