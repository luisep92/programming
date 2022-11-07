using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace El_raton_y_el_gato
{
    internal class GameObject
    {
        public string name;
        public Transform transform = new Transform();
        public List<Component> components = new List<Component>();

        public void AddComponent(Component component)
        {
            components.Add(component);
        }
        public void RemoveComponent(System.Type component)
        {
            foreach(Component c in components)
            {
                if( c.GetType() == component.GetType())
                {
                    components.Remove(c);
                }
            }
        }
        public Component GetComponent(System.Type type)
        {
            foreach (Component c in components)
            {
                if (c.GetType() == type)
                {
                    return c;
                }
            }
            Console.WriteLine("GetComponent Null [" + components.Count + "]");
            return null;
        }

    }
}
