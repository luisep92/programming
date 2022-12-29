using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exercises
{
    internal class Program
    {
        static int[] asd = { 1, 2, 3 ,4 ,5, 6, 7, 8, 9, 10, 11, 12};
        static int[] assd = { 1, 2};
        static void Main(string[] args)
        {
            RotateLeft3(asd, 3);

            string fin = "";
            for(int i = 0; i < asd.Length; i++)
            {
                fin += asd[i] + ", ";
            }
            Console.WriteLine(fin);
        }
        public static int Circular(int n, int min, int max)
        {
            int range = max - min;

            if (n > max)
                return Circular(n - range, min, max);
            if (n < min)
                return Circular(n + range, min, max);
            return n;
        }

        public static void RotateLeft(int[] arr, int disp)
        {
            int aux;
            
            for(int i = 0; i < arr.Length - disp; i++)
            {
                int pos = Circular( arr.Length - disp + i, -1, arr.Length - 1);
                aux = arr[pos];
                arr[pos] = arr[i];
                arr[i] = aux;
            }
            if(arr.Length % 2 != 0)
            {
                aux = arr[arr.Length - disp - 1];
                arr[arr.Length - disp - 1] = arr[arr.Length - disp - 2];
                arr[arr.Length - disp - 2] = aux;
            }
        }
       
        public static void Flip(int[] arr, int max)
        {
            for (int i = 0; i < max >> 1; i++)
            {
                int tmp = arr[i];
                arr[i] = arr[max - i - 1];
                arr[max - i - 1] = tmp;
            }
        }
        public static void RotateLeft3(int[] arr, int disp)
        {
           Flip(arr, disp );
           Flip(arr, arr.Length);
           Flip(arr, arr.Length - disp);
        }


        public static bool Exists<T>(T[] array, T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                    return true;
            }
            return false;
        }
    }
}