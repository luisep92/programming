using DAM;
using static El_raton_y_el_gato.World;
using static El_raton_y_el_gato.Utils;
using OpenTK.Graphics.OpenGL;

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

        public List<Image> sprites = new List<Image>();
        private Vector2 direction = new Vector2(0,0);  //Para el movimiento de la rata

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

        public void FillSpriteList(IAssetManager am)
        {
            if (this.type == Type.CAT)
            {
                sprites.Add(am.LoadImage("resources/sprites/catA.png"));
                sprites.Add(am.LoadImage("resources/sprites/catAD.png"));
                sprites.Add(am.LoadImage("resources/sprites/catD.png"));
                sprites.Add(am.LoadImage("resources/sprites/catBD.png"));
                sprites.Add(am.LoadImage("resources/sprites/catB.png"));
                sprites.Add(am.LoadImage("resources/sprites/catBI.png"));
                sprites.Add(am.LoadImage("resources/sprites/catI.png"));
                sprites.Add(am.LoadImage("resources/sprites/catAI.png"));
            }
            else
            {
                sprites.Add(am.LoadImage("resources/sprites/ratA.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratAD.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratD.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratBD.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratB.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratBI.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratI.png"));
                sprites.Add(am.LoadImage("resources/sprites/ratAI.png"));
            }
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

        public void SetSprite()
        {
            if (direction.x == 0 && direction.y > 0)
                sprite = sprites[0];
            else if (direction.x > 0 && direction.y > 0)
                sprite = sprites[1];
            else if (direction.x > 0 && direction.y == 0)
                sprite = sprites[2];
            else if (direction.x > 0 && direction.y < 0)
                sprite = sprites[3];
            else if (direction.x == 0 && direction.y < 0)
                sprite = sprites[4];
            else if (direction.x < 0 && direction.y < 0)
                sprite = sprites[5];
            else if (direction.x < 0 && direction.y == 0)
                sprite = sprites[6];
            else if (direction.x < 0 && direction.y > 0)
                sprite = sprites[7];
            else
                sprite = sprites[6];
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

        public void SetDirection(IKeyboard keyboard)
        {
            if(this.type == Type.CAT)
            {
                if (keyboard.IsKeyDown(Keys.Left))
                    this.direction.x = -0.0001f * speed;
                else if (keyboard.IsKeyDown(Keys.Right))
                    this.direction.x = 0.0001f * speed;
                else direction.x = 0;

                if (keyboard.IsKeyDown(Keys.Up))
                    this.direction.y = 0.0001f * speed;
                else if (keyboard.IsKeyDown(Keys.Down))
                    this.direction.y = -0.0001f * speed;
                else
                    direction.y = 0;
            }
            else
            {
                int seed = (int)(TomAndJerry.time * 10) % 25;
                if(seed == 0)
                {
                    direction.x = 0.0001f * speed * (int)RandomRange(-1.99999f, 1.99999f);
                    direction.y = 0.0001f * speed * (int)RandomRange(-1.99999f, 1.99999f);
                }
            }
        }

        void MovePosition(IKeyboard keyboard)
        {
            SetDirection(keyboard);
            SetSprite();
            this.position.x += direction.x;
            this.position.y += direction.y;
        }
        #endregion
    }
}
