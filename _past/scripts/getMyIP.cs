using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace location
{
    class getMyIP
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMyIP());

        }

        public static string GetMyIP()
        {
            string url = "https://api.ip.pe.kr";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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
            return responseText;

        }

    }
}
