using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CryptoCodeGenerator.Tests;

public class CodeGeneratorTests
{
    [Fact]
    public void GenerateCode_WithGivenRequirements_ReturnsValidResults()
    {
        //Arrange
        var sut = CreateSUT();
        var requirements = new CodeRequirements(2, 2, 1);
        var alphabet = new char[] {'a', 'b'};

        //Act
        var result = sut.GenerateCodeSpecifiedByRequirements(requirements, alphabet);

        //Assert
        Assert.Equal(result.Count(), result.Distinct().Count());
        Assert.True(AllResultsHasMinimumDistance(result, 1));
    }

    private bool AllResultsHasMinimumDistance(IEnumerable<string> result, int distance)
    {
        var resultList = result.ToList();
        var distanceCalculator = new HammingDistanceCalculator();
        foreach (var item in resultList)
        {
            foreach (var otherItem in resultList)
            {
                if (otherItem != item)
                {
                    if (distanceCalculator.GetDistance(item, otherItem) < distance)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private ICodeGenerator CreateSUT()
    {
        var distanceCalculator = new HammingDistanceCalculator();
        var variationsGenerator = new VariationsGenerator();
        return new CodeGenerator(variationsGenerator, distanceCalculator);
    }
}