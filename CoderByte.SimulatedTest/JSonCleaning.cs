using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class JSonCleaning
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string s = await client.GetStringAsync("https://coderbyte.com/api/challenges/json/json-cleaning");
        s = CleanJson(s);
        Console.WriteLine(s);
    }

    private static string CleanJson(string json)
    {
        if (string.IsNullOrEmpty(json)) return string.Empty;

        JToken parsed = JToken.Parse(json);
        string result = CleanJson(parsed).ToString();
        return result;
    }

    private static JToken CleanJson(JToken token)
    {
        if (token is JObject)
        {
            var result = new JObject();
            foreach (var property in ((JObject)token).Properties())
            {
                JToken cleanedProp = CleanJson(property);
                if (!(cleanedProp is null))
                {
                    result.Add(cleanedProp);
                }
            }
            return result;
        }
        else if (token is JArray)
        {
            var jArray = (JArray)token;
            var result = new JArray();
            foreach (var item in jArray)
            {
                JToken cleanedItem = CleanJson(item);
                if (!(cleanedItem is null))
                {
                    result.Add(cleanedItem);
                }
            }
            return result;
        }
        else if( token is JProperty)
        {
            var prop = (JProperty)token;
            JToken cleanedValue = CleanJson(prop.Value);
            if (cleanedValue is null) return null;
            string strVal = cleanedValue.ToString();
            if (string.IsNullOrEmpty(strVal) || string.IsNullOrWhiteSpace(strVal) || strVal.ToUpper() == "N/A" || strVal == "-")
            {
                return null;
            }
            else
            {
                return new JProperty(prop.Name, cleanedValue);
            }
        }
        else
        {
            JValue val = (JValue)token;
            string strVal = val.Value<string>();
            Console.WriteLine(strVal);
            if (string.IsNullOrEmpty(strVal) || string.IsNullOrWhiteSpace(strVal) || strVal.ToUpper() == "N/A" || strVal == "-")
            {
                return null;
            }
            return token;
        }
        return token;
    }
}
