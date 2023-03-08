using Luis;
using DAM;
using System.Runtime.CompilerServices;
using OpenTK.Graphics.OpenGL;
using SpaceInvaders.Base_classes;

namespace SpaceInvaders
{
    internal class PowerUp : Component
    {
        public enum PowerUpType { HEAL, SPEED }

        static Image healImage;
        static List<Image> speedImages = new List<Image>();
        float time = 0;
        PowerUpType type;
        public PowerUp(GameObject parent, PowerUpType type)
        {
            this.gameObject = parent;
            parent.AddComponent(this);
            this.type = type;
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
            pos.x += (float)Math.Sin(time * 5) * 20 * Time.deltaTime;
        }

        public static void SetSprites(IAssetManager manager)
        {
            speedImages.Add(manager.LoadImage("resources/PowerUps/Speed/1.png"));
            speedImages.Add(manager.LoadImage("resources/PowerUps/Speed/2.png"));
            speedImages.Add(manager.LoadImage("resources/PowerUps/Speed/3.png"));

            healImage = manager.LoadImage("resources/heart.png");
        }

        public override void OnCollision(GameObject gameObject, IAssetManager manager, World world)
        {
            if (gameObject.tag == Tag.PLAYER)
            {
                if(this.type == PowerUpType.SPEED)
                {
                    gameObject.GetComponent<Player>().speed += 3;
                }
                else if(this.type == PowerUpType.HEAL)
                {
                    gameObject.GetComponent<Player>().health += 1;
                }
                GameObject.Destroy(this.gameObject, world);
            }
        }


        public static GameObject RandomPowerUp()
        {
            if ((int)Utils.RandomRange(1f, 2.99999f) == 1)
                return SpeedPrefab();
            else
                return HealPrefab();
        }
        public static GameObject SpeedPrefab()
        {
            GameObject go = new GameObject();
            PowerUp pu = new PowerUp(go, PowerUpType.SPEED);
            Renderer ren = new Renderer(go);
            Animator anim = new Animator(ren, 0.2f, go);
            Collider col = new Collider(pu, go);

            ren.sprites = speedImages;
            ren.sprite = ren.sprites[0];
            ren.paintTrail = true;

            go.transform.size = new Vector2(3, 3 / Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height));

            return go;
        }
        public static GameObject HealPrefab()
        {
            GameObject go = new GameObject();
            PowerUp pu = new PowerUp(go, PowerUpType.HEAL);
            Renderer ren = new Renderer(go);
            Collider col = new Collider(pu, go);

            ren.sprite = healImage;
            ren.paintTrail = true;
            go.transform.size = new Vector2(3, 3 / Utils.AspectRatio(ren.sprite.Width, ren.sprite.Height));
            return go;
        }
    }
}
