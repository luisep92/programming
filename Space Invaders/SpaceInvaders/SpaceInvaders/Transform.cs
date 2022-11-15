using Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Transform
    {
        public Vector2 position;
        public Vector2 size;
        public Transform parent;

        #region CONSTRUCTOR
        public Transform(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }
        #endregion
    }
}
