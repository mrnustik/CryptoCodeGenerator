using System.Collections.Generic;

namespace CryptoCodeGenerator;

public interface IVariationsGenerator
{
    IEnumerable<string> GenerateVariations(char[] alphabet, int length);
}