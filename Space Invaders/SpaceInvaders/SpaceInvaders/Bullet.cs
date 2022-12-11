using DAM;
using Luis;
using SpaceInvaders.Base_classes;

namespace SpaceInvaders
{
    internal class Bullet : Component
    {
        public Bullet(Tag tag, GameObject parent)
        {
            gameObject = parent;
            gameObject.tag = tag;
            gameObject.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            Move(world);
        }

        public override void OnCollision(GameObject go, IAssetManager manager, World world)
        {
            if(go.tag == Tag.ENEMY)
            {
                Enemy.GetEnemyType(go).GetDamage(world, manager, 1);
                DestroyBullet(world);
            }
        }       


        void Move(World world)
        {
            gameObject.transform.position.y += 15f * Time.deltaTime;
            LimitMovement(world);
        }

        void LimitMovement(World world)
        {
            Transform thisT = this.gameObject.transform;
            float limit = world.Y.Max() + thisT.size.y / 2;
            if (thisT.position.y > limit)
            {
                DestroyBullet(world);
            } 
        }

        void DestroyBullet(World world)
        {
            world.Destroy(this.gameObject, world.bulletPool);
        }
      
      
        // Interesante, ...., de esto tenemos que hablar, ..., segun entiendo por tu código, en Unity el concepto de GameObject es sólo
        // un punto de anclaje entre otra entidad superior y el mundo. Esa entidad superior puede ser una cosa como un Bullet, que es el que tiene
        // semántica, ... Entonces, ..., un humano es tambien un componente?
        public static GameObject Prefab(Tag tag)
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Bullet bul = new Bullet(tag, go);
            Collider col = new Collider(bul, go);

            go.transform.size = new Vector2(0.2f, 0.8f);
            ren.color = Color.red;

            return go;
        }
    }
}
