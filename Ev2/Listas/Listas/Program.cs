namespace Listas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(-100);
            list.Add(-20);
            list.Add(-1);
            list.Add(20);
            list.Add(50);

            Console.WriteLine(BinarySearch(list, 50));
        }

        public static int GetMajor(List<int> li)
        {
            if (li == null)
                return int.MinValue;
            if(li.Count == 0)
                return int.MinValue;

            int max = int.MinValue;
            foreach (int i in li)
            {
                if (i > max)
                    max = i;
            }
            return max;
        }

        public static int IndexOf(List<int> list, int n)
        {
            if (list == null)
                return -1;
            if (list.Count == 0)
                return -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == n)
                    return i;
            }
            return -1;
        }
        public static bool Exists(List<int> list, int n)
        {
            return IndexOf(list, n) >= 0;
        }

        public static void Sort(List<int> list)
        {
            int aux = 0;
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = 0; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        aux = list[j];
                        list[j] = list[i];
                        list[i] = aux;
                    }
                }
            }
        }
        public static void Sort2(List<int> list)
        {
            int aux = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] > list[j])
                    {
                        aux = list[j];
                        list[j] = list[i];
                        list[i] = aux;
                    }
                }
            }
        }

        public static int BinarySearch(List<int> list, int n)
        {
            int indexMin = 0;
            int indexMax = list.Count - 1;

            while(indexMin <= indexMax)
            {
                int indexMid = (indexMax + indexMin) / 2;
                if (list[indexMid] == n)
                    return indexMid;
                else if (list[indexMid] < n)
                    indexMin = indexMid + 1;
                else 
                    indexMax = indexMid - 1;
            }
            return -1;
        }
    }
}