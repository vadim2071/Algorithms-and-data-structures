using System;
using System.Diagnostics;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw_int = new Stopwatch();
            Stopwatch sw_hash = new Stopwatch();

            int[,] Arr = new int[3, 1000000];
            int lenghtArr = Arr.GetUpperBound(1);
            var rnd = new Random();
            
            for(int i=0; i<lenghtArr+1; i++) //заполняю массив
            {
                Arr[0, i] = rnd.Next(1, 10000);
                Arr[1, i] = rnd.Next(1, 10000);
                Arr[2, i] = GetHash(Arr[0, i], Arr[1, i]);
                //Console.WriteLine($"Первый элемент - {Arr[0, i]}   Второй элемент - {Arr[1, i]}     Хэш - {Arr[2, i]}");
            }

            //запоминаем значение последей строки массива, которые будем искать
            int serchVal1 = Arr[0, 9999];
            int serchVal2 = Arr[1, 9999];

            //поиск по значению
            sw_int.Start();
            for(int i = 0; i<lenghtArr+1; i++)
            {
                if (Arr[0, i] == serchVal1) if (Arr[1, i] == serchVal2) break;
            }
            sw_int.Stop();
            Console.WriteLine($"Время поиска по значению перебором - {sw_int.Elapsed} ");

            //поиск по Хеш
            sw_hash.Start();
            int hash = GetHash(serchVal1, serchVal2);
            for (int i = 0; i < lenghtArr + 1; i++)
            {
                if (Arr[2, i] == hash) break;
            }
            sw_hash.Stop();
            Console.WriteLine($"Время поиска по Хеш - {sw_hash.Elapsed} ");


            static int GetHash(int a, int b) // метод расчета Хеш
            {
                return a + b*10;
            }

        }
    }
}
