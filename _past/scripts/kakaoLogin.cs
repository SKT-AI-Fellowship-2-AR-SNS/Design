using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace restApi
{
    class kakaoLogin
    {
        static void Main(string[] args)
        {

            getUserInfo("Auth Code");
        }

        public static string getUserInfo(string token)
        {
            string UserInfo = "";
            string uri = "https://kapi.kakao.com/v2/user/me";
            string header = "Bearer " + token;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.Method = "GET";
            request.Headers.Add("Authorization", header);

            string responseText = string.Empty;
            using (WebResponse resp = request.GetResponse())
            {
                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }
            var r = JObject.Parse(responseText);
            UserInfo = (string)r["id"];
            Console.WriteLine(r);
            return UserInfo;
        }
    }
}
