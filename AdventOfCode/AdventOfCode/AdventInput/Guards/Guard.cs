using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AdventInput.Guards
{
    public class Guard
    {
        public List<Action> Actions { get; set; }

        public int Id { get; set; }

        public Guard(List<string> rawActions)
        {

        }

        private (List<Action>, int) Parse(List<string> rawActions)
        {
            throw new NotImplementedException();
        }
    }
}
