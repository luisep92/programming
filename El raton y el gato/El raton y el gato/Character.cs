using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    public enum Type { CAT, RAT}
    internal class Character
    {
        public Type Type;
        public Vector2 position;
        public Vector2 scale;
        public RGBA color;

        public Character(Type type, Vector2 position, Vector2 scale, RGBA color)
        {
            Type = type;
            this.position = position;
            this.position.x = this.position.x - scale.x / 2;
            this.position.y = this.position.y - scale.y / 2;
            this.scale = scale;
            this.color = color;
        }

        public void Move()
        {
            if (Type == Type.CAT)
                this.position.x += 0.001f;
            else
                this.position.x -= 0.001f;
        }
    }
}
