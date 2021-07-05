using System;

//1. Двусвязный список
//Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Тесты
            Node MiNode = new Node(); //создаю новый список firstNode
            MiNode.FirstNode = MiNode; // запоминаю первый элемент списка
            MiNode.LastNode = MiNode;  // запоминаю последний элемент списка 
            MiNode.Value = 12; // записываю в его первый элмент значение 12
            MiNode.AddNode(13); // добавляю следующий элемент списка со значением 13
            MiNode.AddNode(14);
            MiNode.AddNode(15);
            MiNode.AddNode(16);
            MiNode.AddNode(17);

            //вывод созданных элементво списка
            printList(MiNode.FirstNode);

            MiNode.AddNodeAfter(MiNode.NextNode.NextNode.NextNode, 26); //добавляю новый элемент списка после 4-го элемента
            
            //вывод после добавления элемента в середину списка
            Console.Write("Проверка списка после добавления \n");
            printList(MiNode.FirstNode);

            // поиск элментов со значением 16 и 18
            Console.WriteLine("\nПоиск элемента 16");
            if (MiNode.FindNode(16) != null) Console.WriteLine("Элемент списка со значением 16 найден");
            else Console.WriteLine("Элемент списка со значением 16 не найден");
            Console.WriteLine("\nПоиск элемента 18");
            if (MiNode.FindNode(18) != null) Console.WriteLine("Элемент списка со значением 18 найден");
            else Console.WriteLine("Элемент списка со значением 18 не найден");

            //удаление элемента списка переданного как аргумент
            Console.WriteLine("\nУдаление элемента списка переданного как аргумент (со значением 14)");
            MiNode.RemoveNode(MiNode.NextNode.NextNode);
            if (MiNode.FindNode(14) != null) Console.WriteLine("Элемент списка со значением 14 найден");
            else Console.WriteLine("Элемент списка со значением 14 не найден");
            printList(MiNode.FirstNode);

            // удаление элемента списка по индексу
            Console.WriteLine("Удаление 2го по счету элемента списка (со значением 13)");
            MiNode.RemoveNode(2);
            if (MiNode.FindNode(13) != null) Console.WriteLine("Элемент списка со значением 13 найден");
            else Console.WriteLine("Элемент списка со значением 13 не найден");
            printList(MiNode.FirstNode);


            // удаляю 1 и последний элемент списка и вывод всего списка

            Console.WriteLine("\nудаляю 1 и вывод всего списка");
            MiNode.RemoveNode(1);
            printList(MiNode.FirstNode);
            Console.WriteLine("\nудаляю последнего элемент списка и вывод всего списка");
            MiNode.RemoveNode(MiNode.LastNode);
            printList(MiNode.FirstNode);

            static void printList(Node PrintNode)
            {
                Console.WriteLine($"Количество элементов списка - {PrintNode.GetCount()}. Значение первого элемента списка {PrintNode.FirstNode.Value} последнего элемента списка {PrintNode.LastNode.Value}");
                Console.WriteLine($"Список элементов \nЗначение элемента списка {PrintNode.Value}");
                while (PrintNode.NextNode != null)
                {
                    PrintNode = PrintNode.NextNode;
                    Console.WriteLine($"Значение элемента списка {PrintNode.Value}");
                }
                Console.WriteLine("\n");
            }
        }

        
        public class Node : ILinkedList
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
            public Node FirstNode { get; set; }
            public Node LastNode { get; set; }

            public int GetCount()
            {
                Node n = new Node();
                n = FirstNode;
                int i = 1;
                while (n.NextNode != null)
                {
                    i++;
                    n = n.NextNode;
                }
                return i;
            }

            public void AddNode(int value)
            {
                Node NextNode = new Node(); // создаю новый элемент списка
                LastNode.NextNode = NextNode;   // в предыдущий элемент записываю ссылку на новый элемент
                NextNode.PrevNode = LastNode;   // в новом элементе записываю ссылку на предыдущий элемент
                NextNode.Value = value;     // записываю значенией в новый элемент
                LastNode = NextNode;        // сохраняю последний элемент списка
            }

            public void AddNodeAfter(Node node,int value)
            {
                Node newNode = new Node();
                newNode.PrevNode = node;
                newNode.Value = value;
                if (node.NextNode != null) newNode.NextNode = node.NextNode; //если элемент списка не последний
                else LastNode = newNode;                                     //если элемент списка последний запоминаем значение последнего элемента
                node.NextNode = newNode;
            }

            public void RemoveNode(int index)
            {
                if (index > FirstNode.GetCount()) return;
                
                Node delNode = FirstNode;
                
                for(int i = 1; i <= index-1; i++) delNode = delNode.NextNode;
                RemoveNode(delNode);
            }

            public void RemoveNode(Node node)
            {
                if (node.PrevNode != null & node.NextNode != null) // если элемент списка внутри цепочки
                {
                    node.NextNode.PrevNode = node.PrevNode;
                    node.PrevNode.NextNode = node.NextNode;
                }
                else if (node.PrevNode != null & node.NextNode == null) // если элемент списка последний
                {
                    node.PrevNode.NextNode = null;
                    LastNode = node.PrevNode;
                }
                else if (node.PrevNode == null & node.NextNode != null) // если элемент списка первый
                {
                    Console.WriteLine("нельзя удалить первый элемент ( пока не смог придумать как это сделать)");
                    //нельзя удалить первый элемент ( пока не смог придумать как это сделать)
                }
                    
                else
                {
                    //элемент  является единственным
                }
            }

           public Node FindNode(int searchValue)
            {
                Node s = new Node();
                s = this;
                bool FirstNode = true;
                do
                {
                    if (!FirstNode) s = s.NextNode;
                    else FirstNode = false;

                    if (s.Value == searchValue) return s;
                }
                while (s.NextNode != null);
                return null;
            }
        }

        public interface ILinkedList
        {
            int GetCount();                         // возвращает количество элементов в списке
            void AddNode(int value);                // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index);             // удаляет элемент по порядковому номеру
            void RemoveNode(Node node);             // удаляет указанный элемент
            Node FindNode(int searchValue);         // ищет элемент по его значению
            Node FirstNode { get; set; }            // первый элемент списка
            Node LastNode { get; set; }             // последний элемент списка
        }
    }
}
