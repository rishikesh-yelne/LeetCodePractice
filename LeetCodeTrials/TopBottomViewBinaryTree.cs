using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTrials
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int key, Node left = null, Node right = null)
        {
            this.data = key;
            this.left = left;
            this.right = right;
        }
    }

    internal class TopBottomViewBinaryTree
    {
        public TopBottomViewBinaryTree()
        {
            Node t1 = new Node(5, null, null);
            Node t2 = new Node(10, null, null);
            Node t3 = new Node(14, null, null);
            Node t4 = new Node(25, null, null);
            Node t5 = new Node(3, t2, t3);
            Node t6 = new Node(8, t1, t5);
            Node t7 = new Node(22, null, t4);
            Node t8 = new Node(20, t6, t7);

            var bottomResult = BottomView(t8); Console.WriteLine($"Result : {bottomResult.ListToString()}");
            var topResult = TopView(t8); Console.WriteLine($"Result : {topResult.ListToString()}");
        }

        public List<int> BottomView(Node root)
        {
            Queue<Tuple<Node, int>> queue = new Queue<Tuple<Node, int>>();
            Dictionary<int, int> levelMapping = new Dictionary<int, int>();

            queue.Enqueue(new Tuple<Node, int>(root, 0));
            while (queue.Count > 0)
            {
                Tuple<Node, int> element = queue.Dequeue();
                if (levelMapping.ContainsKey(element.Item2))
                {
                    levelMapping.Remove(element.Item2);
                    levelMapping.Add(element.Item2, element.Item1.data);
                }
                else
                {
                    levelMapping.Add(element.Item2, element.Item1.data);
                }

                if (element.Item1.left != null) queue.Enqueue(new Tuple<Node, int>(element.Item1.left, element.Item2 - 1));
                if (element.Item1.right != null) queue.Enqueue(new Tuple<Node, int>(element.Item1.right, element.Item2 + 1));
            }
            return levelMapping.OrderBy(x => x.Key).Select(x => x.Value).ToList();
        }

        public List<int> TopView(Node root)
        {
            Queue<Tuple<Node, int>> queue = new Queue<Tuple<Node, int>>();
            Dictionary<int, int> levelMapping = new Dictionary<int, int>();

            queue.Enqueue(new Tuple<Node, int>(root, 0));
            while (queue.Count > 0)
            {
                Tuple<Node, int> element = queue.Dequeue();
                if (!levelMapping.ContainsKey(element.Item2))
                {
                    levelMapping.Add(element.Item2, element.Item1.data);
                }

                if (element.Item1.left != null) queue.Enqueue(new Tuple<Node, int>(element.Item1.left, element.Item2 - 1));
                if (element.Item1.right != null) queue.Enqueue(new Tuple<Node, int>(element.Item1.right, element.Item2 + 1));
            }
            return levelMapping.OrderBy(x => x.Key).Select(x => x.Value).ToList();
        }
    }
}
