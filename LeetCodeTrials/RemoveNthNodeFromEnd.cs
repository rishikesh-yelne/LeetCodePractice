namespace LeetCodeTrials
{
    internal class RemoveNthNodeFromEnd
    {
        public RemoveNthNodeFromEnd()
        {
            ListNode l5 = new ListNode(5, null);
            ListNode l4 = new ListNode(4, l5);
            ListNode l3 = new ListNode(3, l4);
            ListNode l2 = new ListNode(2, l3);
            ListNode l1 = new ListNode(1, l2);
            var result = RemoveNthFromEnd(l1, 1);
            Console.WriteLine($"Result : {result}");
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (!ReferenceEquals(null, head) && ReferenceEquals(null, head.next)) return null;
            ListNode returnList = head;
            ListNode deleteHead = head;
            int index = 0;
            while (!ReferenceEquals(null, head))
            {
                if (index <= n) head = head.next;
                else if (index > n)
                {
                    head = head.next;
                    deleteHead = deleteHead.next;
                }
                index++;
            }
            if (index == n)
            {
                returnList = returnList.next;
            }
            else if (!ReferenceEquals(null, deleteHead) && !ReferenceEquals(null, deleteHead.next))
            {
                deleteHead.next = deleteHead.next.next;
            }
            return returnList;
        }
    }
}
