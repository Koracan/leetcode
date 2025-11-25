//给你一个整数 n ，请你在无限的整数序列 [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...] 中找出并返回第 n 位上的数字。
// 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 3
//输出：3
// 
//
// 示例 2： 
//
// 
//输入：n = 11
//输出：0
//解释：第 11 位数字在序列 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ... 里是 0 ，它是 10 的一部分。
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 2³¹ - 1 
// 
//
// Related Topics 数学 二分查找 👍 436 👎 0

namespace NthDigit;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int FindNthDigit(int n)
    {
        // digits[i] 表示 i + 1 位数的数字所占的位数总和
        int[] digits = [9, 90 * 2, 900 * 3, 9000 * 4, 90000 * 5, 900000 * 6, 9000000 * 7, 90000000 * 8, int.MaxValue];

        // 确定 n 位数所在的数字位数
        int digitLen = 1;
        while (n > digits[digitLen - 1]) {
            n -= digits[digitLen - 1];
            digitLen++;
        }

        // 确定 n 位数所在的具体数字
        int index = (n - 1) / digitLen; // 数字在该位数范围内的索引
        int startNum = (int)Math.Pow(10, digitLen - 1); // 该位数范围的起始数字
        int num = startNum + index; // 具体数字

        // 提取出具体数字的对应位数
        int offset = (n - 1) % digitLen; // 数字在该数字中的偏移量
        for (int i = 0; i < digitLen - offset - 1; i++) num /= 10;
        return num % 10;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
