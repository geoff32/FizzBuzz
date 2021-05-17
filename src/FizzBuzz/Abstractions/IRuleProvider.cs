using System.Collections.Generic;

namespace FizzBuzz.Abstractions
{
    public interface IRuleProvider
    {
        IEnumerable<IRule> Rules { get; }
        IEnumerable<IRule> Match(int input);
    }
}