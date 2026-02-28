using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class LogsParse
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string logs = await client.GetStringAsync("https://coderbyte.com/api/challenges/logs/web-logs-raw");

        var counts = new Dictionary<string, int>();

        foreach (Match match in Regex.Matches(logs, @"\?shareLinkId=(\S+)"))
        {
            string id = match.Groups[1].Value;
            if (counts.ContainsKey(id))
                counts[id]++;
            else
                counts[id] = 1;
        }

        foreach (string k in counts.Keys)
        {
            if (counts[k] == 1)
                Console.WriteLine(k);
            else
                Console.WriteLine(k + ":" + counts[k]);
        }
    }
}
