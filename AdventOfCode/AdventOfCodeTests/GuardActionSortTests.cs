using AdventOfCode.AdventInput.Guards;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCodeTests
{
    public class GuardActionSortTests
    {
        [Fact]
        public void ShouldSortGuardActionListByDateTimeAscending()
        {
            // Arrange
            var guardActions = GetGuardActions();

            //Act
            guardActions.Sort(new ActionTimestampComparer());

            // Assert
            Assert.Equal("[1518-03-04 00:52] wakes up", guardActions[0]);
            Assert.Equal("[1518-11-07 00:52] wakes up", guardActions[14]);

        }

        private List<string> GetGuardActions()
        {
            return new List<string>
                {
                    "[1518-03-25 00:01] Guard #743 begins shift",
                    "[1518-09-15 00:34] falls asleep",
                    "[1518-10-11 00:27] wakes up",
                    "[1518-04-30 00:56] falls asleep",
                    "[1518-05-27 00:33] falls asleep",
                    "[1518-11-07 00:52] wakes up",
                    "[1518-09-04 00:47] wakes up",
                    "[1518-05-29 00:44] wakes up",
                    "[1518-06-10 00:41] falls asleep",
                    "[1518-09-03 00:21] wakes up",
                    "[1518-06-16 00:59] wakes up",
                    "[1518-03-04 00:52] wakes up",
                    "[1518-07-13 00:58] wakes up",
                    "[1518-07-31 00:05] falls asleep",
                    "[1518-10-15 00:55] falls asleep"
                };
        }
    }
}
