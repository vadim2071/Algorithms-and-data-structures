using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для вычисления Числа Фибоначчи");
            int n = Convert.ToInt32(Console.ReadLine());
            int n_Rec = FibonachiRecursion(n, n - 1);
            int n_Cycle = FibonachiCycle(n);
            Console.WriteLine("Число Фибоначчи через рекусию {0}\nЧисло Фибоначчи через цикл {1}", n_Rec, n_Cycle);

            //метод вычисления Фиббоначи через рекурсию
            static int FibonachiRecursion(int n1, int n2)
            {
                int n = 0;
                if (n2 > 0) n = FibonachiRecursion(n2, n2 - 1);
                return n = n + n1;
            }

            //метод вычисления Фиббоначи через цикл
            static int FibonachiCycle(int n)
            {
                int sum = 0;
                while(n > 0)
                {
                    sum = sum + n;
                    n--;
                }
                return sum;
            }
        }
    }
}
