using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.AdventInput.Guards
{
    public class ActionTimestampComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var timeStringX = x.Split('[', ']');
            var timeStringY = y.Split('[', ']');

            var timeX = DateTime.Parse(timeStringX[1]);
            var timeY = DateTime.Parse(timeStringY[1]);

            if (timeX > timeY)
            {
                return 1;
            }
            else if (timeX == timeY)
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
    }
}
