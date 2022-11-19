using DAM;
using Luis;

namespace SpaceInvaders
{
    internal class GameObject
    {
        public Transform transform = new Transform();
        public List<Component> components = new List<Component>();
        bool isActive = true;
        
        public GameObject(Transform transform)
        {
            this.transform = transform;
        }
        public GameObject()
        {

        }
        public void SetActive (bool active)
        { 
            isActive = active;
        }
        public void Behavior(ICanvas canvas)
        {
            if (this.isActive)
            {
                foreach (Component c in components)
                {
                    c.DoBehavior(canvas);
                }
            }
        }
        public void Behavior(IKeyboard keyboard)
        {
            if (this.isActive)
            {
                foreach (Component c in components)
                {
                    c.DoInput(keyboard);
                }
            }
        }
        public Component GetComponent<T>()
        {
            foreach (Component c in components)
            {
                var type = c.GetType();
                if(type == typeof(T))
                    return c;

            }
            return null;
        }

        public void AddComponent(Component c)
        {
            components.Add(c);
        }

        public void RemoveComponent<T>()
        {
            foreach (Component c in components)
            {
                var type = c.GetType();
                if (type == typeof(T))
                    components.Remove(c);
            }
        }
    }
}
