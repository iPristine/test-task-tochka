using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tochka
{
    class Reader
    {
        public static string GetIdByConsole()
        {
            System.Console.WriteLine("Enter id(or domain):");
            string inputData = System.Console.ReadLine();
            if (inputData.Length>2 && inputData.Substring(0, 2) == "id") { return inputData.Substring(2); }
            if (inputData.Length >6 && inputData.Substring(0, 6) == "public") { return "-" + inputData.Substring(6); }
            if (inputData.Length >4 && inputData.Substring(0, 4) == "club") { return "-" + inputData.Substring(6); }
            ApplicationVkApi vk = new ApplicationVkApi();
            dynamic wall = JObject.Parse(vk.Request("wall.get", new string[] { "domain=" + inputData }));
            return wall.response.items[0].owner_id;
        }


        public static string ReadFromWall(string ownerId)
        {
            ApplicationVkApi vk = new ApplicationVkApi();

            string answ = vk.Request("wall.get", new string[] { "owner_id=" + ownerId, "count=5" });

            dynamic wall = JObject.Parse(answ);

            string data = "";
            foreach (var item in wall.response.items)
            {
                data += item.text;
            }
            return data;

        }
    }
}
