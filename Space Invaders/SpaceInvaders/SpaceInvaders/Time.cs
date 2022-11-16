using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Time
    {
        static float _dTime = 0;
        static DateTime time1 = DateTime.Now;
        static  DateTime time2 = DateTime.Now;

        public static float dTime { get { return _dTime; } }

        public static void CountTime()
        {
            _dTime += (float)DeltaTime();
        }

        public static double DeltaTime()
        {
            time2 = DateTime.Now;
            float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            time1 = time2;
            return deltaTime;
        }
    } 
}
