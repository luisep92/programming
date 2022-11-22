using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Spawner
    {
        static float time = 3f;
        static float timeToSpawn = 5f;
        public static void SpawnEnemies(IAssetManager manager, World world)
        {
            time += Time.deltaTime;
            if(time >= timeToSpawn)
            {
                for (int i = (int)world.X.Min() + 3; i <= world.X.Max() - 3; i += 3)
                {
                    Vector2 spawnPos = new Vector2(i, world.Y.Max() - 2);
                    world.Instantiate(spawnPos, world.enemyPool, manager);
                }
                time = 0;
            }
        }
    }
}
