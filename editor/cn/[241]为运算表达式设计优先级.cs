//给你一个由数字和运算符组成的字符串 expression ，按不同优先级组合数字和运算符，计算并返回所有可能组合的结果。你可以 按任意顺序 返回答案。 
//
// 生成的测试用例满足其对应输出值符合 32 位整数范围，不同结果的数量不超过 10⁴ 。 
//
// 
//
// 示例 1： 
//
// 
//输入：expression = "2-1-1"
//输出：[0,2]
//解释：
//((2-1)-1) = 0 
//(2-(1-1)) = 2
// 
//
// 示例 2： 
//
// 
//输入：expression = "2*3-4*5"
//输出：[-34,-14,-10,-10,10]
//解释：
//(2*(3-(4*5))) = -34 
//((2*3)-(4*5)) = -14 
//((2*(3-4))*5) = -10 
//(2*((3-4)*5)) = -10 
//(((2*3)-4)*5) = 10
// 
//
// 
//
// 提示： 
//
// 
// 1 <= expression.length <= 20 
// expression 由数字和算符 '+'、'-' 和 '*' 组成。 
// 输入表达式中的所有整数值在范围 [0, 99] 
// 输入表达式中的所有整数都没有前导 '-' 或 '+' 表示符号。 
// 
//
// Related Topics 递归 记忆化搜索 数学 字符串 动态规划 👍 934 👎 0

namespace DifferentWaysToAddParentheses;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<int> DiffWaysToCompute(string expression)
    {
        var operators = new List<char>();
        var operands = new List<int>();
        for (int i = 0; i < expression.Length;)
            if (char.IsDigit(expression[i])) {
                var num = 0;
                while (i < expression.Length && char.IsDigit(expression[i])) {
                    num *= 10;
                    num += expression[i] - '0';
                    i++;
                }
                operands.Add(num);
            } else {
                operators.Add(expression[i]);
                i++;
            }

        if (operators.Count == 0) return operands;

        var n = operators.Count;
        var dp = new List<int>?[n, n]; // dp[i,j] 表示从第i个运算符到第j个运算符的所有可能结果，闭区间

        return AllResults(0, n - 1);

        List<int> AllResults(int lo, int hi) // 闭区间
        {
            if (dp[lo, hi] != null) return dp[lo, hi]!;
            var results = new List<int>();
            for (int i = lo; i <= hi; i++) {
                var left = lo <= i - 1 ? AllResults(lo, i - 1) : [operands[lo]];
                var right = i + 1 <= hi ? AllResults(i + 1, hi) : [operands[hi + 1]];

                foreach (var l in left)
                    foreach (var r in right)
                        switch (operators[i]) {
                            case '+':
                                results.Add(l + r);
                                break;
                            case '-':
                                results.Add(l - r);
                                break;
                            case '*':
                                results.Add(l * r);
                                break;
                        }
            }

            dp[lo, hi] = results;
            return results;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
