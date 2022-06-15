using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW22
{
    class Program
    {
        //Сформировать массив случайных целых чисел
        //(размер  задается пользователем).
        //Вычислить сумму чисел массива и максимальное число в массиве.
        //Реализовать  решение  задачи
        //с использованием  механизма  задач продолжения.
        static void Main(string[] args)
        {
            Console.WriteLine("введите длину массива");
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);

            Func<Task<int[]>, int[]> func2 = new Func<Task<int[]>, int[]>(SummArray);
            Task<int[]> task2 = task1.ContinueWith<int[]>(func2);

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintArray);
            Task task3 = task2.ContinueWith(action);


            task1.Start();
            Console.ReadKey();
        }

        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }

        static int[] SummArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Count() - 1; i++)
            {
                int S = 0;
                S += array.Count();

            }
            return array;
            
        }
        static int [] MaxArray(Task<int[]> task)
        {
            int[] array = task.Result;
            foreach (int a in array)
            {
                int max = 0;
                if (a > max)
                    max = a;
            }
            return array;
        }

        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Count(); i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

    }
}
