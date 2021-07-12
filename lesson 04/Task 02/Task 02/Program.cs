using System;

namespace Task_02
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

            Node tree = new Node { Data = 1, Left = null, Right = null, Parent = null };
            tree.AddItem(10);
            tree.AddItem(22);
            tree.Left.AddItem(11);
            tree.Right.AddItem(13);
            tree.GetNodeByValue(11).AddItem(5);
            tree.GetNodeByValue(11).AddItem(7);
            tree.GetNodeByValue(5).AddItem(8);
            tree.GetNodeByValue(5).AddItem(4);
            tree.GetNodeByValue(13).AddItem(44);
            tree.GetNodeByValue(13).AddItem(55);
            tree.GetNodeByValue(55).AddItem(23);
            tree.GetNodeByValue(22).AddItem(77);
            tree.GetNodeByValue(22).AddItem(88);
            tree.GetNodeByValue(88).AddItem(1);
            tree.GetNodeByValue(88).AddItem(17);

            Node find = new Node();
            Console.WriteLine($"")
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
            public void AddItem(int value)
            {
                Node newNode = new Node {Data = value, Left = null, Right = null, Parent = this };
                if (this.Left == null) this.Left = newNode;
                else if (this.Right == null) this.Right = newNode;
            }
            public void RemoveItem(int value) // удалить узел по значению
            {
                Node del = FindNode(GetRoot(), value);
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
                if (find.Right != null & returnNode != null) returnNode = FindNode(find.Right, value);
                return returnNode;
            }
            public void PrintTree() //вывести дерево в консоль
            {
                Console.WriteLine($"{PrintNext(GetRoot())}");
            }
            public string PrintNext(Node node)
            {
                string PrintString = $"({node.Data})";
                if (node.Left != null & node.Right != null) PrintString = PrintString + "(" + PrintNext(node.Left) + "  " + PrintNext(node.Right) + ")";
                else if (node.Left != null & node.Right == null) PrintString = PrintString + "(" + PrintNext(node.Left) + "  " + ")";
                else if (node.Left == null & node.Right != null) PrintString = PrintString + "(" + "  " + PrintNext(node.Right) + ")";
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
