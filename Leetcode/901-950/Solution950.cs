
/**
 * 950. Reveal Cards In Increasing Order
 * 
In a deck of cards, every card has a unique integer.  You can order the deck in any order you want.

Initially, all the cards start face down (unrevealed) in one deck.

Now, you do the following steps repeatedly, until all cards are revealed:

Take the top card of the deck, reveal it, and take it out of the deck.
If there are still cards in the deck, put the next top card of the deck at the bottom of the deck.
If there are still unrevealed cards, go back to step 1.  Otherwise, stop.
Return an ordering of the deck that would reveal the cards in increasing order.

The first entry in the answer is considered to be the top of the deck.

 

Example 1:

Input: [17,13,11,2,3,5,7]
Output: [2,13,3,11,5,17,7]
Explanation: 
We get the deck in the order [17,13,11,2,3,5,7] (this order doesn't matter), and reorder it.
After reordering, the deck starts as [2,13,3,11,5,17,7], where 2 is the top of the deck.
We reveal 2, and move 13 to the bottom.  The deck is now [3,11,5,17,7,13].
We reveal 3, and move 11 to the bottom.  The deck is now [5,17,7,13,11].
We reveal 5, and move 17 to the bottom.  The deck is now [7,13,11,17].
We reveal 7, and move 13 to the bottom.  The deck is now [11,17,13].
We reveal 11, and move 17 to the bottom.  The deck is now [13,17].
We reveal 13, and move 17 to the bottom.  The deck is now [17].
We reveal 17.
Since all the cards revealed are in increasing order, the answer is correct.
 

Note:

1 <= A.length <= 1000
1 <= A[i] <= 10^6
A[i] != A[j] for all i != j
 */


 /*
  * 思路
  * 模拟一遍整个流程，可以得到原来序列的每个元素对应的最终位置，根据最终位置推导出应该的值
  * 比如第四个元素走完流程后到了第一个，那个第四个元素就应该是最小的
  * 
  */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._901_950
{
    class Solution950
    {
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            List<int> tmp = new List<int>(deck);
            tmp.Sort();

            // 下标队列
            Queue<int> que = new Queue<int>();
            for(int i = 0; i < deck.Length; i++)
            {
                que.Enqueue(i);
            }

            // 下标最终位置
            int[] resIdx = new int[deck.Length];
            int increase = 0;
            while(que.Count > 0)
            {
                resIdx[increase] =que.Dequeue();
                increase++;
                if(que.Count > 0)
                {
                    que.Enqueue(que.Dequeue());
                }
            }
            int[] result = new int[tmp.Count];
            for(int i = 0; i < resIdx.Length; i++)
            {
                int idx = resIdx[i];
                result[idx] = tmp[i];
            }
            return result;
        }
    }
}
