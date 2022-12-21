
namespace Prueba_OpenAL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[5];
            array1[0] = 1;
            array1[1] = 2;
            array1[2] = 3;
            array1[3] = 4;
            array1[4] = 5;

            int[] array2 = { 1, 2, 63, 54, 70 };


            //Imprime por consola lo que tiene el array
            for(int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }
        }
        void Cosas(int[] array)
        {
            //lo que sea
        }
    }
}