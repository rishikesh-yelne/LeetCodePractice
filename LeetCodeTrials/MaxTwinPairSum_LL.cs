namespace LeetCodeTrials
{
    internal class MaxTwinPairSum_LL
    {
        public MaxTwinPairSum_LL()
        {
            ListNode l1 = new ListNode(1, null);
            ListNode l2 = new ListNode(2, l1);
            ListNode l3 = new ListNode(4, l2);
            ListNode l4 = new ListNode(5, l3);

            var result = PairSum(l4);
            Console.WriteLine($"Result : {result}");
        }
        public int PairSum(ListNode head)
        {
            Dictionary<int, int> sum = new Dictionary<int, int>();
            int highest = 0;
            int index = 0;
            ListNode pointerOne = head;
            ListNode pointerTwo = head;
            while (pointerTwo != null)
            {
                if (pointerOne != null)
                {
                    sum.Add(index++, pointerOne.val);
                    highest = Math.Max(highest, pointerOne.val);
                    if (pointerTwo != null)
                    {
                        pointerTwo = pointerTwo.next;
                    }
                    if (pointerTwo != null)
                    {
                        pointerTwo = pointerTwo.next;
                    }
                    if (pointerTwo != null)
                    {
                        pointerOne = pointerOne.next;
                    }
                }
            }
            index--;
            if (pointerOne != null)
            {
                pointerOne = pointerOne.next;
            }
            // now pointerOne is at mid
            while (pointerOne != null)
            {
                int val = sum[index];
                val += pointerOne.val;
                sum[index] = val;
                index--;
                highest = Math.Max(highest, val);
                pointerOne = pointerOne.next;
            }
            return highest;
        }
    }
}
