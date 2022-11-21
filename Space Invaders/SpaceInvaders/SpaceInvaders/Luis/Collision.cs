﻿using SpaceInvaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis
{
    internal class Collision
    {
        public static bool SquareCollision(Vector2 pos1, Vector2 size1, Vector2 pos2, Vector2 size2)
        {
            if(pos2.x > pos1.x + size1.x) 
                return false;
            if (pos2.y > pos1.y + size1.y)
                return false;
            if (pos2.y + size2.y < pos1.y)
                return false;
            if (pos2.x + size2.x < pos1.x)
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