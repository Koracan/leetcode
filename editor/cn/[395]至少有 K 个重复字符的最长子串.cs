//给你一个字符串 s 和一个整数 k ，请你找出 s 中的最长子串， 要求该子串中的每一字符出现次数都不少于 k 。返回这一子串的长度。 
//
// 如果不存在这样的子字符串，则返回 0。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "aaabb", k = 3
//输出：3
//解释：最长子串为 "aaa" ，其中 'a' 重复了 3 次。
// 
//
// 示例 2： 
//
// 
//输入：s = "ababbc", k = 2
//输出：5
//解释：最长子串为 "ababb" ，其中 'a' 重复了 2 次， 'b' 重复了 3 次。 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 10⁴ 
// s 仅由小写英文字母组成 
// 1 <= k <= 10⁵ 
// 
//
// Related Topics 哈希表 字符串 分治 滑动窗口 👍 988 👎 0

namespace LongestSubstringWithAtLeastKRepeatingCharacters;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LongestSubstring(string s, int k)
    {
        return Helper(0, s.Length);

        int Helper(int start, int end) // [start,end)
        {
            if (end - start < k) return 0;

            var counts = new int[26];
            for (var i = start; i < end; i++)
                counts[s[i] - 'a']++;

            for (var i = start; i < end; i++)
                if (counts[s[i] - 'a'] < k) {
                    var j = i + 1;
                    while (j < end && counts[s[j] - 'a'] < k) j++;

                    // A valid substring won't contain a char within [i,j) because its count is less than k
                    return Math.Max(Helper(start, i), Helper(j, end));
                }

            // else, all chars within [start,end) have count >= k
            return end - start;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
