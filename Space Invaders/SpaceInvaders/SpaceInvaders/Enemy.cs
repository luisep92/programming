using DAM;
using Luis;
using System.Runtime.CompilerServices;

namespace SpaceInvaders
{
    internal class Enemy : Component
    {
        public float health = 1;
        float speed;
        
        public Enemy(float speed, GameObject parent)
        {
            this.speed = speed;
            this.gameObject = parent;
            this.gameObject.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            Move(world);
        }

        private void Move(World world)
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
            if (health <= 0)
                Die(world, manager);
        }

        private void Die(World world, IAssetManager manager)
        {
            this.gameObject.GetComponent<Animator>().Reset();
            DestroyEnemy(world);
            GameObject.Instantiate(Particles.Explosion(manager), this.gameObject.transform.position);
        }

        void DestroyEnemy(World world)
        {
            world.Destroy(this.gameObject, world.enemyPool);
        }

        public static GameObject Prefab(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Enemy enemy = new Enemy(1.5f,go);
            Animator anim = new Animator(ren, 0.5f, go);

            go.transform.size = new Vector2(1, 2);
            go.tag = Tag.ENEMY;

            ren.sprites.Add(manager.LoadImage("resources/enemy.png"));
            ren.sprites.Add(manager.LoadImage("resources/enemy2.png"));
            ren.sprite = ren.sprites[0];

            go.transform.size.x = go.transform.size.y * Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height);

            return go;
        }
    }
}
