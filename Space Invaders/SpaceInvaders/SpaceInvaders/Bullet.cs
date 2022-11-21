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

        public override void Behavior(ICanvas canvas)
        {
            Move();
        }

        public override void OnCollision(GameObject go)
        {
            if(go.tag == Tag.ENEMY)
            {
                GameObject.Destroy(go);
                GameObject.Destroy(this.gameObject);
            }
        }

        void Move()
        {
            gameObject.transform.position.y += 15f * Time.deltaTime;
        }

      

        
        public static GameObject prefab(Tag tag)
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
