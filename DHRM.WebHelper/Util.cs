using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHRM.WebHelper
{
    public class Util
    {
        public static string GetRandomNumber(int length)
        {
            Random ran = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= length; i++)
            {
                sb.Append(ran.Next(0, 9));
            }
            return sb.ToString();
        }
    }
}
