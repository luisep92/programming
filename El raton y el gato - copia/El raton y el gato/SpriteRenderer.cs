using DAM;
using El_raton_y_el_gato.DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class SpriteRenderer : Component
    {
        public Material material = new Material();
        public override void Render(ICanvas canvas, GameObject obj)
        {
            canvas.FillRectangle(
                obj.transform.position.x - obj.transform.scale.x / 2,
                obj.transform.position.y - obj.transform.scale.y / 2,
                obj.transform.scale.x,
                obj.transform.scale.y,
                (float)material.color.r,
                (float)material.color.g,
                (float)material.color.b,
                (float)material.color.a);
        }
    }
}
