using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;

namespace Exercises
{
    internal class Program
    {
        static int[] asd = { 1, 2, 3 ,4 ,5, 6, 7, 8, 9, 10, 11};
        static void Main(string[] args)
        {
            RotateLeft(asd, 3);
            string au = "";
            for(int i = 0; i < asd.Length; i++)
            {
                au += asd[i] + ", ";
            }
            Console.WriteLine(au);
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
        
        public static void RotateLeft2(int[] arr, int disp)
        {
        }
    }
}