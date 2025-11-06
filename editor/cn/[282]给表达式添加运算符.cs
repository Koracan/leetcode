//给定一个仅包含数字 0-9 的字符串 num 和一个目标值整数 target ，在 num 的数字之间添加 二元 运算符（不是一元）+、- 或 * ，返回 
//所有 能够得到 target 的表达式。 
//
// 注意，返回表达式中的操作数 不应该 包含前导零。 
//
// 注意，一个数字可以包含多个数位。 
//
// 
//
// 示例 1: 
//
// 
//输入: num = "123", target = 6
//输出: ["1+2+3", "1*2*3"] 
//解释: “1*2*3” 和 “1+2+3” 的值都是6。
// 
//
// 示例 2: 
//
// 
//输入: num = "232", target = 8
//输出: ["2*3+2", "2+3*2"]
//解释: “2*3+2” 和 “2+3*2” 的值都是8。
// 
//
// 示例 3: 
//
// 
//输入: num = "3456237490", target = 9191
//输出: []
//解释: 表达式 “3456237490” 无法得到 9191 。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= num.length <= 10 
// num 仅含数字 
// -2³¹ <= target <= 2³¹ - 1 
// 
//
// Related Topics 数学 字符串 回溯 👍 509 👎 0

using System.Text;

namespace ExpressionAddOperators;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<string> AddOperators(string nums, int target)
    {
        var result = new List<string>();
        Backtrack(0, 0, 0, new());
        return result;

        void Backtrack(int index, long current, long last, StringBuilder exp)
        {
            if (index == nums.Length) {
                if (current == target) result.Add(exp.ToString());
                return;
            }

            for (var i = index; i < nums.Length; i++) {
                if (i != index && nums[index] == '0') break; // Skip leading zero numbers

                var numStr = nums.Substring(index, i - index + 1);
                var num = long.Parse(numStr);
                var len = exp.Length;

                if (index == 0) {
                    exp.Append(numStr);
                    Backtrack(i + 1, num, num, exp);
                    exp.Length = len;
                } else {
                    // Add
                    exp.Append('+').Append(numStr);
                    Backtrack(i + 1, current + num, num, exp);
                    exp.Length = len;

                    // Sub
                    exp.Append('-').Append(numStr);
                    Backtrack(i + 1, current - num, -num, exp);
                    exp.Length = len;

                    // Mul
                    exp.Append('*').Append(numStr);
                    Backtrack(i + 1, current - last + last * num, last * num, exp);
                    exp.Length = len;
                }
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
