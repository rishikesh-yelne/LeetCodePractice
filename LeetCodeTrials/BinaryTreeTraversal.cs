using System.Text;

namespace LeetCodeTrials
{
    internal class BinaryTreeTraversal
    {
        public BinaryTreeTraversal()
        {
            TreeNode t3 = new TreeNode(3, null, null);
            TreeNode t2 = new TreeNode(2, t3, null);
            TreeNode t1 = new TreeNode(1, null, t2);

            var inorder = InorderTraversal(t1); Console.WriteLine(inorder.ListToString());
            var preorder = PreorderTraversal(t1); Console.WriteLine(preorder.ListToString());
            var postorder = PostorderTraversal(t1); Console.WriteLine(postorder.ListToString());
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            // Recursive approach - Inorder, Preorder, Postorder

            //List<int> result = new List<int>();
            //if (root == null) return result;

            //Inorder(root, result);
            //return result;


            // Iterative approach - Inorder
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (true)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    if (stack.Count == 0) break;

                    node = stack.Pop();
                    result.Add(node.val);
                    node = node.right;
                }
            }
            return result;
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            // Recursive approach - Inorder, Preorder, Postorder

            //List<int> result = new List<int>();
            //if (root == null) return result;

            //Preorder(root, result);
            //return result;


            // Iterative approach - Preorder
            List<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                result.Add(node.val);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
            return result;
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            // Recursive approach - Inorder, Preorder, Postorder

            //List<int> result = new List<int>();
            //if (root == null) return result;

            //Postorder(root, result);
            //return result;


            // Iterative approach - Postorder
            List<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
                result.Add(node.val);
            }

            result.Reverse();
            return result;
        }

        private void Inorder(TreeNode node, List<int> result)
        {
            if (node == null) return;

            Inorder(node.left, result);
            result.Add(node.val);
            Inorder(node.right, result);

        }

        private void Preorder(TreeNode node, List<int> result)
        {
            if (node == null) return;

            Preorder(node.left, result);
            result.Add(node.val);
            Preorder(node.right, result);

        }

        private void Postorder(TreeNode node, List<int> result)
        {
            if (node == null) return;

            Postorder(node.left, result);
            result.Add(node.val);
            Postorder(node.right, result);

        }
    }
}
