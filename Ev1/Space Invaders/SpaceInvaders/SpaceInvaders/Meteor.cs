using DAM;
using Luis;
using SpaceInvaders.Base_classes;

namespace SpaceInvaders
{
    internal class Meteor : Component   
    {
        public static Image sprite;
        public float xSpeed = (int)Utils.RandomRange(12f, 20f);
        public bool reverse = false;
        public Meteor(GameObject go)
        {
            gameObject = go;
            go.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            Move();
            LimitMovement(world);
            DistanceCollider(world);
        }
       

        public void DistanceCollider(World world)
        {
            if(Vector2.Distance(this.gameObject.transform.position, Player.instance.gameObject.transform.position) < this.gameObject.transform.size.x*0.5f)
            {
                Player.instance.GetDamage(world, 3);
                GameObject particle = GameObject.Instantiate(Particles.RandomExplosion(), this.gameObject.transform.position);
                particle.transform.size = new Vector2(7, 7);
                GameObject.Destroy(this.gameObject, world);
                world.Shake();
            }
        }

        public void Move()
        {
            this.gameObject.transform.position.x += xSpeed* Time.deltaTime;
            this.gameObject.transform.position.y -= 18 * Time.deltaTime;
        }
        protected void LimitMovement(World world)
        {
            Transform thisT = this.gameObject.transform;
            float limit = world.Y.Min() - thisT.size.y / 2;
            if (thisT.position.y < limit)
            {
                GameObject.Destroy(this.gameObject, world);
            }
        }
        public static void SetSprite(IAssetManager manager)
        {
            sprite = manager.LoadImage("resources/meteor.png");
        }
        public static GameObject Prefab()
        {
            GameObject go = new GameObject();
            Renderer ren = new Renderer(go);
            Meteor m = new Meteor(go);
            Collider col = new Collider(m, go);
            ren.sprite = sprite;
            ren.paintTrail = true;
            go.transform.size = new Vector2(5, 5);
            ren.color = new RGBA(1, 0.3f, 0.3f, 0.99999f);
            if((int)Utils.RandomRange(1f,2.99999f) == 2)
            {
                m.reverse = true;
                m.xSpeed *= -1f;
            }
            return go;
        }
    }
}
