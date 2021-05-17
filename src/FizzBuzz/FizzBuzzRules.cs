using FizzBuzz.Rules.Attributes;

namespace FizzBuzz
{
    public enum FizzBuzzRules
    {
        Default,
        [MultipleOf(3), Contains(3)]
        Fizz,
        [MultipleOf(5), Contains(5)]
        Buzz,
        [MultipleOf(7), Contains(7)]
        Boom
    }
}