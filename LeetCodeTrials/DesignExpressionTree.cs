namespace LeetCodeTrials
{
    internal class DesignExpressionTree
    {
        public DesignExpressionTree()
        {
            TreeBuilder obj = new TreeBuilder();
            Node expTree = obj.buildTree(new string[] { "3", "74874773", "*", "236198211", "211385612", "-", "606145066", "606145051", "-", "*", "+", "300759894", "+" });//(new string[] { "3", "4", "+", "2", "*", "7", "/" });//(new string[] { "4", "5", "2", "7", "+", "-", "*"});//
            int ans = expTree.evaluate();
            Console.WriteLine($"Result : {ans}");
        }
        /**
        * This is the interface for the expression tree Node.
        * You should not remove it, and you can define some classes to implement it.
        */

        public abstract class Node
        {
            public abstract int evaluate();
            // define your fields here
        };

        public class TreeNode : Node
        {
            public string val { get; set; } = string.Empty;
            public TreeNode left { get; set; } = null;
            public TreeNode right { get; set; } = null;

            public TreeNode()
            {

            }

            public TreeNode(string val, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
            public override int evaluate()
            {
                switch (val)
                {
                    case "+":
                        return left.evaluate() + right.evaluate();
                    case "-":
                        return left.evaluate() - right.evaluate();
                    case "*":
                        return left.evaluate() * right.evaluate();
                    case "/":
                        return left.evaluate() / right.evaluate();
                    default:
                        return int.Parse(val);
                }
            }
        }

        /**
         * This is the TreeBuilder class.
         * You can treat it as the driver code that takes the postinfix input 
         * and returns the expression tree represnting it as a Node.
         */

        public class TreeBuilder
        {
            public Node buildTree(string[] postfix)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                foreach (string ele in postfix)
                {
                    switch (ele)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                            TreeNode right = stack.Pop();
                            TreeNode left = stack.Pop();
                            stack.Push(new TreeNode(ele, left, right));
                            break;
                        default:
                            stack.Push(new TreeNode(ele));
                            break;
                    }
                }
                return stack.Peek();
            }
        }


        /**
         * Your TreeBuilder object will be instantiated and called as such:
         * TreeBuilder obj = new TreeBuilder();
         * Node expTree = obj.buildTree(postfix);
         * int ans = expTree.evaluate();
         */

    }
}
