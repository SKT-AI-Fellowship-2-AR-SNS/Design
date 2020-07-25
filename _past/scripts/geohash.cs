using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace apiTest
{
    class geohash
    {
        static void Main(string[] args)
        {
            double latitude, longitude;
            Console.WriteLine(geoHash(latitude, longitude));
        }

        public static string geoHash(double a, double b)
        {
            string url = "http://geohash.org?q="+a+","+b+"&format=url&redirect=0";

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
            string[] s = responseText.Split(new char[] {'/'});
            return s[3];
        }

    }
}
