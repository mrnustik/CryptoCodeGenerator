using System.Collections.Generic;

namespace CryptoCodeGenerator;

internal interface ICodeGenerator
{
    IEnumerable<string> GenerateCodeSpecifiedByRequirements(CodeRequirements requirements, char[] codeAlphabet);
}