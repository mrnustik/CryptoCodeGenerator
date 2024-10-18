using System.Collections.Generic;
using System.Linq;

namespace CryptoCodeGenerator;

internal class CodeGenerator : ICodeGenerator
{
    private readonly IVariationsGenerator variationsGenerator;
    private readonly IStringDistanceCalculator distanceCalculator;

    public CodeGenerator(IVariationsGenerator variationsGenerator, IStringDistanceCalculator distanceCalculator)
    {
        this.variationsGenerator = variationsGenerator;
        this.distanceCalculator = distanceCalculator;
    }

    public IEnumerable<string> GenerateCodeSpecifiedByRequirements(CodeRequirements requirements,
                                                                   char[] codeAlphabet)
    {
        var variations = variationsGenerator.GenerateVariations(codeAlphabet, requirements.CodewordsLength);
        var filteredResults = FilterResultsByDistance(variations, requirements.MinimalHammingDistance)
            .Distinct();
        return filteredResults.Take(requirements.NumberOfCodewords);
    }

    private IEnumerable<string> FilterResultsByDistance(IEnumerable<string> variations, int minimalHammingDistance)
    {
        var enabledVariationsList = variations.ToList();
        var finalVariationsList = new List<string>();
        while (enabledVariationsList.Any())
        {
            var currentVariation = enabledVariationsList.First();
            enabledVariationsList.RemoveAll(t =>
                                                distanceCalculator.GetDistance(currentVariation, t) < minimalHammingDistance);
            finalVariationsList.Add(currentVariation);
        }

        return finalVariationsList;
    }
}