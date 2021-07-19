﻿using System;


namespace Task01
{
    class Program
    {
        enum Move
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
            int size = 5; // размер массива полей
            //создаем и заполняем массив для пометки полей в которых уже были
            bool[,] fields = new bool[size,size];
            for (int x = 0; x < size; x++) for (int y = 0; y < size; y++) fields[x, y] = false;
            /*
            // создаем массив для хранения найденного маршрута
            Point[,] route = new Point[2, size * size];
            */

            //задаем точку старта обхода
            Point start = new Point();
            start.X = 0;
            start.Y = 0;
            MarkedField(start);
            /*
            //создаю связанный список для обхода
            Field FieldList = new Field ();
            FieldList.PrevField = null;
            FieldList.NextField = null;
            FieldList.point = start;
            FieldList.FirstField = FieldList;
            FieldList.LastField = FieldList;
            */

            // список для хранения лучшего маршрута
            Field BestRoute = new Field { PrevField = null, NextField = null, point = start, FirstField = null, LastField = null };
            BestRoute.FirstField = BestRoute;
            BestRoute.LastField = BestRoute;

            //список для текущего маршрута
            Field CurentRoute = new Field {PrevField = null, NextField = null, point = start, FirstField = null, LastField = null};
            CurentRoute.FirstField = CurentRoute;
            CurentRoute.LastField = CurentRoute;

            nextStep(start);




            void nextStep(Point start)
            {
                Point nextPoint = new Point();
                if (GoTo(Move.DownLeft, start, fields)) //если есть возможность перейти
                {
                    nextPoint.X = start.X + 2;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y - 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };
                
                if(GoTo(Move.DownRight, start, fields))
                {
                    nextPoint.X = start.X + 2;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y + 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };
                
                if (GoTo(Move.UpLeft, start, fields))
                {
                    nextPoint.X = start.X - 2;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y - 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };
                
                if (GoTo(Move.UpRight, start, fields))
                {
                    nextPoint.X = start.X - 2;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y + 1;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };

                if (GoTo(Move.LeftDown, start, fields))
                {
                    nextPoint.X = start.X + 1;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y - 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };
                
                if (GoTo(Move.LeftUp, start, fields))
                {
                    nextPoint.X = start.X - 1;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y - 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };

                if (GoTo(Move.RightDown, start, fields))
                {
                    nextPoint.X = start.X + 1;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y + 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                };
                if (GoTo(Move.RightUp, start, fields))
                {
                    nextPoint.X = start.X - 1;      //помечаем что зашли в это поле
                    nextPoint.Y = start.Y + 2;
                    MarkedField(nextPoint);

                    CurentRoute.AddField(nextPoint); //добавляем новое поле в текущий маршрут
                    nextStep(nextPoint); // продолжаем обход из нового поля
                }
                //испробовали все возможные маршруты
                int count = CurentRoute.GetCount();
                Console.WriteLine($"BestRoute {BestRoute.GetCount()}     CurentRoute {CurentRoute.GetCount()}");
                if (BestRoute.GetCount() < count)
                {
                    Field copyField = new Field(); //временный список для копирвания текущего элемента из текущего маршрута
                    copyField = CurentRoute.FirstField.NextField; //запоминате поле следующее после первого, с которога начинается обход
                    BestRoute.FirstField.NextField = null; // удаляю старый маршрут и копирую новый из текущего
                    int i = 1;
                    while (i < count) //пока не прошлись по всему списку полей маршрута
                    {
                        BestRoute.AddField(copyField.point);
                        copyField = copyField.NextField;
                        i++;
                    }

                    PrintRoute(BestRoute);
                    Console.WriteLine("Для поиска следующего маршрута нажмите клавишу");
                    Console.ReadLine();
                    //BestRoute.FirstField.NextField = CurentRoute.FirstField.NextField; //сохраняем новый лучший маршрут !!! НЕПРАВИЛЬНО! будет сохранять изменения нижнего кода
                    //надо еще удалить пометку из масива обойденных полей
                    DeMarkedField(CurentRoute.LastField.point); // или start !!???

                    CurentRoute.RemoveField(); //удаляем последний ход, чтобы предыдущий вызов метода смог продолжить попытки дальнейшего обхода
                    Console.WriteLine($"BestRoute {BestRoute.GetCount()}     CurentRoute {CurentRoute.GetCount()}");
                }

            }

            void PrintRoute(Field printRoute)
            {
                Field curenFieldPrint = printRoute.FirstField;
                Console.WriteLine($"Маршрут обхода с количеством шагов - {printRoute.GetCount()}");
                //Console.WriteLine($"Начало обхода X - {curenFieldPrint.point.X} : Y - {curenFieldPrint.point.Y}");
                while(curenFieldPrint.NextField != null)
                {
                    Console.WriteLine($"Следующий шаг X - {curenFieldPrint.point.X} : Y - {curenFieldPrint.point.Y}");
                    curenFieldPrint = curenFieldPrint.NextField;
                }
                Console.WriteLine($"Конец  обхода X - {curenFieldPrint.point.X} : Y - {curenFieldPrint.point.Y}");
            }

            void MarkedField(Point field) //помечаем поле как уже пройденное
            {
                fields[field.X, field.Y] = true;
            }
            void DeMarkedField(Point field) // снимаем пометку поля  как пройденного
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

        /*
        public class Fields
        {
            public bool[,] pole  { get; set; }

        }
        */
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

            public void AddField(Point point)
            {
                Field newField = new Field(); // создаю новый элемент списка
                
                newField.PrevField = LastField;   // в новом элементе записываю ссылку на предыдущий элемент
                this.LastField.NextField = newField;   // в предыдущий элемент записываю ссылку на новый элемент
                //NextField.point.X = point.X;     // записываю значенией в новый элемент
                //NextField.point.Y = point.Y;
                newField.point = point;
                this.LastField = newField;        // сохраняю последний элемент списка

                /* первоначальное решение
                Field NextField = new Field(); // создаю новый элемент списка
                LastField.NextField = NextField;   // в предыдущий элемент записываю ссылку на новый элемент
                NextField.PrevField = LastField;   // в новом элементе записываю ссылку на предыдущий элемент
                //NextField.point.X = point.X;     // записываю значенией в новый элемент
                //NextField.point.Y = point.Y;
                NextField.point = point;
                LastField = NextField;        // сохраняю последний элемент списка
                */

                /* кажется должно быть так
                Field nextField = new Field(); // создаю новый элемент списка
                LastField.NextField = nextField;   // в предыдущий элемент записываю ссылку на новый элемент+++++
                nextField.PrevField = LastField;   // в новом элементе записываю ссылку на предыдущий элемент
                //NextField.point.X = point.X;     // записываю значенией в новый элемент
                //NextField.point.Y = point.Y;
                nextField.point = point;
                LastField = NextField;    
                 */
            }

            public void RemoveField() //удаляет последний элемент
            {
                if (LastField.PrevField != null) LastField.PrevField.NextField = null; // если удаляемый шаг не первыйудаляем ссылку на удалямый шаг
                else Console.WriteLine("нельзя удалить первый шаг");  //нельзя удалить первый шаг
            }

        }

        public interface ILinkedListField
        {
            int GetCount();                         // возвращает количество шагов в списке
            void AddField(Point point);                // добавляет новый шаг в текущей попытке
            void RemoveField();                         // удаляет последний шаг
            Field FirstField { get; set; }            // для хранения поле с которого начинается шаг
            Field LastField { get; set; }             // для хранения последнего шага в текущей попытке
        }
    }
}