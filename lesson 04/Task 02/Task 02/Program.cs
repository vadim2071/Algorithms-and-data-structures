using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Node tree = new Node { Data = 1, Left = null, Right = null, Parent = null };
        }
        public class Node : ITree
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }

            public Node GetRoot() // получение корня дерева
            {
                Node find = this;
                while (find.Parent != null) find = find.Parent;
                return find;
            }
            public void AddItem(int value)
            {

            }
            public void RemoveItem(int value)
            {
                Node del = GetRoot();
                while (del.Data != value)
                {

                }
            }
            public Node GetNodeByValue(int value)
            {

            }
            public void PrintTree()
            {

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




        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode LeftChild { get; set; }
            public TreeNode RightChild { get; set; }


            


            public override bool Equals(object obj)
            {
                var node = obj as TreeNode;

                if (node == null)
                    return false;

                return node.Value == Value;
            }
        }


        public static class TreeHelper
        {
            public static NodeInfo[] GetTreeInLine(ITree tree)
            {
                var bufer = new Queue<NodeInfo>();
                var returnArray = new List<NodeInfo>();
                var root = new NodeInfo() { Node = tree.GetRoot() };
                bufer.Enqueue(root);

                while (bufer.Count != 0)
                {
                    var element = bufer.Dequeue();
                    returnArray.Add(element);

                    var depth = element.Depth + 1;

                    if (element.Node.LeftChild != null)
                    {
                        var left = new NodeInfo()
                        {
                            Node = element.Node.LeftChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(left);
                    }
                    if (element.Node.RightChild != null)
                    {
                        var right = new NodeInfo()
                        {
                            Node = element.Node.RightChild,
                            Depth = depth,
                        };
                        bufer.Enqueue(right);
                    }
                }

                return returnArray.ToArray();
            }
        }

        public class NodeInfo
        {
            public int Depth { get; set; }
            public TreeNode Node { get; set; }
        }

    }
}
