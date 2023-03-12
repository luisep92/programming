using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Set<T>
    {
        public List<T> collection = new List<T> ();
        public void Add(T value, Comparator<T> c)
        {
            if(collection.Count == 0)
            {
                collection.Add (value);
                return;
            }
            
            // Javi: Mal, usar GetIndexOf, ..., aparte, ..., no sé qué estás haciendo aquí
            for (int i = 0; i < collection.Count; i++)
            {
                if (c(collection[i], value) == 1)
                {
                    collection.Insert(i-1, value);
                }
            }
        }

        public void Remove(T value, Comparator<T> c)
        {
            int index = GetIndexOf(value, c);

            if(index >= 0)
                collection.RemoveAt(index);
        }

        public bool Contains(T value, Comparator<T> c) 
        {
            return GetIndexOf(value, c) >= 0;
        }

        public int GetIndexOf(T value, Comparator<T> c)
        {
            for(int i = 0; i < collection.Count; i++)
            {
                if (c(value, collection[i]) == 0)
                    return i;
            }
            return -1;
        }

       /* int BinarySearch(T value, Comparator<T> c)
        {
            int min = 0, max = collection.Count - 1;

            while(min < max)
            {
                int mid = (min + max) >> 1;
            }
        }*/
    }
}
