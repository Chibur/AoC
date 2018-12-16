using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AdventInput
{
    public class ElfsFabricClaim
    {
        public int Id { get; set; }

        public int OffsetTop { get; set; }

        public int OffsetLeft { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }

        public ElfsFabricClaim()
        {

        }

        public ElfsFabricClaim(string claim)
        {
            ParseElfFabricClaim(claim);
        }

        private void ParseElfFabricClaim(string elfClaimString)
        {
            var splitString = elfClaimString.Split(' ');

            var id = splitString[0].Remove(0, 1);
            var offsets = splitString[2].Split(',', ':');
            var measurements = splitString[3].Split('x');

            Id = int.Parse(id);
            OffsetLeft = int.Parse(offsets[0]);
            OffsetTop = int.Parse(offsets[1]);
            Width = int.Parse(measurements[0]);
            Height = int.Parse(measurements[1]);
        }

    }
}
