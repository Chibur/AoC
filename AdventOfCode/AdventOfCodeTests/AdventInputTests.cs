using AdventOfCode.AdventClient;
using AdventOfCode.AdventInput;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCodeTests
{
    public class AdventInputTests
    {
        [Theory, AutoMoqData]
        public async Task ShouldParseElfFabricClaimStringToObject(Mock<IAdventHttpClient> adventClient)
        {
            // Arrange
            adventClient.Setup(c => c.GetInputStringListAsync(It.IsAny<string>())).ReturnsAsync(ElfsClaimStringList());

            var adventInput = new AdventInputProvider(adventClient.Object);

            // Act
            var elfsClaims = await adventInput.GetElfsFabricClaims();
            var elfClaim = elfsClaims.First();

            // Asset
            Assert.Equal(3, elfsClaims.Count());

            Assert.Equal(1, elfClaim.Id);
            Assert.Equal(2, elfClaim.OffsetLeft);
            Assert.Equal(7, elfClaim.OffsetTop);
            Assert.Equal(8, elfClaim.Width);
            Assert.Equal(3, elfClaim.Height);
        }

        private IEnumerable<string> ElfsClaimStringList()
        {
            return new List<string>
            {
                "#1 @ 2,7: 8x3",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
        }
    }
}
