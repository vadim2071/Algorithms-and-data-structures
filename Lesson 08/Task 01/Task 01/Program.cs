using System;
using System.Collections.Generic;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] SortArr = new int[100]; //массив для сортировки
            Random rand = new Random();
            int size = 100; //размер массива для сортировки
            int max = 100; //максимальный число в массиве для сортировки


            for (int i = 0; i < size; i++) //генерация чисел для заполнения массива
            {
                SortArr[i] = rand.Next(max);
                Console.WriteLine(SortArr[i]);
            }

            SortArr = BucketSort(SortArr); //сортируме массив

            Console.WriteLine("Отсортированный массив");
            for (int i = 0; i < size; i++) //вывод массива в консоль
            {
                Console.WriteLine(SortArr[i]);
            }


            static int[] BucketSort(int[] array)
            {
                int size = array.Length;
                //списки для хранения блоков сортировки
                List<int> arr_0_10 = new List<int>();
                List<int> arr_11_20 = new List<int>();
                List<int> arr_21_30 = new List<int>();
                List<int> arr_31_40 = new List<int>();
                List<int> arr_41_50 = new List<int>();
                List<int> arr_51_60 = new List<int>();
                List<int> arr_61_70 = new List<int>();
                List<int> arr_71_80 = new List<int>();
                List<int> arr_81_90 = new List<int>();
                List<int> arr_91_100 = new List<int>();

                //распределяем содержимое массива для сортироваки по блокам
                for (int i = 0; i < size; i++)
                {
                    if (array[i] >= 0 & array[i] <= 10) arr_0_10.Add(array[i]);
                    else if (array[i] > 10 & array[i] <= 20) arr_11_20.Add(array[i]);
                    else if (array[i] > 20 & array[i] <= 30) arr_21_30.Add(array[i]);
                    else if (array[i] > 30 & array[i] <= 40) arr_31_40.Add(array[i]);
                    else if (array[i] > 40 & array[i] <= 50) arr_41_50.Add(array[i]);
                    else if (array[i] > 50 & array[i] <= 60) arr_51_60.Add(array[i]);
                    else if (array[i] > 60 & array[i] <= 70) arr_61_70.Add(array[i]);
                    else if (array[i] > 70 & array[i] <= 80) arr_71_80.Add(array[i]);
                    else if (array[i] > 80 & array[i] <= 90) arr_81_90.Add(array[i]);
                    else if (array[i] > 90 & array[i] <= 100) arr_91_100.Add(array[i]);
                }

                //сортировка
                QuickSort(arr_0_10, 0, arr_0_10.Count - 1);
                QuickSort(arr_11_20, 0, arr_11_20.Count - 1);
                QuickSort(arr_21_30, 0, arr_21_30.Count - 1);
                QuickSort(arr_31_40, 0, arr_31_40.Count - 1);
                QuickSort(arr_41_50, 0, arr_41_50.Count - 1);
                QuickSort(arr_51_60, 0, arr_51_60.Count - 1);
                QuickSort(arr_61_70, 0, arr_61_70.Count - 1);
                QuickSort(arr_71_80, 0, arr_71_80.Count - 1);
                QuickSort(arr_81_90, 0, arr_81_90.Count - 1);
                QuickSort(arr_91_100, 0, arr_91_100.Count - 1);


                //собирам обратно отсортированный массив
                int num = 0;
                arr_0_10.CopyTo(array, num);
                num = num + arr_0_10.Count;
                arr_11_20.CopyTo(array, num);
                num = num + arr_11_20.Count;
                arr_21_30.CopyTo(array, num);
                num = num + arr_21_30.Count;
                arr_31_40.CopyTo(array, num);
                num = num + arr_31_40.Count;
                arr_41_50.CopyTo(array, num);
                num = num + arr_41_50.Count;
                arr_51_60.CopyTo(array, num);
                num = num + arr_51_60.Count;
                arr_61_70.CopyTo(array, num);
                num = num + arr_61_70.Count;
                arr_71_80.CopyTo(array, num);
                num = num + arr_71_80.Count;
                arr_81_90.CopyTo(array, num);
                num = num + arr_81_90.Count;
                arr_91_100.CopyTo(array, num);
                return array;
            }

     

            static void QuickSort(List<int> list, int first, int last)
            {
                if (list.Count == 0) return;
                int i = first, j = last, x = list[(first + last) / 2];

                do
                {
                    while (list[i] < x)
                        i++;
                    while (list[j] > x)
                        j--;

                    if (i <= j)
                    {
                        if (list[i] > list[j])
                        {
                            var tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }

                        i++;
                        j--;
                    }
                } while (i <= j);

                if (i < last)
                    QuickSort(list, i, last);
                if (first < j)
                    QuickSort(list, first, j);
            }
        }
    }
}
