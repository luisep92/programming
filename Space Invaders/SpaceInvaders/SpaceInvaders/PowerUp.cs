using Luis;
using DAM;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;
using SpaceInvaders.Base_classes;

namespace SpaceInvaders
{
    internal class PowerUp : Component
    {
        static List<Image> speedImages = new List<Image>();
        float time = 0;
        public PowerUp(GameObject parent)
        {
            this.gameObject = parent;
            parent.AddComponent(this);
        }

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            time += Time.deltaTime;
            Move();
            LimitMovement(world);
        }


        void LimitMovement(World world)
        {
            Transform thisT = this.gameObject.transform;
            if (thisT.position.y < world.Y.Min() - thisT.size.y)
                GameObject.Destroy(this.gameObject, world);
        }
        void Move()
        {
            Vector2 pos = this.gameObject.transform.position;
            pos.y -= 10 * Time.deltaTime;
            pos.x += (float)Math.Sin(time * 5) * 0.1f;
        }

        public static void SetSprites(IAssetManager manager)
        {
            speedImages.Add(manager.LoadImage("resources/PowerUps/Speed/1.png"));
            speedImages.Add(manager.LoadImage("resources/PowerUps/Speed/2.png"));
            speedImages.Add(manager.LoadImage("resources/PowerUps/Speed/3.png"));
        }

        public override void OnCollision(GameObject gameObject, IAssetManager manager, World world)
        {
            if (gameObject.tag == Tag.PLAYER)
            {
                gameObject.GetComponent<Player>().speed += 3;
                GameObject.Destroy(this.gameObject, world);
            }
        }

        public static GameObject SpeedPrefab()
        {
            GameObject go = new GameObject();
            PowerUp pu = new PowerUp(go);
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 0.2f, go);
            Collider col = new Collider(pu, go);

            go.transform.size = new Vector2(2, 2);

            ren.sprites = speedImages;
            ren.sprite = ren.sprites[0];
            ren.paintTrail = true;

            Vector2 s = go.transform.size;
            go.transform.size = new Vector2(3, 3 / Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height));

            return go;
        }
    }
}
