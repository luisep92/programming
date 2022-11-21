using DAM;
using Luis;
using System.Runtime.CompilerServices;

namespace SpaceInvaders
{
    internal class Enemy : Component
    {
        float speed;

        public Enemy(float speed, GameObject parent)
        {
            this.speed = speed;
            this.gameObject = parent;
            this.gameObject.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas)
        {
            Move();
        }

        public void Move()
        {
            this.gameObject.transform.position.y -= speed * Time.deltaTime;
        }

        public static GameObject Prefab(IAssetManager manager)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Enemy enemy = new Enemy(3,go);
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
