using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
