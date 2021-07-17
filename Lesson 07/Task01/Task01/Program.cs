using System;


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5; // размер массива
            bool[,] fields = new bool[size,size];
            for (int x = 0; x < size; x++) for (int y = 0; y < size; y++) fields[x, y] = false; //создаем и заполняем массив


            static bool GoUpLeft(int x, int y, int size) //проверяет возможность хода конем наверх налево
            {
                if (x - 3 < 0) return false;
                else if (y - 1 < 0) return false;
                else return true;
            }
            static bool GoUpRight(int x, int y, int size) //проверяет возможность хода конем наверх направо
            {
                if (x - 3 < 0) return false;
                else if (y + 1 < size) return false;
                else return true;
            }
        }


        public class Fields
        {
            public bool[,] pole  { get; set; }

        }

        public class Field : ILinkedListField // класс построения связанного списка ходов
        {
            public int X { get; set; }
            public int Y { get; set; }
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

            public void AddField(int X, int Y)
            {
                Field NextField = new Field(); // создаю новый элемент списка
                LastField.NextField = NextField;   // в предыдущий элемент записываю ссылку на новый элемент
                NextField.PrevField = LastField;   // в новом элементе записываю ссылку на предыдущий элемент
                NextField.X = X;     // записываю значенией в новый элемент
                NextField.Y = Y;
                LastField = NextField;        // сохраняю последний элемент списка
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
            void AddField(int X, int Y);                // добавляет новый шаг в текущей попытке
            void RemoveField();                         // удаляет последний шаг
            Field FirstField { get; set; }            // для хранения поле с которого начинается шаг
            Field LastField { get; set; }             // для хранения последнего шага в текущей попытке
        }
    }
}