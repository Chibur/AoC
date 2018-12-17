using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode;
using AdventOfCode.AdventInput;
using AdventOfCode.AdventInput.Guards;
using Moq;
using Xunit;

namespace AdventOfCodeTests
{
    public class Day4Tests
    {
        [Theory, AutoMoqData]
        public async Task ShouldReturnCorrectIdAndMinuteMultiplicationResult(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(a => a.GetGuards()).ReturnsAsync(GetGuards());
            var day4 = new Day4(adventInput.Object);

            // Act
            var result = await day4.FindGuardIdAndMinute();

            // Assert
            Assert.Equal(240, result);
        }

        private IEnumerable<Guard> GetGuards()
        {
            return new List<Guard>();
        }
    }
}
