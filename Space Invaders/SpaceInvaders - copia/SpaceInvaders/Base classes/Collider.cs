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

        public override void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            DetectCollision(manager, world);
        }

        public void DetectCollision(IAssetManager manager, World world)
        {
            GameObject go = Collision.GetObjectCollisioning(thisTransform, world.WorldObjects);
            if (go != null)
            {
                comp.OnCollision(go, manager, world);
            }
        }
    }
}
