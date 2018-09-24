using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tochka
{ 
    public static class Writer
    {
        public static void PostStatisticToWall(string ownerId, string statisticOfFrequencyJson)
        {
            ApplicationVkApi vk = new ApplicationVkApi();
            vk.Request("wall.post", 
                        new string[] { "owner_id=" + ownerId, "message=" + statisticOfFrequencyJson });
        }
    }
}
