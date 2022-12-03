﻿using DAM;
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
        #region BEHAVIOR
        //Comportamiento en OnDraw
        public void Behavior(ICanvas canvas, IAssetManager manager, World world)
        {
            if (this.isActive)
            {
                foreach (Component c in components)
                {
                    c.DoBehavior(canvas, manager, world);
                }
            }
        }
        //Comportamiento en OnKeyboard
        public void Behavior(IKeyboard keyboard, IAssetManager manager, World world)
        {
            if (this.isActive)
            {
                foreach (Component c in components)
                {
                    c.DoInput(keyboard, manager, world);
                }
            }
        }
        #endregion

        public static GameObject Instantiate(GameObject go, Vector2 position)
        {
            toInstance.Add(go);
            go.transform.position.x = position.x;
            go.transform.position.y = position.y;
            return go;
        }
        public static void Destroy(GameObject gameObject,World world)
        {
            foreach(GameObject go in world.WorldObjects)
            {
                if(go == gameObject)
                    toDestroy.Add(go);
            }
        }
        public static void InstanceAndDestroyObjects(World world)
        {
            InstanceObjects(world);
            DestroyObjects(world);
        }
        static void InstanceObjects(World world)
        {
            foreach(GameObject go in toInstance)
                world.WorldObjects.Add(go);
            toInstance.Clear();
        }
        static void DestroyObjects(World world)
        {
            foreach (GameObject go in toDestroy)
            {
                go.components.Clear();
                world.WorldObjects.Remove(go);
            }
            toDestroy.Clear();
        }

        #region COMPONENTS
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

        public static T FindObjectsOfType<T>(World world)
        {
            foreach(GameObject go in world.WorldObjects)
            {
                if (go.GetComponent<T>() != null)
                    return go.GetComponent<T>();
            }
            return default;
        }
        #endregion
    }
}
