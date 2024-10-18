using System;
using System.Collections.Generic;
using System.Linq;
using Combinatorics.Collections;

namespace CryptoCodeGenerator;

internal class VariationsGenerator : IVariationsGenerator
{
    public IEnumerable<string> GenerateVariations(char[] alphabet, int length)
    {
        return new Variations<char>(alphabet, 
                                    length,
                                    GenerateOption.WithRepetition)
            .Select(t => new string(t.ToArray()));
    }
}