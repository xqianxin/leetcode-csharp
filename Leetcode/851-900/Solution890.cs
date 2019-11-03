
/*
 890. Find and Replace Pattern

You have a list of words and a pattern, and you want to know which words in words matches the pattern.

A word matches the pattern if there exists a permutation of letters p so that after replacing every letter x in the 
pattern with p(x), we get the desired word.

(Recall that a permutation of letters is a bijection from letters to letters: every letter maps to another letter, 
and no two letters map to the same letter.)

Return a list of the words in words that match the given pattern. 

You may return the answer in any order.

 

Example 1:

Input: words = ["abc","deq","mee","aqq","dkd","ccc"], pattern = "abb"
Output: ["mee","aqq"]
Explanation: "mee" matches the pattern because there is a permutation {a -> m, b -> e, ...}. 
"ccc" does not match the pattern because {a -> c, b -> c, ...} is not a permutation,
since a and b map to the same letter.
 

Note:

1 <= words.length <= 50
1 <= pattern.length = words[i].length <= 20
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode_csharp.leetcode._851_900
{
    class Solution890
    {
        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            IList<string> result = new List<string>();
            
            foreach (string word in words)
            {
                Dictionary<char, char> patMap = new Dictionary<char, char>();
                Dictionary<char, char> revertMp = new Dictionary<char, char>();
                bool can = true;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (!patMap.ContainsKey(pattern[i]))
                    {
                        patMap[pattern[i]] = word[i];
                    }
                    if (!revertMp.ContainsKey(word[i]) )
                    {
                        revertMp[word[i]] = pattern[i];
                    }
                    if (patMap[pattern[i]] != word[i] || revertMp[word[i]] != pattern[i])
                    {
                        can = false;
                        break;
                    }
                }
                if(can)
                {
                    result.Add(word);
                }
            }
            return result;
        }
    }
}
