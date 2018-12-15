using AdventOfCode;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using AdventOfCode.AdventInput;

namespace AdventOfCodeTests
{
    public class Day2Tests
    {
        [Theory, AutoMoqData]
        public async Task ShouldReturnCorrentCheckSum(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetBoxIds()).ReturnsAsync(PartOneList());
            var day2 = new Day2(adventInput.Object);

            // Act
            var result = await day2.CalculateChecksum();

            // Assert
            Assert.Equal(12, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnCommonLettersOfMostSimilarIds(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetBoxIds()).ReturnsAsync(PartTwoList());
            var day2 = new Day2(adventInput.Object);

            // Act
            var result = await day2.GetStringOfCommonLettersFromMostSimilarBoxIds();

            // Assert
            Assert.Equal("fgij", result);
        }

        private IEnumerable<string> PartOneList()
        {
            return new List<string>
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };
        }

        private IEnumerable<string> PartTwoList()
        {
            return new List<string>
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };
        }
    }
}
