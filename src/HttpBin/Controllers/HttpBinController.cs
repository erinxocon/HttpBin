﻿using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using HttpBin.Utils;
using HttpBin.Models;
using System;

namespace HttpBin.Controllers
{

    [Route("ip")]
    public class IpController : Controller
    {

        [HttpGet]
        public string Get()
        {
            var ipAddress = IpHelper.getIp(Request);
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
            var jsonHeaders = Unpack.flattenDict(Request.Headers);
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

            bool showEnv = Request.Query["show_env"] == "1" ? true : false;

            var respObj = new ResponseObject()
            {
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers, showEnv),
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
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers),
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
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers),
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
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers),
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
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request),
                json = body

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }
    }

    [Route("status/{statusCode:int}")]
    public class StatusController : Controller
    {
        [HttpGet]
        public StatusCodeResult Get(int statusCode)
        {
            return StatusCode(statusCode);
        }
    }

    [Route("response-headers")]
    public class ResponseHeadersController : Controller
    {
        [HttpGet]
        public string Get()
        {

            foreach (var entry in Request.Query)
            {
                Response.Headers.Add(entry.Key, entry.Value);
            }

            return JsonConvert.SerializeObject(Response.Headers, Formatting.Indented);
        }
    }

    [Route("redirect/{num:int}")]
    public class RedirectController : Controller
    {
        [HttpGet]
        public void Get(int num)
        {
            num = Math.Min(num, 60);

            string redirectUrl = "http://" + Request.Host.ToString();

            if (num > 1)
            {
                num--;
                redirectUrl = "/redirect/" + num.ToString();
                Response.Redirect(redirectUrl);
            }

            else
            {
                redirectUrl += "/get";
                Response.Redirect(redirectUrl);
            }

        }
    }

    [Route("redirect-to")]
    public class RedirectToController : Controller
    {
        [HttpGet]
        public void Get()
        {
            var redirectUrl = Request.Query["url"];

            Response.Redirect(redirectUrl);
        }
    }

    [Route("delay/{num:int}")]
    public class DelayController : Controller
    {
        [HttpGet]
        public void Get(int num)
        {
            var redirectUrl = "http://" + Request.Host.ToString() + "/get";

            var milisecs = num * 1000;

            Thread.Sleep(milisecs);

            Response.Redirect(redirectUrl);
        }
    }

    [Route("forms")]
    public class FormsController : Controller
    {
        [HttpPost]
        public string Get()
        {

            var respObj = new ResponseObject()
            {
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request),
                forms = Unpack.flattenDict(Request.Form)

            };

            return JsonConvert.SerializeObject(respObj, Formatting.Indented);
        }

    }

    [Route("cookies")]
    public class CookieController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var cookies = Unpack.flattenDict(Request.Cookies);

            var cookieDict = new Dictionary<string, Dictionary<string, string>>() { { "cookies", cookies } };

            return JsonConvert.SerializeObject(cookieDict, Formatting.Indented);
        }

    }

    [Route("cookies/set")]
    public class CookieSetController : Controller
    {
        [HttpGet]
        public void Get()
        {
            var args = Unpack.flattenDict(Request.Query);

            foreach (var entry in args)
            {

                Response.Cookies.Append(entry.Key, entry.Value, new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Path = "/cookies",
                    HttpOnly = false,
                    Secure = false,
                    Expires = DateTime.Now.AddDays(1d)
                });
            }

            Response.Redirect("/cookies");
        }

    }

    [Route("cookies/delete")]
    public class CookieDeleteController : Controller
    {
        [HttpGet]
        public void Get()
        {
            var args = Unpack.flattenDict(Request.Query);

            foreach (var entry in args)
            {
                Response.Cookies.Append(entry.Key, entry.Value, new Microsoft.AspNetCore.Http.CookieOptions()
                {
                    Path = "/cookies",
                    Expires = DateTime.Now.AddDays(-1d)
                });
            }

            Response.Redirect("/cookies");
        }

    }

    [Route("stream/{num:int}")]
    public class StreamController : Controller
    {
        [HttpGet]
        public string Get(int num)
        {

            num = Math.Min(num, 100);

            var respObj = new ResponseObject()
            {
                origin = IpHelper.getIp(Request),
                args = Unpack.flattenDict(Request.Query),
                headers = Unpack.flattenDict(Request.Headers),
                url = UriHelper.GetDisplayUrl(Request)

            };

            List<ResponseObject> list = new List<ResponseObject>();

            for (int i = 0; i <= num; i++)
            {
                list.Add(respObj);
            };

            return JsonConvert.SerializeObject(list);
        }
    }

}
