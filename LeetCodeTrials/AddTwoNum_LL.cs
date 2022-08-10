namespace LeetCodeTrials
{
    internal class AddTwoNum_LL
    {
        public AddTwoNum_LL()
        {
            //ListNode l11 = new ListNode(3, null);
            //ListNode l12 = new ListNode(4, l11);
            //ListNode l13 = new ListNode(2, l12);
            //ListNode l21 = new ListNode(4, null);
            //ListNode l22 = new ListNode(6, l21);
            //ListNode l23 = new ListNode(5, l22);
            //var result = solution.AddTwoNumbers(l13, l23);
            ListNode l11 = new ListNode(9, null);
            ListNode l12 = new ListNode(4, l11);
            ListNode l13 = new ListNode(2, l12);
            ListNode l21 = new ListNode(9, null);
            ListNode l22 = new ListNode(4, l21);
            ListNode l23 = new ListNode(6, l22);
            ListNode l24 = new ListNode(5, l23);
            var result = AddTwoNumbers(l13, l24);
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            ListNode head = new ListNode();
            int carryOver = 0;
            while (!(l1 == null && l2 == null))
            {
                int num1 = 0;
                if (l1 != null)
                {
                    num1 = l1.val;
                    l1 = l1.next;
                }
                int num2 = 0;
                if (l2 != null)
                {
                    num2 = l2.val;
                    l2 = l2.next;
                }

                int sum = num1 + num2 + carryOver;
                carryOver = sum / 10;

                ListNode summationNode = new ListNode(sum % 10, null);
                if (result == null)
                {
                    result = summationNode;
                    head = result;
                }
                else
                {
                    result.next = summationNode;
                    result = result.next;
                }
            }
            if (carryOver > 0)
            {
                ListNode finalNode = new ListNode(carryOver, null);
                if (result != null)
                {
                    result.next = finalNode;
                }
            }
            return head;
        }
    }
}
