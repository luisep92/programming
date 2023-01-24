using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public delegate int Comparator<T>(T value1, T value2); //value1 > value2 -> 1 / == -> 2 / < -> -1
    internal class GenericArray<T> : IEnumerable
    {
        T[] _array;
        public int Length => _array.Length;

        public T this[int index]
        {
            get => _array[index];    
        }
        public GenericArray(int size)
        {
            _array = new T[size];
        }
        public GenericArray()
        {
            _array = new T[0];
        }
        public T GetItem(int index)
        {
            return _array[index];
        }
        public void SetItem(int index, T value)
        {
            _array[index] = value;
        }
        public bool Exist(T value)
        {
            return IndexOf(value) != -1;
        }
        public int IndexOf(T value)
        {
            for(int i = 0; i < _array.Length; i++)
            {
                T item = GetItem(i);
                if (item == null)
                    continue;
                if(item.Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Flip(int max)
        {
            for (int i = 0; i < max >> 1; i++)
            {
                T tmp = _array[i];
                _array[i] = _array[max - i - 1];
                _array[max - i - 1] = tmp;
            }
        }
        public void Sort(Comparator<T> orderer)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                for(int j = i + 1; j < _array.Length; j++)
                {
                    if (orderer(_array[i], _array[j]) == 1)
                        Swap(ref _array[i], ref _array[j]);
                }
            }
        }
        public int BinarySearch(T item, Comparator<T> comparator)
        {
            int indexMin = 0;
            int indexMax = _array.Length - 1;

            while (indexMin <= indexMax)
            {
                int indexMid = (indexMax + indexMin) / 2;
                if (comparator(_array[indexMid],item) == 0)
                    return indexMid;
                else if (comparator(_array[indexMid], item) == -1)
                    indexMin = indexMid + 1;
                else
                    indexMax = indexMid - 1;
            }
            return -1;
        }
        public void RotateLeft(int displacement)
        {
            Flip(displacement);
            Flip(_array.Length);
            Flip(displacement);
        }
        public void RotateRight(int displacement)
        {
            Flip(_array.Length - displacement);
            Flip(_array.Length);
            Flip(displacement);
        }
        public void RotateLeft()
        {
            if (_array.Length < 2)
                return;
            T aux = _array[0];
            for(int i = 0; i < _array.Length - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _array[^1] = aux;
        }
        public void RotateRight()
        {
            if (_array.Length < 2)
                return;
            T aux = _array[^1];
            for (int i = _array.Length - 1; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = aux;
        }
        public void Add(T value)
        {
            T[] values = new T[_array.Length + 1];
            for(int i = 0; i < _array.Length; i++)
            {
                values[i] = _array[i];
            }
            values[^1] = value;
            _array = values;
        }
        public void Remove(T value)
        {
            int indexAt = IndexOf(value);
            if (indexAt == -1)
                return;
            T[] values = new T[_array.Length - 1];
            for(int i = 0; i < values.Length; i++)
            {
                if (i < indexAt)
                    values[i] = _array[i];
                else
                    values[i] = _array[i + 1];
            }
            _array = values;
        }
        public void RemoveAll(T value)
        {
            int indexAt = IndexOf(value);
            if (indexAt == -1)
                return;
            T[] values = new T[_array.Length - 1];
            for (int i = 0; i < values.Length; i++)
            {
                if (i < indexAt)
                    values[i] = _array[i];
                else
                    values[i] = _array[i + 1];
            }
            _array = values;
            RemoveAll(value);
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _array.Length)
                return;
            T[] values = new T[_array.Length - 1];
            for (int i = 0; i < values.Length; i++)
            {
                if (i < index)
                    values[i] = _array[i];
                else
                    values[i] = _array[i + 1];
            }
            _array = values;
        }

        void Swap(ref T value1, ref T value2)
        {
            T aux = value1;
            value1 = value2;
            value2 = aux;
        }
        public override string ToString()
        {
            string res = "[";
            T item;
            for (int i = 0; i < _array.Length - 1; i++)
            {
                item = _array[i];
                if (item == null)
                    res += "null, ";
                else
                    res += item.ToString() + ", ";
            }
            item = _array[^1];

            if (item == null)
                res += "null]";
            else
                res += item.ToString() + "]";
            return res;
        }
        public IEnumerator GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}
