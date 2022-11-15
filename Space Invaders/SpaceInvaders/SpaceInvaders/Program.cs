using DAM;
using OpenTK.Graphics.GL;
using System.Security.Principal;

namespace SpaceInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Game.Launch(new SpaceInvaders());
            //deltatime
            /*  int current = time1();
              int s = 0;
              for(int i = 0; i < 10000000; i++)
              {
                  if(current != time1())
                  {
                      Console.Write(time1());
                      current = time1();
                  }
                  Console.WriteLine( time1());
              }
          }

          public static int time1()
          {
              return DateTime.UtcNow.Millisecond;
          }*/
        }
    }
}