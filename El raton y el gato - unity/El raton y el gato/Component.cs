using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class Component
    {
        
        public virtual void Render(ICanvas canvas, GameObject obj)
        {
            Console.WriteLine("ERROR: Has accedido a un componente que no es un renderer y has hecho Render();");
        }
        
    }
}
