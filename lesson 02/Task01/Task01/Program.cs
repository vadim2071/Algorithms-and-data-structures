using System;

//1. Двусвязный список
//Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Node MiNode = new Node(); //создаю новый спискок firstNode
            MiNode.Value = 12; // записываю в его первый элмент значение 12
            MiNode.AddNode(13); // добавляю следующий элемент списка со значением 13
            MiNode.AddNode(14);
            MiNode.AddNode(15);
            MiNode.AddNode(16);
            MiNode.AddNode(17);

            Console.WriteLine($"Количество элементов списка - {MiNode.GetCount()}");

            //test
            Node testNode = new Node();
            testNode = MiNode;
            Console.WriteLine($"Значение элемента списка {testNode.Value}");
            while (testNode.NextNode != null) 
            {
                testNode = testNode.NextNode;
                Console.WriteLine($"Значение элемента списка {testNode.Value}");
            }

            MiNode.AddNodeAfter(MiNode.NextNode.NextNode.NextNode, 26); //добавляю новый элемент списка после 4-го элемента

            //test
            testNode = MiNode;
            Console.Write("Проверка списка после добавления \n");
            Console.WriteLine($"Значение элемента списка {testNode.Value}");
            while (testNode.NextNode != null)
            {
                testNode = testNode.NextNode;
                Console.WriteLine($"Значение элемента списка {testNode.Value}");
            }

            if (MiNode.FindNode(16) != null) Console.WriteLine("Элемент списка со значением 16 найден, только я не очень понял как его вывести на экран");
            else Console.WriteLine("Элемент списка со значением 16 не найден");
            if (MiNode.FindNode(18) != null) Console.WriteLine("Элемент списка со значением 18 найден, только я не очень понял как его вывести на экран");
            else Console.WriteLine("Элемент списка со значением 18 не найден");

            Console.WriteLine("Удаление предпоследнего элемента списка со занчением 16");
            MiNode.RemoveNode(MiNode.NextNode.NextNode.NextNode.NextNode);
            if (MiNode.FindNode(16) != null) Console.WriteLine("Элемент списка со значением 16 найден, только я не очень понял как его вывести на экран");
            else Console.WriteLine("Элемент списка со значением 16 не найден");

        }


        public class Node : ILinkedList
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }

            public int GetCount()
            {
                Node n = new Node();
                n = this;
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
                Node i = new Node();
                i = this;

                while(i.NextNode != null) i = i.NextNode;//нахожу последний элемент списка

                Node NextNode = new Node(); // создаю новый элемент списка
                i.NextNode = NextNode;   // в предыдущий элемент записываю ссылку на новый элемент
                NextNode.PrevNode = i;   // в новом элементе записываю ссылку на предыдущий элемент
                NextNode.Value = value;     // записываю значенией в новый элемент

            }

            public void AddNodeAfter(Node node,int value)
            {
                Node newNode = new Node();
                if (node.NextNode != null) newNode.NextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.PrevNode = node;
                newNode.Value = value;
            }

            public void RemoveNode(int index)
            {

            }

            public void RemoveNode(Node node)
            {
                if (node.PrevNode != null & node.NextNode != null) // если элемент списка внутри цепочки
                {
                    node.NextNode.PrevNode = node.PrevNode;
                    node.PrevNode.NextNode = node.NextNode;
                }
                else if (node.PrevNode != null & node.NextNode == null) node.PrevNode.NextNode = null; // если элемент списка последний
                else if (node.PrevNode == null & node.NextNode != null) node.NextNode.PrevNode = null; // если элемент списка первый
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

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению

            //Node FirstNode { get; } // первый элемент списка

            //Node LastNode { get; } // последний элемент списка
        }
    }
}

