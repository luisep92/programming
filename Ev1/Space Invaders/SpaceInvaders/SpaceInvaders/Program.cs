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
        }
    }
}