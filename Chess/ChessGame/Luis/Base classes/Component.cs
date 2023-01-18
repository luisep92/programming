using DAM;

namespace Luis
{
    internal class Component
    {
        public GameObject gameObject;
        public bool isEnabled = true;

        public virtual void Behavior(ICanvas canvas, IAtomicDecoder manager, Scene world)
        {
        }
        public virtual void Inputs(IKeyboard keyboard, IAtomicDecoder manager, Scene world)
        {
        }

        public void DoBehavior(ICanvas canvas, IAtomicDecoder manager, Scene world)
        {
            if (this.isEnabled)
            {
                Behavior(canvas, manager, world);
            }
        }
        public void DoInput(IKeyboard keyboard, IAtomicDecoder manager, Scene world)
        {
            if (this.isEnabled)
            {
                Inputs(keyboard, manager, world);
            }
        }

        public virtual void OnCollision(GameObject gameObject, IAtomicDecoder manager, Scene world)
        {

        }
    }
}
