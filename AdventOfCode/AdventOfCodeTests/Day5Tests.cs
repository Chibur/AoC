using AdventOfCode;
using AdventOfCode.AdventInput;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCodeTests
{
    public class Day5Tests
    {
        [Theory, AutoMoqData]
        public async Task ShouldDestroyAdjacentUnitsWithDifferentPolarityInPolymer(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            var polymer = "dabAcCaCBAcCcaDA";
            adventInput.Setup(c => c.GetPolymer()).ReturnsAsync(polymer);
            var day5 = new Day5(adventInput.Object);

            // Act
            var result = await day5.GetReducedPolymer();

            // Assert
            Assert.Equal("dabCBAcaDA", result);
        }
    }
}
