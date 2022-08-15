namespace LeetCodeTrials
{
    public class BinaryTreeNode
    {
        public int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode next;

        public BinaryTreeNode() { }

        public BinaryTreeNode(int _val)
        {
            val = _val;
        }

        public BinaryTreeNode(int _val, BinaryTreeNode _left, BinaryTreeNode _right, BinaryTreeNode _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    internal class ConnectNextPointerBT
    {
        public ConnectNextPointerBT()
        {
            BinaryTreeNode t1 = new BinaryTreeNode(4, null, null, null);
            BinaryTreeNode t2 = new BinaryTreeNode(5, null, null, null);
            BinaryTreeNode t3 = new BinaryTreeNode(6, null, null, null);
            BinaryTreeNode t4 = new BinaryTreeNode(7, null, null, null);
            BinaryTreeNode t5 = new BinaryTreeNode(2, t1, t2, null);
            BinaryTreeNode t6 = new BinaryTreeNode(3, t3, t4, null);
            BinaryTreeNode t7 = new BinaryTreeNode(1, t5, t6, null);

            var result = Connect(t7);
            Console.WriteLine($"Result : {result}");
        }

        public BinaryTreeNode Connect(BinaryTreeNode root)
        {
            if (root == null) return null;
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                BinaryTreeNode initNode = queue.Dequeue();
                if (initNode.left != null) queue.Enqueue(initNode.left);
                if (initNode.right != null) queue.Enqueue(initNode.right);

                for (int i = 1; i < size; i++)
                {
                    BinaryTreeNode node = queue.Dequeue();
                    initNode.next = node;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    initNode = node;
                }
                initNode.next = null;
            }
            return root;
        }
    }
}
