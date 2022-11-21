using DAM;
using Luis;
using OpenTK.Graphics.OpenGL;
using static SpaceInvaders.World;

namespace SpaceInvaders
{
    internal class Player : Component
    {
        Vector2 direction = new Vector2();
        float speed;
        GameObject fireR;
        GameObject fireL;
        Renderer ren;

        #region CONSTRUCTOR
        public Player(float speed, Vector2 size, GameObject parent, IAssetManager manager)
        {
            this.speed = speed;
            gameObject = parent;
            parent.transform.size = size;
            parent.AddComponent(this);
            parent.tag = Tag.PLAYER;
            fireR = Fire(manager);
            fireL = Fire(manager);
        }
        #endregion
        #region BEHAVIOR
        public override void Behavior(ICanvas canvas)
        {
            SetFire(canvas);
        }

        public override void Inputs(IKeyboard keyboard)
        {
            Move(keyboard);
            Shoot(keyboard);
        }
        #endregion
        #region METHODS
        public void Shoot(IKeyboard k)
        {
            if(Input.GetKeyDown(k, Keys.Space))
            {
                Transform thisT = this.gameObject.transform;
                Vector2 shootPos = new Vector2(thisT.position.x, thisT.position.y + thisT.size.y / 2) ;
                GameObject.Instantiate(Bullet.prefab(Tag.PLAYER), shootPos);
            }
        }
        public void SetDirection(IKeyboard keyboard)
        {
            float dt = Time.deltaTime;
            if (Input.GetKey(keyboard, Keys.A))
                this.direction.x = -1f * speed * dt;
            else if (Input.GetKey(keyboard, Keys.D))
                this.direction.x = 1f * speed * dt;
            else direction.x = 0;
        }

        public void Move(IKeyboard keyboard)
        {
            MovePosition(keyboard);
            SetSprite();
            LimitMovement();
        }
        void MovePosition(IKeyboard keyboard)
        {
            Transform t = this.gameObject.transform;
            SetDirection(keyboard);
            t.position.x += direction.x;
        }
        void LimitMovement()
        {
            Transform t = this.gameObject.transform;
            if (t.position.x > X.Max() - t.size.x / 2)
                t.position.x = X.Max() - t.size.x / 2;
            if (t.position.x < X.Min() + t.size.x / 2)
                t.position.x = X.Min() + t.size.x / 2;
            if (t.position.y > Y.Max() - t.size.y / 2)
                t.position.y = Y.Max() - t.size.y / 2;
            if (t.position.y < Y.Min() + t.size.y / 2)
                t.position.y = Y.Min() + t.size.y / 2;
        }
       
        private void SetFire(ICanvas canvas)
        {
            Transform thisT = gameObject.transform;
            float offsetX = FireDist() * thisT.size.x / 2;
            SetFirePos(fireR, offsetX);
            SetFirePos(fireL, -offsetX);
            fireR.Behavior(canvas);
            fireL.Behavior(canvas);


            void SetFirePos(GameObject go, float offsetX)
            {
                go.transform.position.y = thisT.position.y - (thisT.size.y / 2f + go.transform.size.y / 2f);
                go.transform.position.x = thisT.position.x + offsetX;
            }

            float FireDist()
            {
                if (direction.x != 0)
                    return 0.6f;
                return 0.8f;
            }
        }

        public void SetSprite()
        {
            if (direction.x > 0)
                ren.sprite = ren.sprites[2];
            else if (direction.x < 0)
                ren.sprite = ren.sprites[1];
            else 
                ren.sprite = ren.sprites[0];
        }

        public void Resize()
        {
            Vector2 size = this.gameObject.transform.size;
            size.x = size.x * Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height);
        }
        #endregion
        #region PREFABS
        public static GameObject prefab(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Vector2 size = new Vector2(2, 2);
            Player player = new Player(10f, size, go, manager);

            player.ren = ren;

            ren.sprites.Add(manager.LoadImage("resources/ship2.png"));
            ren.sprites.Add(manager.LoadImage("resources/ship2L.png"));
            ren.sprites.Add(manager.LoadImage("resources/ship2R.png"));
            ren.sprite = ren.sprites[0];

            return go;
        }

        public static GameObject Fire(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 0.2f, go);

            go.transform.size.x = 0.5f;

            ren.sprites.Add(manager.LoadImage("resources/fire1.png"));
            ren.sprites.Add(manager.LoadImage("resources/fire2.png"));
            ren.sprite = ren.sprites[0];

            return go;
        }
        #endregion
    }
}
