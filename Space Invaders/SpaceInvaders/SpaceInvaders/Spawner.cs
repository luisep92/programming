using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class Spawner
    {
        static float timePowerUpSpawn = 0f;
        static float timeEnemySpawn = 2f;
        static float nextPowerUp = Utils.RandomRange(7f, 14f);
        public static void SpawnObjects(IAssetManager manager, World world)
        {
            timeEnemySpawn += Time.deltaTime;
            if(timeEnemySpawn >= 4f)
            {
                for (float i = (int)world.X.Min() + 2; i <= world.X.Max() - 2; i += (world.Dimensions().x - 4)/(int)Utils.RandomRange(1f, 4f))
                {
                    Vector2 spawnPos = new Vector2(i, world.Y.Max() - 2);
                    world.Instantiate(spawnPos, world.enemyPool, manager);
                }
                timeEnemySpawn = 0;
            }

            timePowerUpSpawn += Time.deltaTime;
            if(timePowerUpSpawn >= nextPowerUp)
            {
                Vector2 pos = new Vector2(Utils.RandomRange(world.X.Min() + 3, world.X.Max() - 3), world.Y.Max() - 2);
                GameObject.Instantiate(PowerUp.SpeedPrefab(), pos);
                timePowerUpSpawn = 0;
                nextPowerUp = Utils.RandomRange(5f, 14f);
            }
        }
    }
}
