using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using RestSharp;

namespace Irbis.Utils.Helpers
{
    public static class TelegramBot
    {
        public static void SendMessageOrder(string text)
        {
            var message = new StringBuilder();

            try
            {
                var client = new RestClient("https://api.telegram.org");
                client.Execute(RequestBuilder(Groups.Order, message.ToString()));
            }
            catch
            {
                // ignored
            }
        }

        private static RestRequest RequestBuilder(int telegramGroup, string message)
        {
            var request = new RestRequest("/bot393884541:AAHxqTR03mbphMB5PK0YTMi3rBo6ObpegGw/sendMessage",
                Method.GET);

            request.AddParameter("chat_id", telegramGroup);
            request.AddParameter("disable_web_page_preview", true);
            request.AddParameter("text", message);
            request.AddParameter("parse_mode", "Markdown");
            return request;
        }

        public static class Groups
        {
            public const int Order = -219554415;
        }

    }
}