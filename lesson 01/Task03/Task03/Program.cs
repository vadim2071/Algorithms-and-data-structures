using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для вычисления Числа Фибоначчи");
            int n = Convert.ToInt32(Console.ReadLine());
            int n_Rec = FibonachiRecursion(0, 1, n - 2);
            int n_Cycle = FibonachiCycle(n);
            Console.WriteLine("Число Фибоначчи через рекусию {0}\nЧисло Фибоначчи через цикл {1}", n_Rec, n_Cycle);

            //метод вычисления Фиббоначи через рекурсию
            static int FibonachiRecursion(int a, int b, int num)
            {
                a = a + b;
                num--;
                if (num > 0) a = FibonachiRecursion(b, a, num);
                return a;
            }

            //метод вычисления Фиббоначи через цикл
            static int FibonachiCycle(int n)
            {
                int a = 0, b = 1, c = 1;

                for (int i = 0; i < n - 2; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return c;

                /*while (n - 2 > 0)
                {
                    c = a + b;
                    a = b;
                    b = c;
                    n--;
                }
                return c;*/
            }
        }
    }
}
