using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace location
{
    class location
    {
        
        static void Main(string[] args)
        {
            string ip = "IP";
            string key = "KEY";
            Console.WriteLine(getlocation(ip,key));
        }

        public static string getlocation(string ip, string key)
        {
            string uri = string.Format("http://api.ipstack.com/" +
                "{0}" +
                "?access_key={1}"
                ,ip,key);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";            

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
            Console.WriteLine(r);
            return responseText;
        }
        
    }
}
