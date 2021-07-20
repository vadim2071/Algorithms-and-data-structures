using System;


namespace Task01
{
    class Program
    {
        enum Move //возможные напраления движения 
        {
            UpLeft,
            UpRight,
            LeftDown,
            LeftUp,
            RightUp,
            RightDown,
            DownLeft,
            DownRight
        }

        static void Main(string[] args)
        {
            int size = 7; // размер массива полей для поиска маршрута
            //задаем точку старта обхода
            Point start = new Point {X = 0, Y = 0 };

            //создаем и заполняем массив для пометки полей в которых уже были
            bool[,] fields = new bool[size,size];
            for (int x = 0; x < size; x++) for (int y = 0; y < size; y++) fields[x, y] = false;
            MarkedField(start); //  помечаем точку старта

            // список для хранения лучшего маршрута
            Field BestRoute = new Field { PrevField = null, NextField = null, point = start, FirstField = null, LastField = null };
            BestRoute.FirstField = BestRoute;
            BestRoute.LastField = BestRoute;

            //список для текущего маршрута
            Field CurentRoute = new Field {PrevField = null, NextField = null, point = start, FirstField = null, LastField = null};
            CurentRoute.FirstField = CurentRoute;
            CurentRoute.LastField = CurentRoute;

            //поехали
            nextStep(start);
            PrintRoute(BestRoute);



            void nextStep(Point start) //метод исследования всех возможных ходов из текущей точки
            {
                if (BestRoute.GetCount() == size*size) return; // зачем искать дальше если уже нашли максимально возможный (не проходит если максимально возможный не возможен)

                Point nextPoint = new Point();
                if (GoTo(Move.DownLeft, start, fields)) // если есть возможность перейти
                {
                    nextPoint.X = start.X + 2;          // помечаем что зашли в это поле
                    nextPoint.Y = start.Y - 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    // добавляем новое поле в текущий маршрут
                    nextStep(nextPoint);                // продолжаем обход из нового поля
                };
                
                if(GoTo(Move.DownRight, start, fields))
                {
                    nextPoint.X = start.X + 2;          
                    nextPoint.Y = start.Y + 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                };
                
                if (GoTo(Move.UpLeft, start, fields))
                {
                    nextPoint.X = start.X - 2;          
                    nextPoint.Y = start.Y - 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                };
                
                if (GoTo(Move.UpRight, start, fields))
                {
                    nextPoint.X = start.X - 2;          
                    nextPoint.Y = start.Y + 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                };

                if (GoTo(Move.LeftDown, start, fields))
                {
                    nextPoint.X = start.X + 1;          
                    nextPoint.Y = start.Y - 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                };
                
                if (GoTo(Move.LeftUp, start, fields))
                {
                    nextPoint.X = start.X - 1;          
                    nextPoint.Y = start.Y - 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                };

                if (GoTo(Move.RightDown, start, fields))
                {
                    nextPoint.X = start.X + 1;          
                    nextPoint.Y = start.Y + 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                };
                if (GoTo(Move.RightUp, start, fields))
                {
                    nextPoint.X = start.X - 1;          
                    nextPoint.Y = start.Y + 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint);    
                    nextStep(nextPoint);                
                }

                //испробовали все возможные маршруты в текущем вызове
                int count = CurentRoute.GetCount();

                if (BestRoute.GetCount() < count)                       //если "текущий" маршрут длинее "лучшего" маршрута, сохраняем "текущий" маршрут как "лучший"
                {
                    Field copyField = CurentRoute.FirstField.NextField; //запоминает поле следующее после первого, с которога начинается обход

                    BestRoute.FirstField.NextField = null;              // удаляю старый маршрут и копирую новый из текущего
                    BestRoute.LastField = BestRoute.FirstField;

                    for(int i=1; i < count; i++)                        //пока не прошлись по всему списку полей маршрута, создаю новое поле и копирую его координаты
                    {
                        BestRoute.AddField(copyField.point);
                        copyField = copyField.NextField;
                    }
                    Console.WriteLine($"Найден маршрут обхода с количеством заполненных полей = {count}");

                }
                //В этом обходе возможных вариантов ходов все проверили, удаляем последний ход, чтобы предыдущий вызов метода смог продолжить попытки дальнейшего обхода
                DeMarkedField(CurentRoute.LastField.point);
                CurentRoute.RemoveField();
            }

            void PrintRoute(Field printRoute) //метод вывода в консоль найденного марщрута
            {
                Field curenFieldPrint = printRoute.FirstField;
                Console.WriteLine($"Максимальный маршрут обхода с количеством заполненых полей = {printRoute.GetCount()}");
                string[,] ArrayRoutePrint = new string[size, size];
                string str = "+----+";
                string str1 = "";
                for (int n = 0; n < size-1; n++) str = str + "----+";
                int i = 0;
                while(curenFieldPrint.NextField != null)
                {
                    //Console.WriteLine($"Следующий шаг X - {curenFieldPrint.point.X} : Y - {curenFieldPrint.point.Y}");
                    ArrayRoutePrint[curenFieldPrint.point.X, curenFieldPrint.point.Y] = Convert.ToString(i).Length == 1 ? "0" + Convert.ToString(i) : Convert.ToString(i);
                    i++;
                    curenFieldPrint = curenFieldPrint.NextField;
                }
                //Console.WriteLine($"Конец  обхода X - {curenFieldPrint.point.X} : Y - {curenFieldPrint.point.Y}");
                ArrayRoutePrint[curenFieldPrint.point.X, curenFieldPrint.point.Y] = Convert.ToString(i).Length == 1 ? "0" + Convert.ToString(i) : Convert.ToString(i);
                Console.WriteLine(str);
                for ( int k=0; k<ArrayRoutePrint.GetUpperBound(0)+1; k++)
                {
                    str1 = "|";
                    for (int m = 0; m < ArrayRoutePrint.GetUpperBound(1)+1; m++) str1 = str1 + " " + (ArrayRoutePrint[k, m] ==null ? "  " : ArrayRoutePrint[k, m]) + " |";
                    Console.WriteLine(str1);
                    Console.WriteLine(str);
                }
            }

            void MarkedField(Point field)   //помечает поле как уже пройденное
            {
                fields[field.X, field.Y] = true;
            }
            void DeMarkedField(Point field) // снимает пометку поля  как пройденного
            {
                fields[field.X, field.Y] = false;
            }


            bool GoTo(Move move, Point start, bool[,] fields) // метод (проверка на выход за пределы поля и что в поле еще не были)
            {
                int size = fields.GetUpperBound(0);
                bool canMove = true;
                switch (move)
                {
                    case Move.UpLeft:   //проверяет возможность хода конем наверх налево
                        if ((start.X - 2 < 0) || (start.Y - 1 < 0) || (fields[start.X - 2, start.Y - 1])) canMove = false; 
                        break;
                    case Move.UpRight:  //проверяет возможность хода конем наверх направо
                        if ((start.X - 2 < 0) || (start.Y + 1 > size) || (fields[start.X - 2, start.Y + 1])) canMove = false;
                        break;
                    case Move.LeftDown: //проверяет возможность хода конем налево вниз
                        if ((start.X + 1 > size) || (start.Y - 2 < 0) || (fields[start.X + 1, start.Y - 2])) canMove = false;
                        break;
                    case Move.LeftUp:   //проверяет возможность хода конем налево вверх
                        if ((start.X - 1 < 0) || (start.Y - 2 < 0) || (fields[start.X - 1, start.Y - 2])) canMove = false;
                        break;
                    case Move.RightDown:    //проверяет возможность хода конем направо вниз
                        if ((start.X + 1 > size) || (start.Y + 2 > size) || (fields[start.X + 1, start.Y + 2])) canMove = false;
                        break;
                    case Move.RightUp:  //проверяет возможность хода конем направо вверх
                        if ((start.X - 1 < 0) || (start.Y + 2 > size) || (fields[start.X - 1, start.Y + 2])) canMove = false;
                        break;
                    case Move.DownLeft: //проверяет возможность хода конем вниз налево
                        if ((start.X + 2 > size) || (start.Y - 1 < 0) || (fields[start.X + 2, start.Y - 1])) canMove = false;
                        break;
                    case Move.DownRight:    //проверяет возможность хода конем вниз направо
                        if ((start.X + 2 > size) || (start.Y + 1 > size) || (fields[start.X + 2, start.Y + 1])) canMove = false;
                        break;
                }
                return canMove;
            }

        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public class Field : ILinkedListField // класс построения связанного списка ходов
        {
            public Point point { get; set; }
            public Field NextField { get; set; }
            public Field PrevField { get; set; }
            public Field FirstField { get; set; }
            public Field LastField { get; set; }

            public int GetCount()
            {
                Field n = new Field();
                n = FirstField;
                int i = 1;
                while (n.NextField != null)
                {
                    i++;
                    n = n.NextField;
                }
                return i;
            }

            public void AddField(Point Pnt)
            {
                Field nextField = new Field();      // создаю новый элемент списка
                LastField.NextField = nextField;    // в предыдущий элемент записываю ссылку на новый элемент+++++
                nextField.PrevField = LastField;    // в новом элементе записываю ссылку на предыдущий элемент
                LastField = nextField;    

                Point newPoint = new Point();
                newPoint.X = Pnt.X;                 // записываю значениея в новый элемент
                newPoint.Y = Pnt.Y;                 
                nextField.point = newPoint;
                
            }

            public void RemoveField() //удаляет последний элемент списка
            {
                if (LastField.PrevField != null) 
                {
                    Field temp  = LastField.PrevField;
                    LastField.PrevField.NextField = null;   // если удаляемый шаг не первыйудаляем ссылку на удалямый шаг
                    FirstField.LastField = temp;
                } 
                else Console.WriteLine("");                 //нельзя удалить первый шаг
            }

        }

        public interface ILinkedListField
        {
            int GetCount();                         // возвращает количество шагов в списке
            void AddField(Point point);             // добавляет новый шаг в текущей попытке
            void RemoveField();                     // удаляет последний шаг
            Field FirstField { get; set; }          // для хранения поле с которого начинается шаг
            Field LastField { get; set; }           // для хранения последнего шага в текущей попытке
        }
    }
}