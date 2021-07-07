using System;
//Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet.
//Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, но сам код генерации должен происходить вне участка кода,
//время которого будет тестироваться.
//Для каких методов потребуется написать тест:
//- Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
//- Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
//- Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
//- Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
//Результаты можно оформить в виде списка или таблицы, в которой наглядно можно будет увидеть время выполнения того или иного метода.



namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            PointClassFloat dot1 = new PointClassFloat {X = 651654165, Y = 546131 };
            PointClassFloat dot2 = new PointClassFloat();
            dot2.X = 5,55566161F;
            dot2.Y = 515112654;

            Console.WriteLine(DistReferencFloat(dot1, dot2));

            public static float DistReferencFloat(PointClassFloat dot1, PointClassFloat dot2) // Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
            {
                float x = dot1.X - dot2.X;
                float y = dot1.Y - dot2.Y;
                return Math.Sqrt(x * x + y * y);

            }

            static void DistMeaningfulFloat(PointStructFloat dot1, PointStructFloat dot2) // Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
            {

            }

            static double DistMeaningfulDouble(PointStructDouble dot1, PointStructDouble dot2) // Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
            {
                return Math.Sqrt((dot1.X - dot2.X) * (dot1.X - dot2.X) + (dot1.Y - dot2.Y) * (dot1.Y - dot2.Y));
            }

            static void DistMeaningfulFloatNoSqure(PointStructFloat dot1, PointStructFloat dot2) // Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
            {

            }

        }
        public class PointClassFloat
        {
            public float X;
            public float Y;
        }

        public struct PointStructFloat
        {
            public float X;
            public float Y;
        }

        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }
    }
}
