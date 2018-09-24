using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tochka
{
    public class MyStatistic
    {
        public static IEnumerable<KeyValuePair< char, int>> CountsOfChars(string data)
        {
            Dictionary<char, int> f = new Dictionary<char, int>();
            foreach (var simbol in data)
            {
                if (f.ContainsKey(simbol)){f[simbol]++;}
                else{f.Add(simbol, 1);}
            }
            return f;
        }
        public static IEnumerable<KeyValuePair<char, double>> FrequencyOfChars(IEnumerable<KeyValuePair<char, int>> letterCountery, int lengthOfData)
        {
            return letterCountery
                    .Select(elem => new KeyValuePair<char, Double>(elem.Key, 100 * Convert.ToDouble(elem.Value) / lengthOfData));
        }

    }
}
