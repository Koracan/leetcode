//累加数 是一个字符串，组成它的数字可以形成累加序列。 
//
// 一个有效的 累加序列 必须 至少 包含 3 个数。除了最开始的两个数以外，序列中的每个后续数字必须是它之前两个数字之和。 
//
// 给你一个只包含数字 '0'-'9' 的字符串，编写一个算法来判断给定输入是否是 累加数 。如果是，返回 true ；否则，返回 false 。 
//
// 说明：累加序列里的数，除数字 0 之外，不会 以 0 开头，所以不会出现 1, 2, 03 或者 1, 02, 3 的情况。 
//
// 
//
// 示例 1： 
//
// 
//输入："112358"
//输出：true 
//解释：累加序列为: 1, 1, 2, 3, 5, 8 。1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
// 
//
// 示例 2： 
//
// 
//输入："199100199"
//输出：true 
//解释：累加序列为: 1, 99, 100, 199。1 + 99 = 100, 99 + 100 = 199 
//
// 
//
// 提示： 
//
// 
// 1 <= num.length <= 35 
// num 仅由数字（0 - 9）组成 
// 
//
// 
//
// 进阶：你计划如何处理由过大的整数输入导致的溢出? 
//
// Related Topics 字符串 回溯 👍 471 👎 0

namespace AdditiveNumber;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public bool IsAdditiveNumber(string num)
    {
        // 只要确定前两个数，就能确定后续的数
        int n = num.Length;
        for (int i = 1; i <= n / 2; i++)
            for (int j = 1; Math.Max(i, j) <= n - i - j; j++)
                if (IsValid(i, j))
                    return true;

        return false;

        bool IsValid(int len1, int len2)
        {
            if (num[0] == '0' && len1 > 1) return false;
            if (num[len1] == '0' && len2 > 1) return false;

            ulong num1 = ulong.Parse(num.AsSpan(0,len1));
            ulong num2 = ulong.Parse(num.AsSpan(len1,len2));
            num.AsSpan();
            int start = len1 + len2;
            while (start < num.Length) {
                ulong sum = num1 + num2;
                string sumStr = sum.ToString();
                if (!num.AsSpan(start).StartsWith(sumStr)) return false;

                start += sumStr.Length;
                num1 = num2;
                num2 = sum;
            }
            return true;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
