using DAM;
using Luis;


namespace SpaceInvaders
{
    internal class Player : Component
    {
        Vector2 direction = new Vector2();
        public float speed;
        GameObject fireR;
        GameObject fireL;
        Renderer ren;
        public int health = 5;

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
        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            SetFire(canvas, manager, world);
        }

        public override void Inputs(IKeyboard keyboard, IAssetManager manager, World world)
        {
            Move(keyboard, world);
            Shoot(keyboard, world, manager);
            if (Input.GetKeyDown(keyboard, Keys.G))
                GetDamage(world);
        }
        #endregion
        #region METHODS
        public void Shoot(IKeyboard k, World world, IAssetManager manager)
        {
            if(Input.GetKeyDown(k, Keys.Space))
            {
                Transform thisT = this.gameObject.transform;
                Vector2 shootPos = new Vector2(thisT.position.x, thisT.position.y + thisT.size.y / 2) ;
                world.Instantiate(shootPos, world.bulletPool, manager);
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

        public void Move(IKeyboard keyboard, World world)
        {
            MovePosition(keyboard);
            SetSprite();
            LimitMovement(world);
        }
        void MovePosition(IKeyboard keyboard)
        {
            Transform t = this.gameObject.transform;
            SetDirection(keyboard);
            t.position.x += direction.x;
        }
        void LimitMovement(World world)
        {
            Transform t = this.gameObject.transform;
            if (t.position.x > world.X.Max() - t.size.x / 2)
                t.position.x = world.X.Max() - t.size.x / 2;
            if (t.position.x < world.X.Min() + t.size.x / 2)
                t.position.x = world.X.Min() + t.size.x / 2;
            if (t.position.y > world.Y.Max() - t.size.y / 2)
                t.position.y = world.Y.Max() - t.size.y / 2;
            if (t.position.y < world.Y.Min() + t.size.y / 2)
                t.position.y = world.Y.Min() + t.size.y / 2;
        }
       
        public void GetDamage(World world)
        {
            health -= 1;
            Overlay ol = GameObject.FindObjectsOfType<Overlay>(world);
            ol.Update();
        }
        private void SetFire(ICanvas canvas,IAssetManager manager, World world)
        {
            Transform thisT = gameObject.transform;
            float offsetX = FireDist() * thisT.size.x / 2;
            SetFirePos(fireR, offsetX);
            SetFirePos(fireL, -offsetX);
            fireR.Behavior(canvas, manager, world);
            fireL.Behavior(canvas, manager, world);


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
