using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class World
    {
        public Vector2 X = new Vector2(-15, 15);
        public Vector2 Y = new Vector2(-20, 20);
        public List<GameObject> WorldObjects = new List<GameObject>();
        public Image background;
        float noiseTime = 5f;


        public Vector2 Dimensions()
        {
            return Vector2.Diference(X, Y);
        }

        public void SetCamera(ICanvas canvas, World world)
        {
            canvas.SetCamera(world.X.Min() + Noise(), world.Y.Min() + Noise(), world.X.Max() + Noise(), world.Y.Max() + Noise(), true);
        }

        public void Shake()
        {
            noiseTime = 0;
        }
        float Noise()
        {
            if (noiseTime < 0.35f)
                return Utils.RandomRange(-0.3f, 0.3f);
            else
                return 0;
        }

        #region POOLING SYSTEM

        public List<GameObject> bulletPool = new List<GameObject>();
        public List<GameObject> enemyPool = new List<GameObject>();

        //Quita los objetos de la lista de objetos del mundo, se ejecuta en el ondraw al final
        public void PoolObjects()
        {
            foreach (GameObject go in bulletPool)
            {
                this.WorldObjects.Remove(go);
            }
            foreach (GameObject go in enemyPool)
            {
                this.WorldObjects.Remove(go);
            }
        }

        //Añade un objeto a la cola de pool
        public void Destroy(GameObject obj, List<GameObject> pool)
        {
            obj.SetActive(false);
            pool.Add(obj);
        }

        //Saca un objeto de una pool. Si no hay, instancia uno nuevo
        public void Instantiate(Vector2 position, List<GameObject> pool, IAssetManager manager)
        {
            if (pool.Count > 0)
            {
                pool[0].SetActive(true);
                GameObject.Instantiate(pool[0], position);
                pool.Remove(pool[0]);
            }
            else
            {
                if (pool == bulletPool)
                    GameObject.Instantiate(Bullet.Prefab(Tag.DEFAULT), position);
                else
                {
                    if((int)Utils.RandomRange(1f, 2.99f) == 1)
                        GameObject.Instantiate(EnemyMad.Prefab(manager), position);
                    else
                        GameObject.Instantiate(Enemy.Prefab(manager), position);
                }
                    
            }
        }
        #endregion 

        #region BEHAVIOR
        public void InputBehavior(IKeyboard kb, IAssetManager manager, World world)
        {
            foreach (GameObject go in WorldObjects)
            {
                go.Behavior(kb, manager, world);
            }
        }

        public void OnDrawBehavior(ICanvas canvas, IAssetManager manager, World world)
        {
            noiseTime += Time.deltaTime;
            foreach (GameObject go in WorldObjects)
            {
                go.Behavior(canvas, manager, world);
            }
        }
        #endregion
    }
}
