using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    internal class Herencia
    {
        
    }
    internal class ClassA
    {
        public virtual void M1()
        {
            Console.WriteLine("a");
        }
    }
    internal class ClassB : ClassA
    {
        public override void M1()
        {
            Console.WriteLine("aa");
        }
    }
    internal class ClassC : ClassB
    {
        public override void M1()
        {
            Console.WriteLine("c");
            base.M1();
        }
    }
}
