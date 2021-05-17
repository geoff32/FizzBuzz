namespace FizzBuzz.Abstractions
{
    public interface IRule
    {
        string Label { get; }
        bool Match(int i);
    }
}