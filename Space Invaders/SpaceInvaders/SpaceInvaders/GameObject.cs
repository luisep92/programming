using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class GameObject
    {
        public Transform transform;
        List<Component> components = new List<Component>();
        public GameObject(Transform transform)
        {
            this.transform = transform;
        }

        public Component GetComponent<T>()
        {
            foreach (Component c in components)
            {
                var type = c.GetType();
                Console.WriteLine(type);
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
