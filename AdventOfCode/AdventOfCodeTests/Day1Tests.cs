using System.Threading.Tasks;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using AdventOfCode;
using System.Collections.Generic;

namespace AdventOfCodeTests
{
    public class Day1Tests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IAdventClient> _adventClient;

        public Day1Tests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _adventClient = _fixture.Freeze<Mock<IAdventClient>>();
        }

        [Fact]
        public async Task ShouldReturnCorrentFrequency()
        {
            // Arrange
            _adventClient.Setup(c => c.GetFrequencies()).ReturnsAsync(InputList());
            var day1 = new Day1(_adventClient.Object);

            // Act
            var result = await day1.CalculateFrequency();

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public async Task ShouldReturnFirstFrequencyDuplication()
        {
            // Arrange
            _adventClient.Setup(c => c.GetFrequencies()).ReturnsAsync(InputList());
            var day1 = new Day1(_adventClient.Object);

            // Act
            var result = await day1.GetFirstFrequencyDuplication();

            // Assert
            Assert.Equal(1, result);
        } 

        private List<string> InputList()
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
