using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSharp9
{
    public class PatternMatchingTests
    {
        public static string GetLetterGrade(double percentage)
            => percentage switch
            {
                < 0.5 and >= 0.0 => "F",
                < 0.65 => "D",
                < 0.75 => "C",
                < 0.85 => "B",
                < 0.95 => "A",
                >= 0.95 and < 1.0 => "A+ Super Star!",
                double.PositiveInfinity or (double.NegativeInfinity and not double.NaN) => "You don't exist",
                object /*_*/ => throw new ArgumentException(null, nameof(percentage))
            };

        [Fact]
        public void NegatedPatterns()
        {
            Action<string, string> discardParameter = (_, _) => { };

            string defaultValue = "Default";
            Enumerable.Range(0, 10)
                .Select(x => x.ToString() ?? defaultValue)
                .Where(static x => x is not null);
        }
    }
}
