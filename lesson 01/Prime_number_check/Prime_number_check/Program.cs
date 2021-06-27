using System;

namespace Prime_number_check
{
    class Program
    {
        static void Main(string[] args)
        {
            if (PrimeNumber(GetNumber())) Console.WriteLine("Это простое число");
            else Console.WriteLine("Это не простое число");

            
            static int GetNumber()
            {
                int number = 0;
                Console.WriteLine("Определение простого числа");
                while (number == 0)
                {
                    try
                    {
                        Console.WriteLine("Введите число");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number <= 0)
                        {
                            Console.WriteLine("Ошибка! Вы ввели отрицательное число или ноль");
                            number = 0;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка! Вы ввели не число!");
                    }
                }
                return number;
            }

            static bool PrimeNumber(int number)
            {
                int d = 0;
                int i = 2;

                while (i < number)
                {
                    if (number % i == 0) d++;
                    i++;
                }

                if (d == 0) return true;
                else return false;
            }


        }

        
    }
}
