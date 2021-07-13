using System;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Тесты
            //создаем дерево
            //                      18
            //                  /           \
            //                 10            22    
            //               /    \        /     \            
            //            11        13     77    88           
            //            /\        /\            /\  
            //           5  7     44   55       1    17         
            //           /\              \                   
            //          8  4              23                                      

            Node tree = new Node { Data = 18, Left = null, Right = null, Parent = null };
            tree.AddItem(10);
            tree.AddItem(22);
            tree.Left.AddItem(11);
            tree.Left.AddItem(13);
            tree.Left.Left.AddItem(5);
            tree.Left.Left.AddItem(7);
            tree.Left.Left.Left.AddItem(8);
            tree.Left.Left.Left.AddItem(4);
            tree.Left.Right.AddItem(44);
            tree.Left.Right.AddItem(55);
            tree.Left.Right.Right.AddItem(23);

            tree.Right.AddItem(77);
            tree.Right.AddItem(88);
            tree.Right.Right.AddItem(1);
            tree.Right.Right.AddItem(17);

            
        }
        public class Node : ITree
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }

            public Node GetRoot() // получение корня дерева (хотя можно было бы и хранить в классе)
            {
                Node find = this;
                while (find.Parent != null) find = find.Parent;
                return find;
            }
            public void AddItem(int value) //добавление нового узла к текущему, если у текущего нет левой ветки, то новый узел становится левой веткой
                                           // если нет правой ветки, то новый узел становится правой веткой, иначе новый узел не создается
            {
                Node newNode = new Node { Data = value, Left = null, Right = null, Parent = this };
                if (this.Left == null) this.Left = newNode;
                else if (this.Right == null) this.Right = newNode;
            }
            public void RemoveItem(int value) // удалить узел по значению
            {
                Node del = new Node();
                del = this.GetNodeByValue(value);

                if (del.Parent != null) // если есть верхний элемент (владелец удаляемого элемента)
                {
                    if (del.Parent.Left == del) del.Parent.Left = null; // если удаляемый элемент является левой веткой владельца, уадаляем всю ветку 
                    else if (del.Parent.Right == del) del.Parent.Right = null; // если удаляемый элемент является правой веткой владельца, уадаляем всю ветку 
                                                                               //удалить элемент из цепочки не можем, может возникнуть ситуация когда у 
                                                                               //удаляемго элемента могут быть 2 ветки, а мы можем аписать ссылку только на одну. 
                }
                del.Parent = null;
                del.Left = null;
                del.Right = null;

            }
            public Node GetNodeByValue(int value) //получить узел дерева по значению
            {
                return FindNode(GetRoot(), value); //находим корень дерева, запускаем обход дерева. Возвращает найденный элемент или null если не найдено. 
            }

            public Node FindNode(Node find, int value) // рекурсивый метод обхода дерева. Возвращает найденный элемент или null если не найдено. 
            {
                Node returnNode = null;
                if (find.Data == value) return find;
                else if (find.Left != null) returnNode = FindNode(find.Left, value);
                if (find.Right != null & returnNode == null) returnNode = FindNode(find.Right, value);
                return returnNode;
            }
            public void PrintTree() //вывести дерево в консоль
            {
                Console.WriteLine($"{PrintNext(GetRoot())}");
            }
            public string PrintNext(Node node)
            {
                string PrintString = $"({node.Data}";
                if (node.Left != null & node.Right != null) PrintString = PrintString + "(" + PrintNext(node.Left) + PrintNext(node.Right) + ")";
                else if (node.Left != null & node.Right == null) PrintString = PrintString + "(" + PrintNext(node.Left) + ")";
                else if (node.Left == null & node.Right != null) PrintString = PrintString + "(" + PrintNext(node.Right) + ")";
                PrintString = PrintString + ")";
                return PrintString;

            }

        }
        public interface ITree
        {
            Node GetRoot(); // получение корня дерева
            void AddItem(int value); // добавить узел
            void RemoveItem(int value); // удалить узел по значению
            Node GetNodeByValue(int value); //получить узел дерева по значению
            void PrintTree(); //вывести дерево в консоль
        }
    }
}