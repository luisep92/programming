using DAM;
using Luis;

namespace SpaceInvaders
{
    public enum Tag { DEFAULT, PLAYER, ENEMY }
    internal class GameObject
    {
        public Transform transform = new Transform();
        public List<Component> components = new List<Component>();
        public Tag tag = Tag.DEFAULT;
        bool isActive = true;
        
        static List<GameObject> toInstance = new List<GameObject>();
        static List<GameObject> toDestroy = new List<GameObject>();

        #region CONSTRUCTOR
        public GameObject(Transform transform)
        {
            this.transform = transform;
        }
        public GameObject()
        {

        }
        #endregion

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
        public static GameObject Instantiate(GameObject go, Vector2 position)
        {
            toInstance.Add(go);
            go.transform.position.x = position.x;
            go.transform.position.y = position.y;
            return go;
        }
        public static void Destroy(GameObject gameObject)
        {
            foreach(GameObject go in World.WorldObjects)
            {
                if(go == gameObject)
                    toDestroy.Add(go);
            }
        }
        public static void InstanceAndDestroyObjects()
        {
            InstanceObjects();
            DestroyObjects();
        }
        static void InstanceObjects()   //COMENTAR, tuve que hacerlo porque no puedo modificar una lista mientras la itero
        {
            foreach(GameObject go in toInstance)
                World.WorldObjects.Add(go);
            toInstance.Clear();
        }
        static void DestroyObjects()
        {
            foreach (GameObject go in toDestroy)
                World.WorldObjects.Remove(go);
            toDestroy.Clear();
        }
        /*  public Component GetComponent<T>()    COMENTAR A JAVI - lo tuve que cambiar para que devolviese el tipo del que es, no un COMPONENT
          {
              foreach (Component c in components)
              {
                  var type = c.GetType();
                  if(type == typeof(T))
                      return c;

              }
              return null;
          }*/
        public T GetComponent<T>()
        {
            foreach (Component c in components)
            {
                if (c.GetType() == typeof(T))
                {
                    return (T)Convert.ChangeType(c, typeof(T));
                }
            }
            return default;
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
        public void RemoveComponent(Component comp)
        {
            foreach (Component c in components)
            {
                if(c == comp)
                    components.Remove(comp);
            }
        }
    }
}
