using AdventOfCode.AdventClient;
using AdventOfCode.AdventInput;
using AdventOfCode.AdventInput.Guards;
using Moq;
using System;
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

        [Theory, AutoMoqData]
        public async Task ShouldParseGuardActionsAndGroupByGuardId(Mock<IAdventHttpClient> adventClient)
        {
            // Arrange
            adventClient.Setup(c => c.GetInputStringListAsync(It.IsAny<string>())).ReturnsAsync(GetGuardActions());

            var adventInput = new AdventInputProvider(adventClient.Object);

            // Act
            var guards = (await adventInput.GetGuards()).ToList();
            var guardActions = guards.First(g => g.Id == 1).Actions;

            // Asset
            Assert.Equal(3, guards.Count());

            Assert.Equal(ActionType.BeginsShift, guardActions[0].Type);
            Assert.Equal(DateTime.Parse("1518-01-01 00:01"), guardActions[0].Timestamp);

            Assert.Equal(ActionType.FallsAsleep, guardActions[1].Type);
            Assert.Equal(ActionType.WakesUp, guardActions[2].Type);

            Assert.Equal(ActionType.BeginsShift, guardActions[3].Type);
            Assert.Equal(DateTime.Parse("1518-07-01 00:01"), guardActions[3].Timestamp);
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

        private IEnumerable<string> GetGuardActions()
        {
            return new List<string>
                {
                    "[1518-01-31 00:42] wakes up",
                    "[1518-01-01 00:34] falls asleep",
                    "[1518-01-30 23:48] Guard #2 begins shift",
                    "[1518-01-31 00:57] wakes up",
                    "[1518-06-10 00:41] Guard #3 begins shift",
                    "[1518-07-01 00:01] Guard #1 begins shift",
                    "[1518-01-31 00:33] falls asleep",
                    "[1518-01-01 00:01] Guard #1 begins shift",
                    "[1518-01-31 00:47] falls asleep",
                    "[1518-01-01 00:54] wakes up"
                };
        }
    }
}
