using System;
using Xunit;

namespace CryptoCodeGenerator.Tests
{
    public class HammingDistanceCalculatorTests
    {
        [Fact]
        public void CalculateDistance_WithSameStrings_ReturnsZero()
        {
            //Arrange
            var sut = CreateSUT();
            string x = "012", y = "012";

            //Act
            var result = sut.GetDistance(x, y);

            //Assert
            Assert.Equal(0,result);
        }

        [Fact]
        public void CalculateDistance_WithStringsWithOneDifferentCharacter_ReturnsOne()
        {
            //Arrange
            var sut = CreateSUT();
            string x = "012", y = "010";

            //Act
            var result = sut.GetDistance(x, y);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void CalculateDistance_WithStringsWithAllDifferentCharacters_ReturnsStringsLength()
        {
            //Arrange
            var sut = CreateSUT();
            string x = "000", y = "121";

            //Act
            var result = sut.GetDistance(x, y);

            //Assert
            Assert.Equal(x.Length, result);
        }

        private IStringDistanceCalculator CreateSUT()
        {
            return new HammingDistanceCalculator();
        }
    }
}
