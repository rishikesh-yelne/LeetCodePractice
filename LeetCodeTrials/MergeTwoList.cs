namespace LeetCodeTrials
{
    internal class MergeTwoList
    {
        public MergeTwoList()
        {
            ListNode l13 = new ListNode(4, null);
            ListNode l12 = new ListNode(2, l13);
            ListNode l11 = new ListNode(1, l12);

            ListNode l23 = new ListNode(4, null);
            ListNode l22 = new ListNode(3, l23);
            ListNode l21 = new ListNode(1, l22);

            MergeTwoLists(l11, l21);
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

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode resultHead = new ListNode(0);
            ListNode iteratorHead = resultHead;

            while (list1 != null && list2 != null)
            {
                if (list1.val >= list2.val)
                {
                    iteratorHead.next = list2;
                    list2 = list2.next;
                }
                else
                {
                    iteratorHead.next = list1;
                    list1 = list1.next;
                }

                iteratorHead = iteratorHead.next;
            }

            if (list1 != null && iteratorHead != null) iteratorHead.next = list1;
            if (list2 != null && iteratorHead != null) iteratorHead.next = list2;
            return resultHead.next;
        }
    }
}
