//给你一个字符串 s ，请你去除字符串中重复的字母，使得每个字母只出现一次。需保证 返回结果的字典序最小（要求不能打乱其他字符的相对位置）。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "bcabc"
//输出："abc"
// 
//
// 示例 2： 
//
// 
//输入：s = "cbacdcbc"
//输出："acdb" 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 10⁴ 
// s 由小写英文字母组成 
// 
//
// 
//
// 注意：该题与 1081 https://leetcode-cn.com/problems/smallest-subsequence-of-
//distinct-characters 相同 
//
// Related Topics 栈 贪心 字符串 单调栈 👍 1164 👎 0

namespace RemoveDuplicateLetters;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string RemoveDuplicateLetters(string s)
    {
        var lastIndex = new int[26];
        for (var i = 0; i < s.Length; i++)
            lastIndex[s[i] - 'a'] = i;
        var stack = new Stack<char>();
        var inStack = new bool[26];
        for (var i = 0; i < s.Length; i++) {
            var c = s[i];
            if (inStack[c - 'a']) continue;

            while (stack.TryPeek(out var top) && top > c && lastIndex[top - 'a'] > i)
                inStack[stack.Pop() - 'a'] = false;

            stack.Push(c);
            inStack[c - 'a'] = true;
        }

        var result = new char[stack.Count];
        for (var i = stack.Count - 1; i >= 0; i--)
            result[i] = stack.Pop();

        return new(result);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
