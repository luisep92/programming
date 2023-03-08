using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace Exercises
{
    internal class Program
    {
        static int[] asd = { 1, 2, 3 ,4 ,5, 6, 7, 8, 9, 10, 11, 12};
        static int[] assd = { 1, 2};
        
        //Tuve que poner "orderer" fuera de la clase porque sino no lo podia declarar 
        static void Main(string[] args)
        {
            #region SORT
            GenericArray<int> arr = new GenericArray<int>(6);

             arr.SetItem(0, 1);
             arr.SetItem(1, 35);
             arr.SetItem(2, 10);
             arr.SetItem(3, 4);
             arr.SetItem(4, 5);
             arr.SetItem(5, 6);

            GenericArray<Vector3> arr2 = new GenericArray<Vector3>(4);

            arr2.SetItem(0, new Vector3(32, 0, 23));
            arr2.SetItem(1, new Vector3(22, 0, 23));
            arr2.SetItem(2, new Vector3(78, 0, 23));
            arr2.SetItem(3, new Vector3(10, 0, 23));

            Comparator<int> ord = (int a, int b) =>
            {
                if (a > b) return 1;
                if (a == b) return 0;
                    return -1;
            };
            Comparator<string> ordStr = (string a, string b) =>
            {
                if (a.Length > b.Length) return 1;
                if (a == b) return 0;
                return -1;
            };
            Comparator<Vector3> ord2 = (Vector3 a, Vector3 b) =>
            {
                if (a.x > b.x) return 1;
                if (a.x == b.x) return 0;
                return -1;
            };
            
            Console.WriteLine(arr.IndexOf(325).ToString());
            #endregion
            #region BINARYSEARCH
             GenericArray<int> arr3 = new GenericArray<int>(6);

             arr3.SetItem(0, 1);
             arr3.SetItem(1, 2);
             arr3.SetItem(2, 3);
             arr3.SetItem(3, 4);
             arr3.SetItem(4, 5);
             arr3.SetItem(5, 6);

             Comparator<int> ord3 = (int a, int b) =>
             {
                 if (a > b) return 1;
                 if (a == b) return 0;
                 return -1;
             };

             Console.WriteLine(arr.BinarySearch(5, ord3));
            #endregion
            /* GenericArray<string> ads = new GenericArray<string>() { "3", "2", "3" , "4"};
             string asd = "asd";
             asd += null;
             foreach(string st in ads)
             {
                 Console.WriteLine("a");
             }*/
            funcion(20,6);
        }
        static void funcion(int a, int h)
        {
            int j = 2;
            int s = 0;
            int n;
            n = Int32.Parse(Console.ReadLine());
            while (j <= n / 2)
            {
                if (n % j == 0)
                    s = s + 1;
                j = j + 1;
            }
               
            if (s == 0)
                Console.Write(n + "es primo");
            else
                Console.Write(n + "no es primo");
        }

    }
}