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

        public virtual void Behavior(ICanvas canvas)
        {
        }
        public virtual void Inputs(IKeyboard keyboard)
        {
        }

        public void DoBehavior(ICanvas canvas)
        {
            if (this.isEnabled)
            {
                Behavior(canvas);
            }
        }
        public void DoInput(IKeyboard keyboard)
        {
            if (this.isEnabled)
            {
                Inputs(keyboard);
            }
        }

        public virtual void OnCollision(GameObject gameObject)
        {

        }
    }
}
