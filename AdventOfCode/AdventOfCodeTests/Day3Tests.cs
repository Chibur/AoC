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
        public async Task ShouldReturnCountOfInchesOverlaping_When_TwoClaimsOverlap(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetElfsFabricClaims()).ReturnsAsync(ElfsClaimsOnFibricWithTwoOverlaping());
            var day3 = new Day3(adventInput.Object);

            // Act
            var result = await day3.CountFabricInchesOverlaping();

            // Assert
            Assert.Equal(4, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnCountOfInchesOverlaping_When_ThreeClaimsOverlap(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetElfsFabricClaims()).ReturnsAsync(ElfsClaimsOnFibricWithThreeOverlaping());
            var day3 = new Day3(adventInput.Object);

            // Act
            var result = await day3.CountFabricInchesOverlaping();

            // Assert
            Assert.Equal(6, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnNonOverlapingClaimId(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            adventInput.Setup(c => c.GetElfsFabricClaims()).ReturnsAsync(ElfsClaimsOnFibricWithThreeOverlaping());
            var day3 = new Day3(adventInput.Object);

            // Act
            var result = await day3.GetNonOverlapingClaimId();

            // Assert
            Assert.Equal(4, result);
        }

        private IEnumerable<ElfsFabricClaim> ElfsClaimsOnFibricWithTwoOverlaping()
        {
            return new List<ElfsFabricClaim>
            {
                new ElfsFabricClaim("#1 @ 1,3: 4x4"),
                new ElfsFabricClaim("#2 @ 3,1: 4x4"),
                new ElfsFabricClaim("#3 @ 5,5: 2x2")
            };
        }

        private IEnumerable<ElfsFabricClaim> ElfsClaimsOnFibricWithThreeOverlaping()
        {
            return new List<ElfsFabricClaim>
            {
                new ElfsFabricClaim("#1 @ 1,3: 4x4"),
                new ElfsFabricClaim("#2 @ 3,1: 4x4"),
                new ElfsFabricClaim("#3 @ 2,2: 2x2"),
                new ElfsFabricClaim("#4 @ 5,5: 2x2")

            };
        }
    }
}
