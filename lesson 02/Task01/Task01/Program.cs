using System;

//1. Двусвязный список
//Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом


namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public class Node : ILinkedList
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }

            public int GetCount()
            {
                int i = 0;
                while (NextNode != null)
                {
                    i++;
                    NextNode = NextNode.NextNode;
                }
                return i;
            }

            public void AddNode(int value)
            {

            }

            public void AddNodeAfter(Node node,int value)
            {

            }

            public void RemoveNode(int index)
            {

            }

            public void RemoveNode(Node node)
            {

            }

           /* public Node FindNode(int searchValue)
            {
               // return ;
            }*/

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

            Node FirstNode { get; } // первый элемент списка

            Node LastNode { get; } // последний элемент списка
        }
    }
}

