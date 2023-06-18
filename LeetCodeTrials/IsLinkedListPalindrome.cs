namespace LeetCodeTrials
{
    internal class IsLinkedListPalindrome
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;

            ListNode halfList = FindMid(head);
            ListNode secondHalfList = ReverseList(halfList.next);

            ListNode firstHalfList = head;
            bool answer = true;
            while (answer && secondHalfList != null)
            {
                if (firstHalfList.val != secondHalfList.val) answer = false;
                firstHalfList = firstHalfList.next;
                secondHalfList = secondHalfList.next;
            }

            return answer;
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode curr = head;
            ListNode prev = null;

            while (curr != null)
            {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            return prev;
        }

        private ListNode FindMid(ListNode head)
        {
            ListNode singleJumper = head;
            ListNode doubleJumper = head;

            while (doubleJumper.next != null && doubleJumper.next.next != null)
            {
                singleJumper = singleJumper.next;
                doubleJumper = doubleJumper.next.next;
            }

            return singleJumper;
        }
    }
}
