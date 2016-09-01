using Microsoft.AspNetCore.Http;

namespace HttpBin.Utils
{
    public class IpHelper
    {

        static public string getIp(HttpRequest request)
        {
            string ipAddress;

            if (request.Headers.Keys.Contains("X-Forwarded-For"))
            {
                ipAddress = request.Headers["X-Forwarded-For"];
            }

            else
            {
                ipAddress = request.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            return ipAddress;
        }
    }
}
