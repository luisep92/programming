using UDK;

namespace Luisbreria
{
    internal class Collider : Component
    {
        Component comp;
        Transform thisTransform;
        public Collider(Component comp, GameObject parent)
        {
            this.comp = comp;
            gameObject = parent;
            gameObject.AddComponent(this);
            thisTransform = gameObject.transform;
        }

        public override void Behavior(ICanvas canvas, IAtomicDecoder manager, Scene world)
        {
            DetectCollision(manager, world);
        }

        public void DetectCollision(IAtomicDecoder manager, Scene world)
        {
            GameObject go = Collision.GetObjectCollisioning(thisTransform, world.WorldObjects);
            if (go != null)
            {
                comp.OnCollision(go, manager, world);
            }
        }
    }
}
