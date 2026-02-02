//给你一个字符串 s 和一个整数 k 。你可以选择字符串中的任一字符，并将其更改为任何其他大写英文字符。该操作最多可执行 k 次。 
//
// 在执行上述操作后，返回 包含相同字母的最长子字符串的长度。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "ABAB", k = 2
//输出：4
//解释：用两个'A'替换为两个'B',反之亦然。
// 
//
// 示例 2： 
//
// 
//输入：s = "AABABBA", k = 1
//输出：4
//解释：
//将中间的一个'A'替换为'B',字符串变为 "AABBBBA"。
//子串 "BBBB" 有最长重复字母, 答案为 4。
//可能存在其他的方法来得到同样的结果。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 10⁵ 
// s 仅由大写英文字母组成 
// 0 <= k <= s.length 
// 
//
// Related Topics 哈希表 字符串 滑动窗口 👍 946 👎 0

namespace LongestRepeatingCharacterReplacement;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int lo = 0, hi = 0;
        int[] count = new int[26];
        int maxCount = 0;
        int maxLength = 0;

        while (hi < s.Length) {
            count[s[hi] - 'A']++;
            maxCount = Math.Max(maxCount, count[s[hi] - 'A']);
            hi++;

            while (hi - lo - maxCount > k) {
                count[s[lo] - 'A']--;
                lo++;
            }

            maxLength = Math.Max(maxLength, hi - lo);
        }

        return maxLength;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
