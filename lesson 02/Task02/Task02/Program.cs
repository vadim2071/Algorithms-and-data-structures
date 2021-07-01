using System;

//Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.
// нужное число найдется максимально за O(log(N)) (N- диапазон поиска, количесвто значений, которое может принять искомое число)


namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] test = new int [] {0, 10, 25, 50, 71, 99, 100 };
            int lenght = test.Length;
            
            for (int i = 0; i < lenght; i++) Console.WriteLine($"Найдено за {BinarySerch(0, 100, test[i])} шагов, правильное число {test[i]}");

            static int BinarySerch(int min, int max, int num)
            {
                int average = 0;
                int count = 0;
                while (average != num)
                {
                    average = (min + max) / 2;
                    if (num < average) max = average-1;
                    else if (num > average) min = average+1;
                    count++;
                }
                Console.WriteLine($"\n загаданное число {average}");
                return count;
            }
        }
    }
}
