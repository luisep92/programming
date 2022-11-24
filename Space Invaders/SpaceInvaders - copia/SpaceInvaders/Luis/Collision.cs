using SpaceInvaders;

namespace Luis
{
    internal class Collision
    {
        public static bool SquareCollision(Vector2 pos1, Vector2 size1, Vector2 pos2, Vector2 size2)
        {
            float posi1x = pos1.x - size1.x / 2; 
            float posi1y = pos1.y - size1.y / 2;
            float posi2x = pos2.x - size2.x / 2;
            float posi2y = pos2.y - size2.y / 2;

            if(posi1x > posi2x + size2.x) 
                return false;
            if (posi1y > posi2y + size2.y)
                return false;
            if (posi1y + size1.y < posi2y)
                return false;
            if (posi1x + size1.x < posi2x)
                return false;
            return true;
        }

        public static GameObject GetObjectCollisioning(Transform obj, List<GameObject> objects)
        {
            foreach (GameObject go in objects)
            {
                if(obj != go.transform)
                {
                    if (SquareCollision(obj.position, obj.size, go.transform.position, go.transform.size))
                        return go;
                }
            }
            return null;
        }
    }
}
