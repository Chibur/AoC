using System.Threading.Tasks;
using Xunit;
using Moq;
using AdventOfCode;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    public class Day1Tests
    {
        [Theory, AutoMoqData]
        public async Task ShouldReturnCorrentFrequency(Mock<IAdventClient> adventClient)
        {
            // Arrange
            adventClient.Setup(c => c.GetFrequencies()).ReturnsAsync(InputList());
            var day1 = new Day1(adventClient.Object);

            // Act
            var result = await day1.CalculateFrequency();

            // Assert
            Assert.Equal(8, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnFirstFrequencyDuplication(Mock<IAdventClient> adventClient)
        {
            // Arrange
            adventClient.Setup(c => c.GetFrequencies()).ReturnsAsync(InputList());
            var day1 = new Day1(adventClient.Object);

            // Act
            var result = await day1.GetFirstFrequencyDuplication();

            // Assert
            Assert.Equal(1, result);
        } 

        private IEnumerable<string> InputList()
        {
            return new List<string>
            {
                "+2",
                "-1",
                "+3",
                "+1",
                "-4",
                "4",
                "-2",
                "2",
                "3",
            };
        }
    }
}
