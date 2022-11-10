using DAM;
using static El_raton_y_el_gato.World;
using static El_raton_y_el_gato.Utils;

namespace El_raton_y_el_gato
{
    public enum Type {CAT, RAT}
    internal class Character
    {
        public Type type;
        public Vector2 position;
        public Vector2 size;
        public RGBA color;
        public Image sprite;
        public float speed;

        #region CONSTRUCTOR
        public Character(Type type, Vector2 position, Vector2 size, RGBA color, Image sprite, float speed)
        {
            this.type = type;
            this.position = position;
            this.size = size;
            this.size.y = size.x / AspectRatio(sprite.Width, sprite.Height);
            this.color = color;
            this.sprite = sprite;
            this.speed = speed;
        }

        public Character()
        {

        }
        #endregion

        #region RENDER
        public void RenderRectangle(ICanvas canvas)
        {
            FillRectangle(
                canvas,
                this.position.x - this.size.x/2,
                this.position.y - this.size.y/2,
                this.size.x,
                this.size.y,
                this.color);
        }
        public void Render(ICanvas canvas)
        {
            canvas.FillRectangle(
                this.position.x - this.size.x / 2,
                this.position.y - this.size.y / 2,
                this.size.x,
                this.size.y,
                this.sprite,
                0f,0f,1f,1f,1f,1f,1f,
                (float)this.color.a);

            if (this.type == Type.RAT)
                FlickerEffect();
        }
       
        public void FlickerEffect()
        {
            this.color.a = PingPong(0.99999f);
        }
        #endregion

        #region MOVEMENT
        public void Move(IKeyboard keyboard)
        {
            MovePosition(keyboard);
            LimitMovement();
        }

        void LimitMovement()
        {
            if (this.position.x > X.Max() - this.size.x / 2)
                this.position.x = X.Max() - this.size.x / 2;
            if (this.position.x < X.Min() + this.size.x / 2)
                this.position.x = X.Min() + this.size.x / 2;
            if (this.position.y > Y.Max() - this.size.y / 2)
                this.position.y = Y.Max() - this.size.y / 2;
            if (this.position.y < Y.Min() + this.size.y / 2)
                this.position.y = Y.Min() + this.size.y / 2;
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
        #endregion
    }
}
