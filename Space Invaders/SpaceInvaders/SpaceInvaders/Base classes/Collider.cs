using DAM;
using Luis;

namespace SpaceInvaders.Base_classes
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

        public override void Behavior(ICanvas canvas)
        {
            DetectCollision();
        }

        public void DetectCollision()
        {
            GameObject go = Collision.GetObjectCollisioning(thisTransform, World.WorldObjects);
            if (go != null)
            {
                comp.OnCollision(go);
            }
        }
    }
}
