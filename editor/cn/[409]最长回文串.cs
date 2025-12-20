//给定一个包含大写字母和小写字母的字符串
// s ，返回 通过这些字母构造成的 最长的 回文串 的长度。 
//
// 在构造过程中，请注意 区分大小写 。比如 "Aa" 不能当做一个回文字符串。 
//
// 
//
// 示例 1: 
//
// 
//输入:s = "abccccdd"
//输出:7
//解释:
//我们可以构造的最长的回文串是"dccaccd", 它的长度是 7。
// 
//
// 示例 2: 
//
// 
//输入:s = "a"
//输出:1
//解释：可以构造的最长回文串是"a"，它的长度是 1。
// 
//
// 
//
// 提示: 
//
// 
// 1 <= s.length <= 2000 
// s 只由小写 和/或 大写英文字母组成 
// 
//
// Related Topics 贪心 哈希表 字符串 👍 643 👎 0

namespace LongestPalindrome;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int LongestPalindrome(string s)
    {
        var counts = new int[52];
        foreach (var c in s) counts[GetIndex(c)]++;
        var result = 0;
        var hasOdd = 0;
        foreach (var count in counts) {
            result += count & ~1;
            hasOdd |= count & 1;
        }

        return result + hasOdd;
        int GetIndex(char c) => c <= 'Z' ? c - 'A' : c - 'a' + 26;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
