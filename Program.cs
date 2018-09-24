using System;
using System.Collections.Generic;
using System.Linq;

namespace Tochka
{
    class Program
    {
        public static string MyDictionaryToJson(IEnumerable< KeyValuePair< char, Double>> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": {1:0.000}", d.Key, d.Value));
            return "{" + string.Join(",", entries) + "}";
        }


        static void Main(string[] args)
        {
            while (true) { 
                string ownerId = Reader.GetIdByConsole();

                string data = Reader.ReadFromWall(ownerId);

                IEnumerable<KeyValuePair<char, int>> stasisticOfCount = MyStatistic.CountsOfChars(data);
                IEnumerable<KeyValuePair<char, double>> statisticOfFrequency = MyStatistic.FrequencyOfChars(stasisticOfCount, data.Length);
                string statisticOfFrequencyJson = MyDictionaryToJson(statisticOfFrequency);

                Writer.PostStatisticToWall(ownerId, statisticOfFrequencyJson);
            }
        }
    }
}