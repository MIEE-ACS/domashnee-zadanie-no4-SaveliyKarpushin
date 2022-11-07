/*Двумерные массивы
Для заданной матрицы размером 8x8 найти такие k, при которых k-я строка матрицы совпадает с k-м столбцом.
Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 8;                   
            int[,] mas = new int[N, N];        
            int[] masi = new int[N];
            int[] masj = new int[N];
            int count = 0, ind = 0;

            Random r = new Random();

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    mas[i, j] = r.Next(-1, 1);   

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(mas[i, j] + "\t");
                Console.WriteLine();
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    masi[j] = mas[i, j];

                for (int m = 0; m < N; m++)
                {
                    for (int n = 0; n < N; n++)
                    {
                        if (masi[n] == mas[n, m])
                        {
                            count++;
                            ind = m;
                        }
                        else
                        {
                            count = 0;
                            break;
                        }
                    }

                    if (count == N && i == ind)
                    {
                        Console.WriteLine("\nk: " + (i + 1));
                    }
                }
            }

            
            
            // Сумма элементов в строках с отр. элементом(ми)
           

            int sum = 0;
            bool check = false;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sum += mas[i, j];
                    if (mas[i, j] < 0) check = true;
                }
                if (check)
                {
                    Console.WriteLine("Сумма (" + i + "): " + sum);
                    check = false;
                }
                sum = 0;
            }

        }
    }
}
