using System;
using System.Collections.Generic;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //создам массив отношений вершин графа
            // |    | 1  | 2  | 3  | 4  | 5  | 6  | 7  | 8  | 9  | 10 |         (1)      (2)----1------(3)-----2------- (4)
            // |----|----|----|----|----|----|----|----|----|----|----|          | \       | \          /                /     
            // | 1  |    |    |    |    |  2 |  4 |    |    |    |    |          |   \     |  \         |               /          
            // |----|----|----|----|----|----|----|----|----|----|----|          2     4   1    2       6              5              
            // | 2  |    |    |  1 |    |    |  1 |  2 |    |    |    |          |       \ |      \    /             /         
            // |----|----|----|----|----|----|----|----|----|----|----|          (5)       (6)       (7)          (8)
            // | 3  |    |  1 |    | 2  |    |    |  6 |    |    |    |           \         /         |            /            
            // |----|----|----|----|----|----|----|----|----|----|----|            \       /          |           /             
            // | 4  |    |    |  2 |    |    |    |    | 5  |    |    |             5     1           4          8                      
            // |----|----|----|----|----|----|----|----|----|----|----|              \    /            \      /                         
            // | 5  |  2 |    |    |    |    |    |    |    |  5 |    |                (9)------3-------(10)
            // |----|----|----|----|----|----|----|----|----|----|----|
            // | 6  |  4 | 1  |    |    |    |    |    |    |  1 |    |
            // |----|----|----|----|----|----|----|----|----|----|----|
            // | 7  |    | 2  | 6  |    |    |    |    |    |    | 4  |
            // |----|----|----|----|----|----|----|----|----|----|----|
            // | 8  |    |    |    | 5  |    |    |    |    |    | 8  |
            // |----|----|----|----|----|----|----|----|----|----|----|
            // | 9  |    |    |    |    |  5 | 1  |    |    |    | 3  |
            // |----|----|----|----|----|----|----|----|----|----|----|
            // | 10 |    |    |    |    |    |    | 4  | 8  |  3 |    |

            //создаем и заполняем массив. где нет связей записываем число 5000, которое больше во много раз самого длинного маршрута
            int[,] graf = new int[,]    { {5000, 5000, 5000, 5000, 2, 4, 5000, 5000, 5000, 5000 },
                                        { 5000, 5000, 1, 5000, 5000, 1, 2, 5000, 5000, 5000 },
                                        { 5000, 1, 5000, 2, 5000, 5000, 6, 5000, 5000, 5000 },
                                        { 5000, 5000, 2, 5000, 5000, 5000, 5000, 5, 5000, 5000 },
                                        { 2, 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5, 5000 },
                                        { 4, 1, 5000, 5000, 5000, 5000, 5000, 5000, 1, 5000 },
                                        { 5000, 2, 6, 5000, 5000, 5000, 5000, 5000, 5000, 4 },
                                        { 5000, 5000, 5000, 5, 5000, 5000, 5000, 5000, 5000, 8 },
                                        { 5000, 5000, 5000, 5000, 5, 1, 5000, 5000, 5000, 3 },
                                        { 5000, 5000, 5000, 5000, 5000, 5000, 4, 8, 3, 5000 } };

            BFSearch(graf, 2);
            DFSerch(graf, 3);
            SerchDijkstra(graf, 8, 1);



            static void SerchDijkstra(int[,] grafPrint, int start, int end) //поиск кратчайшего пути. grafPrint - масcив графа, start - начало маршрута, end - конец маршрута)
            {
                Console.WriteLine($"поиск кратчайшего пути из вершины {start} в вершину {end}");
                int lenght = grafPrint.Length / grafPrint.GetLength(0);
                if (start > lenght + 1 || end > lenght+1 || start < 1 || end < 1) return; //проверяем чтобы вершины попадала в диапазон вершин
                Queue<int> quaeue = new Queue<int>(); // Инициализирум очередь
                
                int point = start - 1;
                quaeue.Enqueue(point);
                int[] route = new int[] { 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000, 5000 }; // массив для хранения весов маршрутов
                                                                                                        // 5000 такого маршрута точно не будет

                route[point] = 0;

                while(quaeue.Count != 0)
                {
                    point = quaeue.Dequeue();
                    for (int i = 0; i < lenght; i++) //ищем смежные вершины
                    {
                        if (grafPrint[point, i] != 5000) //если вершины смежные
                        {
                            if (route[point] + grafPrint[point, i] < route[i]) //если новый маршрут короче существующего
                            {
                                route[i] = route[point] + grafPrint[point, i];
                                quaeue.Enqueue(i);
                            }
                        }
                    }
                }
                Console.WriteLine($"Кратчайшего маршрут из вершины {start} в вершину {end} - {route[end-1]}");
                // вывод самого маршрута
                point = end - 1;
                Stack<int> stack = new Stack<int>(); //Стэк для записи маршрута
                stack.Push(point);

                //quaeue.Enqueue(point);
                while (point != start - 1)
                {
                    for (int i = 0; i < lenght; i++)//перебираем все вершины
                    {
                        if (grafPrint[point, i] != 5000) //если вершина смежная проверяем длину маршрута
                        {
                            if (route[point] - grafPrint[point,i] == route[i])
                            {
                                stack.Push(i);
                                point = i;
                            }
                        }
                    }
                }

                while (stack.Count != 0) Console.WriteLine($"Вершина {stack.Pop()+1}"); //Вывод промежуточных точек


            }

            static void BFSearch(int[,] grafPrint, int start) //обход в ширину. grafPrint - масcив графа, start - номер вершины с которой начинается обход
            {
                //обход в ширину
                Console.WriteLine("Использование Очереди для обхода графа в глубину");
                int lenght = grafPrint.Length / grafPrint.GetLength(0);
                if (start > lenght + 1 || start < 1) return; //проверяем чтобы вершина попадала в диапазон вершин
                Queue<int> quaeue = new Queue<int>(); // Инициализирум очередь
                bool[] vawe = new bool[] {false, false, false, false, false, false, false, false, false, false}; // массив для хранения факта вхождений в вершину
                int i = start;
                quaeue.Enqueue(i);
                vawe[i - 1] = true;

                while (quaeue.Count != 0)
                {
                    i = quaeue.Dequeue();
                    Console.WriteLine($"Элемент {i}");
                    for (int k = 0; k < lenght; k++)
                    {
                        if (grafPrint[i - 1, k] != 5000 & !vawe[k]) 
                        {
                            quaeue.Enqueue(k + 1); //если есть связь между вершинами и в соседнюю вершины мы еще не заходили
                            vawe[k] = true;
                        }
                        
                    }
                }

            }

            static void DFSerch(int[,] grafPrint, int start) //обход в глубину grafPrint - масcив графа, start - номер вершины с которой начинается обход

            {
                Console.WriteLine("Использование Стека для обхода дерева в глубину");
                int lenght = grafPrint.Length / grafPrint.GetLength(0);
                if (start > lenght + 1 || start < 1) return; //проверяем чтобы вершина попадала в диапазон вершин
                Stack<int> stack = new Stack<int>(); // Инициализирум стек
                bool[] vawe = new bool[] { false, false, false, false, false, false, false, false, false, false }; // массив для хранения факта вхождений в вершину
                int i = start;
                stack.Push(i);
                vawe[i - 1] = true;

                while (stack.Count != 0)
                {
                    i = stack.Pop();
                    Console.WriteLine($"Элемент {i}");
                    for (int k = 0; k < lenght; k++)
                    {
                        if (grafPrint[i - 1, k] != 5000 & !vawe[k])
                        {
                            stack.Push(k + 1); //если есть связь между вершинами и в соседнюю вершины мы еще не заходили
                            vawe[k] = true;
                        }

                    }
                }

            }
        }
    }
}
