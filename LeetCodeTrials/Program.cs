// See https://aka.ms/new-console-template for more information
using LeetCodeTrials;

TreeNode t1 = new TreeNode(4, null, null);
TreeNode t2 = new TreeNode(5, null, null);
TreeNode t3 = new TreeNode(6, null, null);
TreeNode t4 = new TreeNode(7, null, null);
TreeNode t5 = new TreeNode(2, t1, t2);
TreeNode t6 = new TreeNode(3, t3, t4);
TreeNode t7 = new TreeNode(1, t5, t6);

Solution solution = new Solution();
var result = solution.LevelOrder(t7);
Console.WriteLine($"Result : {result}");

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

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {

    }
}