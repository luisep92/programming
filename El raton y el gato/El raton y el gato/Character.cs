using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static El_raton_y_el_gato.TomAndJerry;
using static El_raton_y_el_gato.World;

namespace El_raton_y_el_gato
{
    public enum Type { CAT, RAT}
    internal class Character
    {
        public Type type;
        public Vector2 position;
        public Vector2 size;
        public RGBA color;
        public Image sprite;
        public float speed;

        public Vector2 initScale = new Vector2();

        #region CONSTRUCTOR
        public Character(Type type, Vector2 position, Vector2 scale, RGBA color, Image image, float speed)
        {
            this.type = type;
            this.position = position;
            this.position.x = position.x ;
            this.position.y = position.y ;
            this.size = scale;
            initScale.x = scale.x;
            initScale.y = scale.y;
            this.size.x = scale.x ;
            this.size.y = scale.y ;
            this.color = color;
            this.sprite = image;
            this.speed = speed;
        }

        public Character()
        {

        }

        public static Character NewChar(Type type, float x, float y, float width, float height, float r, float g, float b, float a, float speed)
        {
            Character c = new Character();
            c.type = type;
            c.position.x = x;
            c.position.y = y;
            c.size.x = width;
            c.size.y = height;
            c.color.r = r;
            c.color.g = g;
            c.color.b = b;
            c.color.a = a;
            c.speed = speed;

            return c;
        }
        #endregion

        #region RENDER
        public void RenderRectangle(ICanvas canvas)
        {
            canvas.FillRectangle(
            this.position.x - this.size.x/2,
            this.position.y - this.size.y/2,
            this.size.x,
            this.size.y,
            (float)this.color.r,
            (float)this.color.g,
            (float)this.color.b,
            (float)this.color.a);
        }
        public void Render(ICanvas canvas)
        {
           canvas.FillRectangle(
           this.position.x - this.size.x / 2,
           this.position.y - this.size.y / 2,
           this.size.x,
           this.size.y,
           this.sprite,
           0f,0f,1f,1f,1f,1f,1f,(float)this.color.a);

            if (this.type == Type.CAT)
                FlickerEffect();
            
        }
        public void Resize(IWindow window)
        {
            this.size.x = initScale.x * Meter(Dimensions().x);
            this.size.y = initScale.y * Meter(Dimensions().y);
        }
        public void FlickerEffect()
        {
            this.color.a = Utils.PingPong();
        }
        #endregion



        #region MOVEMENT
        void LimitMovement()
        {
            if (this.position.x > 10 - this.size.x/2)
                this.position.x = 10 - this.size.x/2;
            if (this.position.x < -10 + this.size.x / 2)
                this.position.x = -10 + this.size.x / 2;
            if (this.position.y > 5 - (this.size.y / 2))
                this.position.y = 5 - (this.size.y / 2);
            if (this.position.y  < -5 + this.size.y / 2)
                this.position.y = -5 + this.size.y / 2;
        }
        void MovePosition(IKeyboard keyboard)
        {
            if (this.type == Type.CAT)
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
