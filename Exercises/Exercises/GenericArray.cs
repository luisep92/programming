using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    internal class GenericArray<T>
    {
        T[] array;
        public int Length => array.Length;

        public T this[int index]
        {
            get => array[index];    
        }

        public GenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T GetItem(int index)
        {
            return array[index];
        }
        public void SetItem(int index, T value)
        {
            array[index] = value;
        }
        public bool Exist(T value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(GetItem(i).Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        
    }

    public class Pruebas
    {
        GenericArray<Object> arr = new GenericArray<Object>(3);

        Vector3 vec = new Vector3(2, 2, 2);
        GenericArray<int> intArr = new GenericArray<int>(5);

        public void DoSmt()
        {
            arr.SetItem(0, null);
            arr.SetItem(1, vec);
            arr.SetItem(2, "asdad");
            arr.SetItem(3, 6);
            arr.SetItem(4, 6);

            for (int i = 0; i < arr.Length; i++)
            {
                Object item = arr.GetItem(i);
                if(item != null)
                {
                    Console.WriteLine(arr.GetItem(i).GetType());
                }
                else
                {
                    Console.WriteLine("Null");
                }
                
            }

        }

    }
}
