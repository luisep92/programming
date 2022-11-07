using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static El_raton_y_el_gato.TomAndJerry;

namespace El_raton_y_el_gato
{
    public enum Type { CAT, RAT}
    internal class Character
    {
        public Type Type;
        public Vector2 position;
        public Vector2 scale;
        public RGBA color;
        public float speed;

        #region CONSTRUCTOR
        public Character(Type type, Vector2 position, Vector2 scale, RGBA color, float speed)
        {
            Type = type;
            this.position = position;
            this.position.x = position.x * Meter(Dimensions().x);
            this.position.y = position.y * Meter(Dimensions().y);
            this.scale = scale;
            this.scale.x = scale.x * Meter(Dimensions().x);
            this.scale.y = scale.y * Meter(Dimensions().y);
            this.color = color;
            this.speed = speed;
        }

        public Character()
        {

        }

        public static Character NewChar(Type type, float x, float y, float width, float height, float r, float g, float b, float a, float speed)
        {
            Character c = new Character();
            c.Type = type;
            c.position.x = x;
            c.position.y = y;
            c.scale.x = width;
            c.scale.y = height;
            c.color.r = r;
            c.color.g = g;
            c.color.b = b;
            c.color.a = a;
            c.speed = speed;

            return c;
        }
        #endregion

        #region RENDER
        public void Render(ICanvas canvas)
        {
            canvas.FillRectangle(
            this.position.x - this.scale.x/2,
            this.position.y - this.scale.y/2,
            this.scale.x,
            this.scale.y,
            (float)this.color.r,
            (float)this.color.g,
            (float)this.color.b,
            (float)this.color.a);
        }
        #endregion

        #region MOVEMENT
        void LimitMovement()
        {
            if (this.position.x > 1 - this.scale.x/2)
                this.position.x = 1 - this.scale.x/2;
            if (this.position.x < -1 + this.scale.x / 2)
                this.position.x = -1 + this.scale.x / 2;
            if (this.position.y > 1 - (this.scale.y / 2))
                this.position.y = 1 - (this.scale.y / 2);
            if (this.position.y  < -1 + this.scale.y / 2)
                this.position.y = -1 + this.scale.y / 2;
        }
        void MovePosition(IKeyboard keyboard)
        {
            if (this.Type == Type.CAT)
            {
                if (keyboard.IsKeyDown(Keys.Left))
                    this.position.x -= 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.Right))
                    this.position.x += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.Up))
                    this.position.y += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.Down))
                    this.position.y -= 0.0001f * speed;
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.A))
                    this.position.x -= 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.D))
                    this.position.x += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.W))
                    this.position.y += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.S))
                    this.position.y -= 0.0001f * speed;
            }
        }
        public void Move(IKeyboard keyboard)
        {
           MovePosition(keyboard);
           LimitMovement();
        }
        #endregion
    }
}
