using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoCodeGenerator
{
    internal interface ICodeGenerator
    {
        IEnumerable<string> GenerateCodeSpecifiedByRequirements(CodeRequirements requirements, char[] codeAlphabet);
    }

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

    public class Program
    {
        public static void Main(string[] args)
        {
            var requirements = new CodeRequirements(4, 9, 3);
            var distanceCalculator = new HammingDistanceCalculator();
            var variationsGenerator = new VariationsGenerator();
            var codeGeneraor = new CodeGenerator(variationsGenerator, distanceCalculator);
            foreach (var generateCodeSpecifiedByRequirement in codeGeneraor.GenerateCodeSpecifiedByRequirements(requirements, new[] {'0', '1', '2'}))
            {
                Console.WriteLine(generateCodeSpecifiedByRequirement);
            }

        }
    }
}
