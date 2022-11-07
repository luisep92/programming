using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_lista_heren
{
    internal class Transf : Component
    {
        public string name;

        public Transf(string name)
        {
            this.name = name;
        }

        public override void DoSmt()
        {
            base.DoSmt();
            Console.WriteLine("TRANSF");
        }
    }
}
