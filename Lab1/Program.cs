//Требуется найти количество неотрицательных элементов массива К(25).
//Массив задается в коде. Задача реализуется в отдельном методе.

using System;

namespace Lab1
{
    class Program
    {
        private static void FindingNonNegativeNumbers(int[] arr)
        {
            Console.Write("Неотрицательные числа: ");
            foreach (int i in arr)
            {
                if (i > 0)
                {
                    Console.Write(i + " ");
                }
            }

        }

        static void Main()
        {
            int[] K = new int[25];
            Random rnd = new Random();
            for (int i = 0; i < K.Length; i++)
            {
                K[i] = rnd.Next(-50, 50);
            }
            Console.Write("Массив: ");
            foreach (int i in K) 
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            FindingNonNegativeNumbers(K);
        }

    }
}
