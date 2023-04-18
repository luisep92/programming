namespace Luisbreria
{
    public class Time
    {
        // Yo no hubiese puesto estas cosas como variables de clase
        static DateTime time1 = DateTime.Now;
        static DateTime time2 = DateTime.Now;
        static float _appTime = 0;
        public static float deltaTime; //Tiempo entre cada frame

        public static float AppTime => _appTime;

        public static void UpdateDeltaTime() //Poner en el OnDraw
        {
            time2 = DateTime.Now;
            deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            _appTime += deltaTime;
            time1 = time2;

        }
    }
}