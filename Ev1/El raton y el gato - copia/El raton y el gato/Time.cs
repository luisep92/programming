using System.Timers;

namespace El_raton_y_el_gato
{
    internal class Time
    {
        public static float miliSeconds = 0;
        public static System.Timers.Timer timer = new System.Timers.Timer(100);
        //SOLO CUENTA BIEN A PARTIR DE DECIMAS 
        public static void Timer()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            Console.ReadKey();
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            miliSeconds++;
            Console.WriteLine(miliSeconds/10 + " Seconds");  
        }
    }
}
