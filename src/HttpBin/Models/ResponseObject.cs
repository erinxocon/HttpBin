using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace HttpBin.Models
{
    public class ResponseObject
    {
        public Dictionary<string, string> args { get; set; }
        public Dictionary<string, string> headers { get; set; }
        public string origin { get; set; }
        public string url { get; set; }
        public JObject json { get; set; }
    }
}
