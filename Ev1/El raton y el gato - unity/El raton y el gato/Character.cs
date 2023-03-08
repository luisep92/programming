using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    public enum Type { CAT, RAT}
    internal class Character : GameObject
    {
        public Type Type;
        public float speed;
        SpriteRenderer spriteRenderer;
        public Character(Type type, Vector2 position, Vector2 scale, RGBA color, float speed)
        {
            Type = type;
            transform.position = position;
            this.transform.scale = scale;
            this.speed = speed;
            spriteRenderer = new SpriteRenderer();
            spriteRenderer.material.color = color;
            components.Add(spriteRenderer);
        }

        public Character()
        {

        }

        public static Character NewChar(Type type, float x, float y, float width, float height, float r, float g, float b, float a, float speed)
        {
            Character c = new Character();
            c.Type = type;
            c.transform.position.x = x;
            c.transform.position.y = y;
            c.transform.scale.x = width;
            c.transform.scale.y = height;
            c.spriteRenderer.material.color.r = r;
            c.spriteRenderer.material.color.g = g;
            c.spriteRenderer.material.color.b = b;
            c.spriteRenderer.material.color.a = a;
            c.speed = speed;

            return c;
        }

        void LimitMovement()
        {
            if (this.transform.position.x > 1 - this.transform.scale.x/2)
                this.transform.position.x = 1 - this.transform.scale.x/2;
            if (this.transform.position.x < -1 + this.transform.scale.x / 2)
                this.transform.position.x = -1 + this.transform.scale.x / 2;
            if (this.transform.position.y > 1 - this.transform.scale.y / 2)
                this.transform.position.y = 1 - this.transform.scale.y / 2;
            if (this.transform.position.y  < -1 + this.transform.scale.y / 2)
                this.transform.position.y = -1 + this.transform.scale.y / 2;
        }
        void MovePosition(IKeyboard keyboard)
        {
            if (this.Type == Type.CAT)
            {
                if (keyboard.IsKeyDown(Keys.Left))
                    this.transform.position.x -= 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.Right))
                    this.transform.position.x += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.Up))
                    this.transform.position.y += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.Down))
                    this.transform.position.y -= 0.0001f * speed;
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.A))
                    this.transform.position.x -= 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.D))
                    this.transform.position.x += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.W))
                    this.transform.position.y += 0.0001f * speed;
                if (keyboard.IsKeyDown(Keys.S))
                    this.transform.position.y -= 0.0001f * speed;
            }
        }
        public void Move(IKeyboard keyboard)
        {
           MovePosition(keyboard);
           LimitMovement();
        }
        
    }
}
