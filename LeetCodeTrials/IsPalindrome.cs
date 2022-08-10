namespace LeetCodeTrials
{
    public class IsPalindrome
    {
        //ListNode node4 = new ListNode()
        //{
        //    val = 1,
        //    next = null
        //};
        //ListNode node3 = new ListNode()
        //{
        //    val = 2,
        //    next = node4
        //};
        //ListNode node2 = new ListNode()
        //{
        //    val = 2,
        //    next = node3
        //};
        //ListNode node1 = new ListNode()
        //{
        //    val = 1,
        //    next = node2
        //};
        //Solution solution = new Solution();
        //bool answer = solution.IsPalindrome(node1);
        //Console.WriteLine($"Answer : {answer}");
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public bool IsPalindrome(ListNode head)
        {
            Stack<int> stackedList = new Stack<int>();
            ListNode currentNode = head;

            while (currentNode != null)
            {
                stackedList.Push(currentNode.val);
                currentNode = currentNode.next;
            }

            int length = stackedList.Count / 2;
            for (int i = 0; i < length; i++)
            {
                if (head.val != stackedList.Pop())
                    return false;
                head = head.next;
            }
            return true;
        }
    }
}
