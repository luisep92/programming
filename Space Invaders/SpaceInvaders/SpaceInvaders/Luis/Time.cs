using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Luis
{
    internal class Time
    {
          
         static DateTime time1 = DateTime.Now;
         static DateTime time2 = DateTime.Now;
         public static float deltaTime;

         public static void UpdateDeltaTime()
         {
            time2 = DateTime.Now;
            deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            time1 = time2;
         }
        /*
        static float ms1 = DateTime.UtcNow.Millisecond;
        static float ms2 = DateTime.UtcNow.Millisecond;

        public static float DeltaTime;

        public static void UpdateDeltaTime()
        {
            ms2 = DateTime.UtcNow.Millisecond;
            float dif = ms2 - ms1;
            if (dif < 0)
                dif += 1000;
            ms1 = ms2;
            DeltaTime = dif / 1000;
        }*/
       
    } 
}
