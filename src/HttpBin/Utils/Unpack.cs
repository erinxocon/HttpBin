using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace HttpBin.Utils
{
    static public class Unpack
    {
        static public Dictionary<string, string> flattenDict(IEnumerable<KeyValuePair<string, StringValues>> queryString)
        {
            var newDict = new Dictionary<string, string>();
            foreach (var entry in queryString)
            {
                newDict.Add(entry.Key, entry.Value);
            }
            return newDict;
        }

        static public Dictionary<string, string> flattenDict(IHeaderDictionary headerDict, bool showEnv = false)
        {
            var newDict = new Dictionary<string, string>();
            foreach (var entry in headerDict)
            {
                if (entry.Key.StartsWith("X") && showEnv == false)
                {
                    break;
                }

                else
                {
                    newDict.Add(entry.Key, entry.Value);
                }

            }
            return newDict;
        }

        static public Dictionary<string, string> flattenDict(IEnumerable<KeyValuePair<string, string>> cookies)
        {
            var newDict = new Dictionary<string, string>();
            foreach (var entry in cookies)
            {
                newDict.Add(entry.Key, entry.Value);
            }
            return newDict;
        }
    }
}
