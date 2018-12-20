using System;
using System.Collections.Generic;
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
        public async Task ShouldReturnCorrectIdAndMinuteMultiplicationResult_When_SneakOnLongestSleepingGuardStrategyUsed(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            var guards = GetGuards();
            adventInput.Setup(a => a.GetGuards()).ReturnsAsync(GetGuards());
            var day4 = new Day4(adventInput.Object);

            // Act
            var result = await day4.FindLongestSleepingGuardAndMinuteToSneak();

            // Assert
            Assert.Equal(240, result);
        }

        [Theory, AutoMoqData]
        public async Task ShouldReturnCorrectIdAndMinuteMultiplicationResult_When_SneekOnMostFrequentlySleepingGuardStrategyUsed(Mock<IAdventInputProvider> adventInput)
        {
            // Arrange
            var guards = GetGuards();
            adventInput.Setup(a => a.GetGuards()).ReturnsAsync(GetGuards());
            var day4 = new Day4(adventInput.Object);

            // Act
            var result = await day4.FindGuardMostFrequentlyAsleepAndMinuteToSneak();

            // Assert
            Assert.Equal(4455, result);
        }

        private IEnumerable<Guard> GetGuards()
        {

            return new List<Guard>
            {
                new Guard
                {
                    Id = 10,
                    Actions = new List<AdventOfCode.AdventInput.Guards.Action>
                    {
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-01 00:00"),
                            Type = ActionType.BeginsShift
                        },
                          new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-01 00:05"),
                            Type = ActionType.FallsAsleep
                        },
                          new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-01 00:25"),
                            Type = ActionType.WakesUp
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-01 00:30"),
                            Type = ActionType.FallsAsleep
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-01 00:55"),
                            Type = ActionType.WakesUp
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-03 00:05"),
                            Type = ActionType.BeginsShift
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-03 00:24"),
                            Type = ActionType.FallsAsleep
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-03 00:29"),
                            Type = ActionType.WakesUp
                        }
                    }
                },
                new Guard
                {
                    Id = 99,
                    Actions = new List<AdventOfCode.AdventInput.Guards.Action>
                    {
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-01 23:58"),
                            Type = ActionType.BeginsShift
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-02 00:40"),
                            Type = ActionType.FallsAsleep
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-02 00:50"),
                            Type = ActionType.WakesUp
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-04 00:02"),
                            Type = ActionType.BeginsShift
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-04 00:36"),
                            Type = ActionType.FallsAsleep
                        },
                         new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-04 00:46"),
                            Type = ActionType.WakesUp
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-05 00:03"),
                            Type = ActionType.BeginsShift
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-05 00:45"),
                            Type = ActionType.FallsAsleep
                        },
                        new AdventOfCode.AdventInput.Guards.Action
                        {
                            Timestamp = DateTime.Parse("1518-11-05 00:55"),
                            Type = ActionType.WakesUp
                        }
                    }
                }
            };
        }
    }
}
