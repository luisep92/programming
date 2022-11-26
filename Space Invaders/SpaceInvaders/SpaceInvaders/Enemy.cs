using DAM;
using Luis;
using System.Drawing.Drawing2D;

namespace SpaceInvaders
{
    internal class Enemy : Component
    {
        public float health = 3;
        public float speed;
        public static List<Image> enemySprites = new List<Image>();
        public float damageTime = 5f;
        Renderer ren = null;
        
        public Enemy(float speed, GameObject parent)
        {
            this.speed = speed;
            this.gameObject = parent;
            this.gameObject.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            damageTime += Time.deltaTime;
            Move(world);
            GetDamageAnim();
        }

    

        public virtual void Move(World world)
        {
            this.gameObject.transform.position.y -= speed * Time.deltaTime;
            LimitMovement(world);
        }

       

        private void LimitMovement(World world)
        {
            Transform thisT = this.gameObject.transform;
            float limit = world.Y.Min() - thisT.size.y / 2;
            if (thisT.position.y < limit)
                DestroyEnemy(world);
        }

        public void GetDamage(World world, IAssetManager manager)
        {
            health -= 1;
            damageTime = 0;
            if (health <= 0)
                Die(world, manager);
        }


        public void GetDamageAnim()
        {
            if(ren != null)
            {
                if (damageTime < 0.15f)
                    ren.color = Color.red;
                else
                    ren.color = Color.white;
            }
            else
            {
                ren = this.gameObject.GetComponent<Renderer>();
            }
        }

        private void Die(World world, IAssetManager manager)
        {
            this.gameObject.GetComponent<Animator>().Reset();
            DestroyEnemy(world);
            world.Shake();
            GameObject.Instantiate(Particles.RandomExplosion(), this.gameObject.transform.position);
           
        }

        public virtual void DestroyEnemy(World world)
        {
            damageTime = 5f;
            health = 3;
            world.Destroy(this.gameObject, world.enemyPool);
        }


        public static void FillImageList(IAssetManager manager)
        {
            enemySprites.Add(manager.LoadImage("resources/enemy.png"));
            enemySprites.Add(manager.LoadImage("resources/enemy2.png"));
        }

        public static Enemy GetEnemyType(GameObject go)
        {
            foreach(Component c in go.components)
            {
                Type type = c.GetType();
                if (type == typeof(Enemy) || type == typeof(EnemyMad))
                    return c as Enemy;
            }
            return null;
        }

        public static GameObject Prefab(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Enemy enemy = new Enemy(2f, go);
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 0.5f, go);

            go.transform.size = new Vector2(1, 2);
            go.tag = Tag.ENEMY;

            ren.sprites = enemySprites;
            ren.sprite = ren.sprites[0];

            go.transform.size.x = go.transform.size.y * Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height);

            return go;
        }
    }
}
