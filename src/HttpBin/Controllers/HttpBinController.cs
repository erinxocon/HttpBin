using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HttpBin.Utilis;

namespace HttpBin.Controllers
{

    [Route("ip")]
    public class IpController : Controller
    {
    
        [HttpGet]
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


        [HttpGet]
        public string Get()
        {
            var headers = Request.Headers;
            var jsonHeaders = Unpack.convertToDict(headers);
            return JsonConvert.SerializeObject(jsonHeaders, Formatting.Indented);
        }
    }

    [Route("user-agent")]
    public class UserAgentController : Controller
    {

        [HttpGet]
        public string Get()
        {
            var userAgentString = Request.Headers["User-Agent"];
            var userDict = new Dictionary<string, string>() { { "userAgent", userAgentString } };
            return JsonConvert.SerializeObject(userDict, Formatting.Indented);
        }
    }

    [Route("get")]
    public class GetController : Controller
    {

        [HttpGet]
        public string Get()
        {
            var queryString = Request.Query;
            var queryDict = Unpack.convertToDict(queryString);
            return JsonConvert.SerializeObject(queryDict, Formatting.Indented);
        }
    }

    [Route("post")]
    public class PostController : Controller
    {
        [HttpPost]
        public string Get([FromBody] dynamic body)
        {
            return body.ToString();
        }
    }

    [Route("patch")]
    public class PatchController : Controller
    {
        [HttpPatch]
        public string Get([FromBody] dynamic body)
        {
            return body.ToString();
        }
    }


    [Route("put")]
    public class PutController : Controller
    {
        [HttpPut]
        public string Get([FromBody] dynamic body)
        {
            return body.ToString();
        }
    }

    [Route("delete")]
    public class DeleteController : Controller
    {
        [HttpDelete]
        public string Get([FromBody] dynamic body)
        {
            return body.ToString();
        }
    }

}
