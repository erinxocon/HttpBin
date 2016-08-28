using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using HttpBin.Utils;
using HttpBin.Models;

namespace HttpBin.Controllers
{

    [Route("ip")]
    public class IpController : Controller
    {
    
        [HttpGet]
        public string Get()
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var jsonIp = new Dictionary<string, string>() { { "origin", ipAddress } };
            return JsonConvert.SerializeObject(jsonIp, Formatting.Indented);
        }
    }

    [Route("headers")]
    public class HeaderController : Controller
    {


        [HttpGet]
        public string Get()
        {
            var jsonHeaders = Unpack.convertToDict(Request.Headers);
            var resp = new Dictionary<string, Dictionary<string, string>>() { { "headers", jsonHeaders } };
            return JsonConvert.SerializeObject(resp, Formatting.Indented);
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

            var respObj = new ResponseObject()
            {
                origin = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                args = Unpack.convertToDict(Request.Query),
                headers = Unpack.convertToDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request)

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }
    }

    [Route("post")]
    public class PostController : Controller
    {
        [HttpPost]
        public string Get([FromBody] dynamic body)
        {

            var respObj = new ResponseObject()
            {
                origin = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                args = Unpack.convertToDict(Request.Query),
                headers = Unpack.convertToDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request),
                json = body

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }
    }

    [Route("patch")]
    public class PatchController : Controller
    {
        [HttpPatch]
        public string Get([FromBody] dynamic body)
        {
            var respObj = new ResponseObject()
            {
                origin = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                args = Unpack.convertToDict(Request.Query),
                headers = Unpack.convertToDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request),
                json = body

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }
    }


    [Route("put")]
    public class PutController : Controller
    {
        [HttpPut]
        public string Get([FromBody] dynamic body)
        {
            var respObj = new ResponseObject()
            {
                origin = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                args = Unpack.convertToDict(Request.Query),
                headers = Unpack.convertToDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request),
                json = body

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }
    }

    [Route("delete")]
    public class DeleteController : Controller
    {
        [HttpDelete]
        public string Get([FromBody] dynamic body)
        {
            var respObj = new ResponseObject()
            {
                origin = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                args = Unpack.convertToDict(Request.Query),
                headers = Unpack.convertToDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request),
                json = body

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }
    }

}
