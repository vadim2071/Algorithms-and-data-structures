using System;


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {

        }


        public class Field : ILinkedListField
        {
            public int NumStep { get; set; }
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

            public void AddField(int step)
            {
                Field NextField = new Field(); // создаю новый элемент списка
                LastField.NextField = NextField;   // в предыдущий элемент записываю ссылку на новый элемент
                NextField.PrevField = LastField;   // в новом элементе записываю ссылку на предыдущий элемент
                NextField.NumStep = step;     // записываю значенией в новый элемент
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
            void AddField(int value);                // добавляет новый шаг в текущей попытке
            void RemoveField();                         // удаляет последний шаг
            Field FirstField { get; set; }            // для хранения поле с которого начинается шаг
            Field LastField { get; set; }             // для хранения последнего шага в текущей попытке
        }
    }
}