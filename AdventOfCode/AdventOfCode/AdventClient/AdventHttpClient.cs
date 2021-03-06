using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace AdventOfCode.AdventClient
{
    public class AdventHttpClient: IAdventHttpClient
    {
        private Uri _baseUrl => new Uri("https://adventofcode.com");

        public async Task<string> GetInputStringAsync(string uri)
        {
            string result;

            //var proxy = new WebProxy()
            //{
            //    Address = new Uri("sadfasdafsdfasdf"),
            //    UseDefaultCredentials = true,
            //};

            //var httpClientHandler = new HttpClientHandler()
            //{
            //    Proxy = proxy
            //};

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Add("cookie", "_ga=GA1.2.2010882644.1544457104; _gid=GA1.2.785056167.1544457104; session=53616c7465645f5fe57a5508b8cecfe077d33dab2b326652a244344e6509766a0eceb5a21e915feccb9bbb04ae295b9c");
                // httpClient.DefaultRequestHeaders.Add("cookie", "session=53616c7465645f5f05d95f081151e906dfa07ae2b6866380524a3366b375866b1501e44f481b7dfb62494872eb129793; _gid=GA1.2.772893616.1545499557; _ga=GA1.2.682683098.1544440427");
                // httpClient.DefaultRequestHeaders.Add("Cookie", "_ga=GA1.2.77188142.1544512270; _gid=GA1.2.411141830.1545028007; session=53616c7465645f5f12dd5ce5cb9a1a159689616b9b1c09ff877432f27b883e9095b48ca2b1bba3a7fa2e28db480fc69c");

                result = await httpClient.GetStringAsync(uri);
            }
            return result.Trim();
        }

        public async Task<IEnumerable<string>> GetInputStringListAsync(string uri)
        {
            var rawInput = await GetInputStringAsync(uri);
            var splitInput = rawInput.Split('\n');
            return splitInput;
        }
    }
}
