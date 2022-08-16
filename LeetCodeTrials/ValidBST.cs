namespace LeetCodeTrials
{
    internal class ValidBST
    {
        public bool IsValidBST(TreeNode root)
        {
            return CheckIfValidBST(root);
        }

        private bool CheckIfValidBST(TreeNode node)
        {
            if (node == null) return true;
            if (node.left != null)
            {
                if (node.left.val > node.val) return false;
                return CheckIfValidBST(node.left);
            }
            if (node.right != null)
            {
                if (node.right.val < node.val) return false;
                return CheckIfValidBST(node.right);
            }
            return true;
        }
    }
}
