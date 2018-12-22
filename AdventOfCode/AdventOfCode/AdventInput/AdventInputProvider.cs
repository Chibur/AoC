using AdventOfCode.AdventClient;
using AdventOfCode.AdventInput.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Action = AdventOfCode.AdventInput.Guards.Action;

namespace AdventOfCode.AdventInput
{
    public class AdventInputProvider : IAdventInputProvider
    {
        private readonly IAdventHttpClient _adventClient;

        public AdventInputProvider(IAdventHttpClient adventClient)
        {
            _adventClient = adventClient;
        }

        public async Task<IEnumerable<string>> GetFrequencies()
        {
            var frequencies = await _adventClient.GetInputStringListAsync("2018/day/1/input");
            return frequencies;
        }

        public async Task<IEnumerable<string>> GetBoxIds()
        {
            var boxIds = await _adventClient.GetInputStringListAsync("2018/day/2/input");
            return boxIds;
        }

        public async Task<IEnumerable<ElfsFabricClaim>> GetElfsFabricClaims()
        {
            var elfsClaimsStrings = await _adventClient.GetInputStringListAsync("2018/day/3/input");
            var elfsClaims = new List<ElfsFabricClaim>();

            foreach (var claimString in elfsClaimsStrings)
            {
                var claim = ElfsFabricClaim.Parse(claimString);
                elfsClaims.Add(claim);
            }
            return elfsClaims;
        }

        public async Task<IEnumerable<Guard>> GetGuards()
        {
            var guardActionStrings = await _adventClient.GetInputStringListAsync("2018/day/4/input");
            var guards = ParseGuards(guardActionStrings.ToList());
            return guards;
        }

        private IEnumerable<Guard> ParseGuards(List<string> guardActions)
        {

            var dateTimeExp = new Regex("\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{2}", RegexOptions.Compiled);
            var idExp = new Regex("#\\d+", RegexOptions.Compiled);
            var actionExp = new Regex("[a-z]+ [a-z]+$", RegexOptions.Compiled);

            guardActions.Sort(new ActionTimestampComparer());

            var guards = new List<Guard>();
            var currentGuardId = 0;

            foreach (var actionLog in guardActions)
            {
                if (idExp.IsMatch(actionLog))
                {
                    var guardId = int.Parse(idExp.Match(actionLog).Value.Substring(1));
                    currentGuardId = guardId;

                    if (!guards.Exists(g => g.Id == guardId))
                    {
                        var newGuard = GetInitGuardObject();
                        newGuard.Id = guardId;
                        guards.Add(newGuard);
                    }
                }

                var guard = guards.First(g => g.Id == currentGuardId);
                var timestamp = dateTimeExp.Match(actionLog);
                var action = actionExp.Match(actionLog);

                guard.Actions.Add(new Action
                {
                    Timestamp = DateTime.Parse(timestamp.Value),
                    Type = action.Value
                });
            }

            return guards;
        }

        public async Task<string> GetPolymer()
        {
            return await _adventClient.GetInputStringAsync("2018/day/4/input");
        }

        private Guard GetInitGuardObject()
        {
            return new Guard {Actions = new List<Action>()};
        }
    }
}
