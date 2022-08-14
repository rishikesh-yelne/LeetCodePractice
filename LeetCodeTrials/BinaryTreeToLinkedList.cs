namespace LeetCodeTrials
{
    internal class BinaryTreeToLinkedList
    {
        public BinaryTreeToLinkedList()
        {
            TreeNode t1 = new TreeNode(4, null, null);
            TreeNode t2 = new TreeNode(5, null, null);
            TreeNode t3 = new TreeNode(6, null, null);
            TreeNode t4 = new TreeNode(7, null, null);
            TreeNode t5 = new TreeNode(2, t1, t2);
            TreeNode t6 = new TreeNode(3, t3, t4);
            TreeNode t7 = new TreeNode(1, t5, t6);

            Flatten(t7);
        }

        // for recursive approach
        TreeNode previousNode = null;

        public void Flatten(TreeNode root)
        {
            if (root == null) return;

            // recursive approach
            //TreeToLinkedList(root);

            // iterative approach
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                if (currentNode.right != null) stack.Push(currentNode.right);
                if (currentNode.left != null) stack.Push(currentNode.left);

                if (stack.Count > 0) currentNode.right = stack.Peek();
                currentNode.left = null;
            }
        }

        private void TreeToLinkedList(TreeNode node)
        {
            if (node == null) return;

            if (node.right != null) TreeToLinkedList(node.right);
            if (node.left != null) TreeToLinkedList(node.left);

            node.right = previousNode;
            node.left = null;
            previousNode = node;
        }
    }
}
