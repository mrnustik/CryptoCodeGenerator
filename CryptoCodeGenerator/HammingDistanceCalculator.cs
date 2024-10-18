using System;
using System.Linq;

namespace CryptoCodeGenerator;

internal class HammingDistanceCalculator : IStringDistanceCalculator
{
    public int GetDistance(string x, string y)
    {
        if (x.Length != y.Length)
        {
            throw new ArgumentException($"Strings has to have the same length");
        }

        return x.ToCharArray()
                .Zip(y.ToCharArray(), (charFromX, charFromY) => (charFromX, charFromY))
                .Count(t => t.Item1 != t.Item2);
    }
}