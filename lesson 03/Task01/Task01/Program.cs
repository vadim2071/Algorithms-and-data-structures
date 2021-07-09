using System;
using System.Diagnostics;
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

            Stopwatch sw;
            float distanceFloat;
            double distanceDouble;
            
            float[,] floatArr =  { { 2375272741.2f, 947227122.2f, 6519728728.2f, 7862872774.2f, 88278276786.4f },{87782782795.5f, 67278258.5f, 5828782874.5f, 56872782785.5f, 445546.3f }, { 47935.5f, 655775788.5f, 58872854.5f, 5678285.5f, 453436.3f }, { 4538278278.2f, 4537872.2f, 786378282318.2f, 453444.2f, 4535346.4f } };
            double[,] doubleArr = { { 2375272741.2, 947227122.2, 6519728728.2, 7862872774.2, 88278276786.4 }, { 87782782795.5, 67278258.5, 5828782874.5, 56872782785.5, 445546.3 }, { 47935.5, 655775788.5, 58872854.5, 5678285.5, 453436.3 }, { 4538278278.2, 4537872.2, 786378282318.2, 453444.2, 4535346.4 } };

            Console.WriteLine("     Тест            Время");

            //- Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
            PointClassFloat dot1 = new PointClassFloat();
            PointClassFloat dot2 = new PointClassFloat();
            Console.WriteLine("Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).");
            for (int i =0; i< 5; i++)
            {
                sw = new Stopwatch();
                dot1.X = floatArr[0, i];
                dot1.Y = floatArr[1, i];
                dot2.X = floatArr[2, i];
                dot2.Y = floatArr[3, i];

                sw.Start();
                distanceDouble = DistReferencFloat(dot1, dot2);
                sw.Stop();

                Console.WriteLine($"Тест № {i + 1, 3}          время {sw.Elapsed}");
            }
            //- Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
            Console.WriteLine("Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).");
            PointStructFloat dot5 = new PointStructFloat();
            PointStructFloat dot6 = new PointStructFloat();
            for (int i = 0; i < 5; i++)
            {
                sw = new Stopwatch();
                dot5.X = floatArr[0, i];
                dot5.Y = floatArr[1, i];
                dot6.X = floatArr[2, i];
                dot6.Y = floatArr[3, i];

                sw.Start();
                distanceDouble = DistMeaningfulFloat(dot5, dot6);
                sw.Stop();

                Console.WriteLine($"Тест № {i + 1,3}          время {sw.Elapsed}");
            }


            //- Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
            Console.WriteLine("Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).");
            PointStructDouble dot3 = new PointStructDouble();
            PointStructDouble dot4 = new PointStructDouble();
            for (int i = 0; i < 5; i++)
            {
                sw = new Stopwatch();
                dot3.X = doubleArr[0, i];
                dot3.Y = doubleArr[1, i];
                dot4.X = doubleArr[2, i];
                dot4.Y = doubleArr[3, i];

                sw.Start();
                distanceDouble = DistMeaningfulDouble(dot3, dot4);
                sw.Stop();

                Console.WriteLine($"Тест № {i + 1,3}          время {sw.Elapsed}");
            }

            //- Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
            Console.WriteLine("Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).");
            PointStructFloat dot7 = new PointStructFloat();
            PointStructFloat dot8 = new PointStructFloat();
            for (int i = 0; i < 5; i++)
            {
                sw = new Stopwatch();
                dot7.X = floatArr[0, i];
                dot7.Y = floatArr[1, i];
                dot8.X = floatArr[2, i];
                dot8.Y = floatArr[3, i];

                sw.Start();
                distanceDouble = DistMeaningfulFloatNoSqure(dot7, dot8);
                sw.Stop();

                Console.WriteLine($"Тест № {i + 1,3}          время {sw.Elapsed}");
            }

            static double DistReferencFloat(PointClassFloat dot1, PointClassFloat dot2) // Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
            {
                float x = dot1.X - dot2.X;
                float y = dot1.Y - dot2.Y;
                return Math.Sqrt(x * x + y * y);

            }
            
            static double DistMeaningfulFloat(PointStructFloat dot1, PointStructFloat dot2) // Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
            {
                float x = dot1.X - dot2.X;
                float y = dot1.Y - dot2.Y;
                return Math.Sqrt(x * x + y * y);
            }

            static double DistMeaningfulDouble(PointStructDouble dot1, PointStructDouble dot2) // Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
            {
                return Math.Sqrt((dot1.X - dot2.X) * (dot1.X - dot2.X) + (dot1.Y - dot2.Y) * (dot1.Y - dot2.Y));
            }

            static float DistMeaningfulFloatNoSqure(PointStructFloat dot1, PointStructFloat dot2) // Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
            {
                float x = dot1.X - dot2.X;
                float y = dot1.Y - dot2.Y;
                return (x * x + y * y);
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
