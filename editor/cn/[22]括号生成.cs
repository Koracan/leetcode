//数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 3
//输出：["((()))","(()())","(())()","()(())","()()()"]
// 
//
// 示例 2： 
//
// 
//输入：n = 1
//输出：["()"]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 8 
// 
//
// Related Topics 字符串 动态规划 回溯 👍 3833 👎 0

namespace GenerateParentheses;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        // var sb = new StringBuilder(2 * n);
        // var result = new List<string>();
        // Next(0, 0, sb);
        // return result;
        //
        // void Next(int left, int right, StringBuilder current)
        // {
        //     if (left == n)
        //     {
        //         current.Append(new string(')', n - right));
        //         result.Add(current.ToString());
        //         current.Remove(left + right, n - right);
        //         return;
        //     }
        //     
        //     current.Append('(');
        //     Next(left + 1, right, current);
        //     current.Remove(left + right, 1);
        //
        //     if (left > right)
        //     {
        //         current.Append(')');
        //         Next(left, right + 1, current);
        //         current.Remove(left + right, 1);
        //     }
        // }

        var dp = new List<string>[n + 1];
        dp[0] = [""];
        dp[1] = ["()"];
        for (var i = 2; i <= n; i++) {
            dp[i] = [];
            for (var j = 0; j < i; j++)
                foreach (var s1 in dp[j])
                    foreach (var s2 in dp[i - j - 1])
                        dp[i].Add($"({s2}){s1}");
        }

        return dp[n];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
