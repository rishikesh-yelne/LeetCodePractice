namespace LeetCodeTrials
{
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

    internal class VerticalTraversalBinaryTree
    {
        public VerticalTraversalBinaryTree()
        {
            //TreeNode t1 = new TreeNode(9, null, null);
            //TreeNode t2 = new TreeNode(15, null, null);
            //TreeNode t3 = new TreeNode(7, null, null);
            //TreeNode t4 = new TreeNode(20, t2, t3);
            //TreeNode t5 = new TreeNode(3, t1, t4);

            TreeNode t1 = new TreeNode(0, null, null);
            TreeNode t2 = new TreeNode(2, null, null);
            TreeNode t3 = new TreeNode(2, null, null);
            TreeNode t4 = new TreeNode(1, t1, t2);
            TreeNode t5 = new TreeNode(4, t3, null);
            TreeNode t6 = new TreeNode(3, t4, t5);

            var result = VerticalTraversal(t6);
            Console.WriteLine($"Result : {result}");
        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            // create a queue with a tuple of TreeNode and co-ordinate of the node (x, y) tuple
            Queue<Tuple<TreeNode, Tuple<int, int>>> queue = new Queue<Tuple<TreeNode, Tuple<int, int>>>();

            // create a dictionary of level with list of nodes at that level 
            Dictionary<int, IList<Tuple<int, int>>> coordinateMapping = new Dictionary<int, IList<Tuple<int, int>>>();

            queue.Enqueue(new Tuple<TreeNode, Tuple<int, int>>(root, new Tuple<int, int>(0, 0)));
            while (queue.Count > 0)
            {
                Tuple<TreeNode, Tuple<int, int>> element = queue.Dequeue();
                if (coordinateMapping.ContainsKey(element.Item2.Item1)) // check if X co-ordinate (level) is already present in dictionary
                {
                    IList<Tuple<int, int>> existingList = coordinateMapping[element.Item2.Item1];
                    coordinateMapping.Remove(element.Item2.Item1);
                    existingList.Add(new Tuple<int, int>(element.Item1.val, element.Item2.Item2));
                    coordinateMapping.Add(element.Item2.Item1, existingList.OrderBy(x => x.Item2).ThenBy(x => x.Item1).ToList());
                }
                else
                {
                    coordinateMapping.Add(element.Item2.Item1, new List<Tuple<int, int>>() { new Tuple<int, int>(element.Item1.val, element.Item2.Item2) });
                }

                if (element.Item1.left != null) queue.Enqueue(new Tuple<TreeNode, Tuple<int, int>>(element.Item1.left, new Tuple<int, int>(element.Item2.Item1 - 1, element.Item2.Item2 + 1)));
                if (element.Item1.right != null) queue.Enqueue(new Tuple<TreeNode, Tuple<int, int>>(element.Item1.right, new Tuple<int, int>(element.Item2.Item1 + 1, element.Item2.Item2 + 1)));
            }
            var valueList = coordinateMapping.OrderBy(x => x.Key).Select(x => x.Value).ToList();
            List<IList<int>> elements = new List<IList<int>>();
            foreach (var element in valueList)
            {
                elements.Add(element.Select(x => x.Item1).ToList());
            }
            return elements;
        }
    }
}
