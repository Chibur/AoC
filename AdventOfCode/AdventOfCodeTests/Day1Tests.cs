using System.Threading.Tasks;
using Xunit;
using Moq;
using AdventOfCode;
using System.Collections.Generic;
using AdventOfCode.AdventInput;

namespace AdventOfCodeTests
{
    public class Day1Tests
    {
        [Theory, AutoMoqData]
        public async Task ShouldReturnCorrentFrequency(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetFrequencies()).ReturnsAsync(InputList());
            var day1 = new Day1(adventInput.Object);

            // Act
            var result = await day1.CalculateFrequency();

            // Assert
            Assert.Equal(8, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnFirstFrequencyDuplication(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetFrequencies()).ReturnsAsync(InputList());
            var day1 = new Day1(adventInput.Object);

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
