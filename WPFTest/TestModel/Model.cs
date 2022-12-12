using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModel
{
    public class Model
    {
        public static string Enumerate(int n)
        {
            string result = "0";
            for(int i = 1; i <= n; i++)
            {
                result += "," + i;
            }
            return result;
        }
    }
}
