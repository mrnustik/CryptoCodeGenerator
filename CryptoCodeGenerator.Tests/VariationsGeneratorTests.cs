using System.Linq;
using Xunit;

namespace CryptoCodeGenerator.Tests
{
    public class VariationsGeneratorTests
    {
        [Fact]
        public void GeneratePermutations_AlphabetOfTwoCharacters_CreatesAllPermutations()
        {
            //Arrange
            var sut = CreateSUT();
            var alphabet = new[] { '0', '1' };
            //Act
            var permutations = sut.GenerateVariations(alphabet, 2)
                .ToList();

            //Assert
            Assert.Contains(permutations, t => t == "00");
            Assert.Contains(permutations, t => t == "01");
            Assert.Contains(permutations, t => t == "10");
            Assert.Contains(permutations, t => t == "11");
        }

        [Fact]
        public void GeneratePermutations_AlphabetOfTwoCharactersWithLength1_CreatesAllPermutations()
        {
            //Arrange
            var sut = CreateSUT();
            var alphabet = new[] { '0', '1' };
            //Act
            var permutations = sut.GenerateVariations(alphabet, 1)
                .ToList();

            //Assert
            Assert.Contains(permutations, t => t == "0");
            Assert.Contains(permutations, t => t == "1");
        }

        private IVariationsGenerator CreateSUT()
        {
            return new VariationsGenerator();
        }
    }
}