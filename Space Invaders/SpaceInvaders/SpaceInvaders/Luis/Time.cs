

namespace Luis
{
    internal class Time
    {
          
         static DateTime time1 = DateTime.Now;
         static DateTime time2 = DateTime.Now;

         public static float deltaTime; //Tiempo entre cada frame

         public static void UpdateDeltaTime() //Poner en el OnDraw
         {
            time2 = DateTime.Now;
            deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            time1 = time2;
         }
    } 
}
