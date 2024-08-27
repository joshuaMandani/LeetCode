/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public bool IsPalindrome(ListNode head) {
        var d1 = head;
        var d2 = head;
        var delay = true;
        var count = 0;

        //Set d1 to point to 2nd half of list whilst counting the list length
        while (d2 != null) {
            d2 = d2.next;
            if (delay) {
                d1 = d1.next;
                delay = false;
            } else {
                delay = true;
            }
            count++;
        }

        //Reverse first half of list
        d2 = head;
        ListNode dummy = null;
        for (var i = 0; i < count / 2; i++) {
            var temp = d2.next;
            d2.next = dummy;
            dummy = d2;
            d2 = temp;
        }

        //Compare reversed first half (dummy as head) and second half of original list (d1)
        for (var i = 0; i < count / 2; i++) {
            if (d1.val != dummy.val) {
                return false;
            } else {
                d1 = d1.next;
                dummy = dummy.next;
            }
        }
        return true;
    }
}