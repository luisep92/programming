using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_lista_heren
{
    internal class SRen : Component
    {
        public string smt;

        public SRen(string smt)
        {
            this.smt = smt;
        }

        public override void DoSmt()
        {
            base.DoSmt();
            Console.WriteLine("SRen");
        }
    }
}
