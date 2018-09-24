using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tochka
{
    class ApplicationVkApi
    {
        private string Token;
        private string apiVersion = "5.85";

        public ApplicationVkApi(string accesToken = "YOUR_ACCES_TOKEN")
        {
            Token = accesToken;
        }

        public string Request(string method, string[] parametrs)
        {
            string params_str = string.Join("&", parametrs);
            System.Net.WebRequest req = System.Net.WebRequest.Create("https://api.vk.com/method/" + method + "?" + params_str + "&access_token=" + Token + "&v=" + apiVersion);
            System.IO.Stream stream = req.GetResponse().GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }
}
