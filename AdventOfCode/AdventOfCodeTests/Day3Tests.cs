using AdventOfCode;
using AdventOfCode.AdventInput;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCodeTests
{
    public class Day3Tests
    {
        [Theory, AutoMoqData]
        public async Task ShouldReturnCountOfOverlapingFabricClaims_When_TwoClaimsOverlap(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetElfsFabricClaims()).ReturnsAsync(ElfsClaimsOnFibricWithTwoOverlaping());
            var day3 = new Day3(adventInput.Object);

            // Act
            var result = await day3.CountAreasOverlapingMoreThanOnce();

            // Assert
            Assert.Equal(2, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnCountOfOverlapingFabricClaims_When_ThreeClaimsOverlap(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetElfsFabricClaims()).ReturnsAsync(ElfsClaimsOnFibricWithThreeOverlaping());
            var day3 = new Day3(adventInput.Object);

            // Act
            var result = await day3.CountAreasOverlapingMoreThanOnce();

            // Assert
            Assert.Equal(3, result);
        }

        private IEnumerable<ElfsFabricClaim> ElfsClaimsOnFibricWithTwoOverlaping()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ElfsFabricClaim> ElfsClaimsOnFibricWithThreeOverlaping()
        {
            throw new NotImplementedException();
        }
    }
}
