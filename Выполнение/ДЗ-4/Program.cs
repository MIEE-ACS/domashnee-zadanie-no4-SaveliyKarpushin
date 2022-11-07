/*Вариант 7 Карпушин УТС-21
   Одномерные массивы
В одномерном массиве, состоящем из n-целочисленных элементов, вычислить:
• номер максимального элемента массива;
• произведение элементов массива, расположенных между первым и вторым нулевыми элементами.
Преобразовать массив таким образом, чтобы в первой его половине располагались элементы, стоявшие в нечетных позициях, а во второй половине — элементы, стоявшие в четных позициях.
 */
   
using System;
using System.Collections.Generic;
using System.Linq;

namespace ДЗ_4
{

    class Function
    {
        //функция печати массива на экран
       
        public static void PrintArray(int[] a)
        {
            foreach (int i in a) Console.Write(i + "  ");
            Console.WriteLine();
        }
       

        //функция поиска максимального элемента в массиве
        public int IndexOfMaxElement(int[] a, int size)
        {
            int max = a[0];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                    index = i;
                }
            }
            return index;
        }
       

        //функция поиска индексов левого и правого нулей
        public void ZeroIndex(int[] a, int size, out int leftIndex, out int rightIndex)
        {
            leftIndex = rightIndex = 0;
            //в данном цикле находится индекс самого левого нуля
            for (int i = 0; i < size; i++)
            {
                if (a[i] == 0)
                {
                    leftIndex = i;
                    break;
                }
            }
          
            //в данном цикле находится индекс самого правого нуля
            for (int i = size - 1; i >= 0; i--)
            {
                if (a[i] == 0)
                {
                    rightIndex = i;
                    break;
                }
            }
           
        }
       

        //функция находит произведение элементов между крайними нулями
        public int Proizvedenie(int[] a, int leftIndex, int rightIndex)
        {
            int proiz = 1;
            for (int i = leftIndex + 1; i < rightIndex; i++) proiz *= a[i];
            return proiz;
        }
       

        //функция перестановки элементов в массиве
        public void Exchange(int[] a, int size)
        {
            int temp; //для обмена значений
            for (int i = 0, j = 1; i < size / 2; i++, j += 2)
            {
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }
        }
        
    }

    class MainClass
    {
        static void Main()
        {
            int[] array;
            int n = int.Parse(Console.ReadLine());
            array = new int[n];
            Random r = new Random();
            for(int i = 0; i < n; i++)
            {
                array [i] = r.Next(-100, 100); 
            }

         Function function = new Function();
            int leftIndex, rightIndex;
            Console.WriteLine("Исходный массив:" + Environment.NewLine);
            Function.PrintArray(array);
            Console.WriteLine();

            Console.Write("Индекс максимального элемента в массиве: " +
            function.IndexOfMaxElement(array, n) +Environment.NewLine);
            function.ZeroIndex(array, n, out leftIndex, out rightIndex);
            Console.WriteLine("Произведение элементов, находящихся между крайними нулями: " +
            function.Proizvedenie(array, leftIndex, rightIndex) + Environment.NewLine);

            Console.WriteLine("Массив после перестановки элементов: " + Environment.NewLine);
            function.Exchange(array, n);
            Function.PrintArray(array);

            Console.ReadKey();
        }
    }

}
