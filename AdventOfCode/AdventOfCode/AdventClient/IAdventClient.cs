using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public interface IAdventClient
    {
        Task<List<string>> GetInputListForADayAsync(string uri);
        Task<string> GetInputForADayAsync(string uri);
    }
}
