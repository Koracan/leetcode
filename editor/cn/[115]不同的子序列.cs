//给你两个字符串 s 和 t ，统计并返回在 s 的 子序列 中 t 出现的个数。 
//
// 测试用例保证结果在 32 位有符号整数范围内。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "rabbbit", t = "rabbit"
//输出：3
//解释：
//如下所示, 有 3 种可以从 s 中得到 "rabbit" 的方案。
//rabbbit
//rabbbit
//rabbbit 
//
// 示例 2： 
//
// 
//输入：s = "babgbag", t = "bag"
//输出：5
//解释：
//如下所示, 有 5 种可以从 s 中得到 "bag" 的方案。 
//babgbag
//babgbag
//babgbag
//babgbag
//babgbag
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length, t.length <= 1000 
// s 和 t 由英文字母组成 
// 
//
// Related Topics 字符串 动态规划 👍 1344 👎 0

namespace DistinctSubsequences;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int NumDistinct(string s, string t)
    {
        int m = s.Length, n = t.Length;
        var dp = new int[n + 1];
        dp[0] = 1;
        for (var i = 1; i <= m; i++)
            for (var j = n; j >= 1; j--)
                if (s[i - 1] == t[j - 1])
                    dp[j] += dp[j - 1];

        return dp[n];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
