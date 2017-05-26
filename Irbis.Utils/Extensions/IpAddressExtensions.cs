using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Irbis.Utils.Extensions
{
    public static class IpAddressExtensions
    {
        private static readonly Regex IpRegex = new Regex("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", RegexOptions.Compiled);
        public static bool IsIpAddress(this string ip)
        {
            return !string.IsNullOrEmpty(ip) && IpRegex.IsMatch(ip);
        }

        public static Int64 ToInt64(this IPAddress address)
        {
            if (address == null)
            {
                return 0;
            }

            try
            {
                var bytes = address.GetAddressBytes();

                if (bytes.Length != 4)
                {
                    return 0;
                }

                Int64 result = Convert.ToInt64(bytes[3])
                               + Convert.ToInt64(256) * bytes[2]
                               + Convert.ToInt64(256) * 256 * bytes[1]
                               + Convert.ToInt64(256) * 256 * 256 * bytes[0];

                return result;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary> Получить IP адрес </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static String GetIpAddress(this HttpRequestBase request)
        {
            var key = request.Headers.AllKeys.FirstOrDefault(x => x.ToLower().Trim() == "x-forwarded-for");

            if (!String.IsNullOrEmpty(key) && request.Headers[key].IsIpAddress())
            {
                var ips = request.Headers[key];
                if (!String.IsNullOrEmpty(ips))
                {
                    if (ips.IndexOf(",", StringComparison.Ordinal) > 0)
                    {
                        var ip = ips.Split(',').FirstOrDefault();
                        if (!string.IsNullOrEmpty(ip)) return ip.Trim().RemoveIpPort();
                    }
                    return ips.RemoveIpPort();
                }
            }

            return request.UserHostAddress;
        }

        /// <summary> Получить IP адрес </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static String GetIpAddress(this HttpRequest request)
        {
            var key = request.Headers.AllKeys.FirstOrDefault(x => x.ToLower().Trim() == "x-forwarded-for");

            if (!String.IsNullOrEmpty(key) && request.Headers[key].IsIpAddress())
            {
                var ips = request.Headers[key];
                if (!String.IsNullOrEmpty(ips))
                {
                    if (ips.IndexOf(",", StringComparison.Ordinal) > 0)
                    {
                        var ip = ips.Split(',').FirstOrDefault();
                        if (!string.IsNullOrEmpty(ip)) return ip.Trim().RemoveIpPort();
                    }
                    return ips.RemoveIpPort();
                }
            }

            return request.UserHostAddress;
        }

        /// <summary> Удалить порт из IP адреса (бывает при x-forwaded-for) </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static string RemoveIpPort(this String ip)
        {
            if (ip.IndexOf(":", StringComparison.Ordinal) > 0)
            {
                return ip.Split(':')[0];
            }
            return ip;
        }

        public static bool IsOldOpera(this string userAgent)
        {
            bool isOldOpera = userAgent.ToLower().Contains("opera");
            return isOldOpera;
        }

        private static readonly string[] mobileDevices = { "iphone", "ppc", "windows ce", "blackberry", "opera mini", "mobile", "palm", "portable", "opera mobi" };

        public static bool IsMobile(this string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent))
            {
                return false;
            }
            userAgent = userAgent.ToLower();
            return mobileDevices.Any(x => userAgent.Contains(x));
        }
    }
}