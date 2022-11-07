using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_lista_heren
{
    internal class Component
    {
        public string valor = "a";

        public virtual void DoSmt()
        {
            Console.WriteLine("COMPONENT");
        }
    }
}
