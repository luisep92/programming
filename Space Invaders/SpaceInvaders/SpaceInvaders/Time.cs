using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Time
    {
        public static int currentMs = MiliSeconds();
        public static int second = 0;
        
        public static void CountTime()
        {
            if (currentMs != MiliSeconds())
            {
               
                currentMs = MiliSeconds();

                if (currentMs == 0)
                {
                    second++;
                }
            }
        }
        public static int MiliSeconds()
        {
            return DateTime.UtcNow.Millisecond;
        }
    } 
}
