using DAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Component
    {
        public GameObject gameObject;
        public bool isEnabled = true;

        public virtual void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
        }
        public virtual void Inputs(IKeyboard keyboard, IAssetManager manager, World world)
        {
        }

        public void DoBehavior(ICanvas canvas,IAssetManager manager, World world)
        {
            if (this.isEnabled)
            {
                Behavior(canvas, manager, world);
            }
        }
        public void DoInput(IKeyboard keyboard, IAssetManager manager, World world)
        {
            if (this.isEnabled)
            {
                Inputs(keyboard, manager, world);
            }
        }

        public virtual void OnCollision(GameObject gameObject,IAssetManager manager, World world)
        {

        }
    }
}
