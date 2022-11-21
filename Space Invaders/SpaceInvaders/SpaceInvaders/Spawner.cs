using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Spawner
    {
        static float time = 2;
        static float timeToSpawn = 5f;
        public static void SpawnEnemies(IAssetManager manager)
        {
            time += Time.deltaTime;
            if(time >= timeToSpawn)
            {
                for (int i = (int)World.X.Min() + 3; i <= World.X.Max() - 3; i += 3)
                {
                    GameObject.Instantiate(Enemy.Prefab(manager), new Vector2(i, World.Y.Max() - 2));
                }
                time = 0;
            }
                
        }
    }
}
