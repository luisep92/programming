using Luis;
using DAM;

namespace SpaceInvaders
{
    internal class EnemyMad : Enemy
    {
        Vector2 center = new Vector2(1000, 1000);
        float time = 0;
        bool isSpinning = false;
        float cooldown = Utils.RandomRange(1.25f, 5f);
        bool reverse = false;
        public static List<Image> enemyMadSprites = new List<Image>();

        public EnemyMad(float speed, GameObject parent) : base(speed, parent)
        {
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            damageTime += Time.deltaTime;
            if (time > cooldown)
            {
                isSpinning = true;
                time = 0;
            }
            Move(world);
            GetDamageAnim();
        }
        public override void Move(World world)
        {
            center.y -= speed * Time.deltaTime;
            DoCircles(5f, 5f);
        }

        private void DoCircles(float speed, float radius)
        {
            Vector2 pos = this.gameObject.transform.position;

            time += Time.deltaTime;

            if (this.center.x == 1000f)
            {
                center.x = pos.x;
                center.y = pos.y;
            }
            if (isSpinning)
            {
                pos.x = (float)Math.Sin(time * speed) * radius + center.x;

                if(reverse)
                    pos.y = (float)-Math.Cos(time * speed) * radius + center.y + radius;
                else
                    pos.y = (float)Math.Cos(time * speed) * radius + center.y - radius;
            }
            else
            {
                pos.y = center.y;
                pos.x = center.x;
            }

            if (time >= 1.25f && isSpinning)
            {
                time = 0;
                isSpinning = false;
                cooldown = Utils.RandomRange(1.25f, 3.5f);
                int ran = (int)Utils.RandomRange(1f, 2.99999f);
                if (ran == 1)
                    reverse = false;
                else
                    reverse = true;
            }
        }
        public override void DestroyEnemy(World world)
        {
            this.center.x = 1000f;
            this.center.y = 1000f;
            time = 0;
            isSpinning = false;
            base.DestroyEnemy(world);
        }
        public static void FillSpriteList(IAssetManager manager)
        {
            enemyMadSprites.Add(manager.LoadImage("resources/enemyMad.png"));
            enemyMadSprites.Add(manager.LoadImage("resources/enemyMad2.png"));
        }
        public static GameObject Prefab(IAssetManager manager)
        {
            GameObject go = new GameObject();
            EnemyMad enemy = new EnemyMad(2f, go);
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 0.5f, go);

            go.transform.size = new Vector2(1, 2);
            go.tag = Tag.ENEMY;

            ren.sprites = enemyMadSprites;
            ren.sprite = ren.sprites[0];

            go.transform.size.x = go.transform.size.y * Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height);

            return go;
        }
    }
}
