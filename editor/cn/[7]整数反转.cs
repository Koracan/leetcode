//给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。 
//
// 如果反转后整数超过 32 位的有符号整数的范围 [−2³¹, 231 − 1] ，就返回 0。 
//假设环境不允许存储 64 位整数（有符号或无符号）。
//
// 
//
// 示例 1： 
//
// 
//输入：x = 123
//输出：321
// 
//
// 示例 2： 
//
// 
//输入：x = -123
//输出：-321
// 
//
// 示例 3： 
//
// 
//输入：x = 120
//输出：21
// 
//
// 示例 4： 
//
// 
//输入：x = 0
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// -2³¹ <= x <= 2³¹ - 1 
// 
//
// Related Topics 数学 👍 4165 👎 0

namespace ReverseInteger;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private const int Upper = int.MaxValue / 10;
    private const int Lower = int.MinValue / 10;

    public int Reverse(int x)
    {
        var res = 0;
        while (x != 0) {
            // 溢出的情况下，x 最高位的最大值是 2，而边界的最低位是 7 或 8，所以除以 10 忽略末位判断是安全的
            if (res > Upper || res < Lower) return 0;
            res *= 10;
            res += x % 10;
            x /= 10;
        }

        return res;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
