using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Newtonsoft.Json;

namespace Test.Controllers
{
    [Route("ip")]
    public class IpController : Controller
    {
        [HttpGet(Name = "ip")]
        public string Get()
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var jsonIp = new Dictionary<string, string>() { { "origin", ipAddress.ToString() } };
            return JsonConvert.SerializeObject(jsonIp, Formatting.Indented);
        }
    }

    [Route("headers")]
    public class HeaderController : Controller
    {
        [HttpGet(Name = "headers")]
        public string Get()
        {
            var headers = Request.Headers;
            var jsonHeaders = new Dictionary<string, IHeaderDictionary>() { { "headers", headers } };
            return JsonConvert.SerializeObject(jsonHeaders, Formatting.Indented);
        }
    }

    [Route("user-agent")]
    public class UserAgentController : Controller
    {
        [HttpGet(Name = "user-agent")]
        public string Get()
        {
            var userAgentString = Request.Headers["User-Agent"];
            var userDict = new Dictionary<string, string>() { { "userAgent", userAgentString } };
            return JsonConvert.SerializeObject(userDict, Formatting.Indented);
        }
    }
}
