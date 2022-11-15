using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Time
    {
        static int currentMs = MiliSeconds();
        int s = 0;
        
        public static void CountTime()
        {

            for (int i = 0; i < 10000000; i++)
            {
                if (currentMs != MiliSeconds())
                {
                    Console.Write(MiliSeconds());
                    currentMs = MiliSeconds();
                }
                Console.WriteLine(MiliSeconds());
            }
        }
        public static int MiliSeconds()
        {
            return DateTime.UtcNow.Millisecond;
        }
    }

        
    
}
