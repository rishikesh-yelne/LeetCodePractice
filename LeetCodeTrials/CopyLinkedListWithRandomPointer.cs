namespace LeetCodeTrials
{
    internal class CopyLinkedListWithRandomPointer
    {
        public CopyLinkedListWithRandomPointer()
        {
            Node n1 = new Node(7);
            Node n2 = new Node(13);
            Node n3 = new Node(11);
            Node n4 = new Node(10);
            Node n5 = new Node(1);
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = null;
            n1.random = null;
            n2.random = n1;
            n3.random = n5;
            n4.random = n3;
            n5.random = n1;

            var result_recursive = CopyRandomList_Recursive(n1);
            var result_iterative = CopyRandomList_Iterative(n1);
            Console.WriteLine($"Result (recursive): {result_recursive}");
            Console.WriteLine($"Result (iterative): {result_iterative}");
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val, Node next = null, Node random = null)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        Dictionary<Node, Node> dictionary = new Dictionary<Node, Node>();

        public Node CopyRandomList_Recursive(Node head)
        {
            if (head == null) return null;
            if (dictionary.ContainsKey(head)) return dictionary[head];

            Node clone = new Node(head.val, null, null);
            dictionary.Add(head, clone);

            clone.next = CopyRandomList_Recursive(head.next);
            clone.random = CopyRandomList_Recursive(head.random);

            return clone;
        }

        private Node GetClonedNode(Node node)
        {
            if (node != null)
            {
                if (dictionary.ContainsKey(node)) return dictionary[node];
                Node clone = new Node(node.val, null, null);
                dictionary.Add(node, clone);
                return clone;
            }
            return null;
        }

        public Node CopyRandomList_Iterative(Node head)
        {
            if (head == null) return null;

            Node oldHead = head;
            Node newHead = new Node(head.val);
            dictionary.Add(oldHead, newHead);

            while (oldHead != null)
            {
                newHead.next = GetClonedNode(oldHead.next);
                newHead.random = GetClonedNode(oldHead.random);

                oldHead = oldHead.next;
                newHead = newHead.next;
            }
            return dictionary[head];
        }
    }
}
