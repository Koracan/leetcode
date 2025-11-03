//颠倒给定的 32 位有符号整数的二进制位。 
//
// 
//
// 示例 1： 
//
// 
// 输入：n = 43261596 
// 
//
// 输出：964176192 
//
// 解释： 
//
// 
// 
// 
// 整数 
// 二进制 
// 
// 
// 43261596 
// 00000010100101000001111010011100 
// 
// 
// 964176192 
// 00111001011110000010100101000000 
// 
// 
// 
//
// 示例 2： 
//
// 
// 输入：n = 2147483644 
// 
//
// 输出：1073741822 
//
// 解释： 
//
// 
// 
// 
// 整数 
// 二进制 
// 
// 
// 2147483644 
// 01111111111111111111111111111100 
// 
// 
// 1073741822 
// 00111111111111111111111111111110 
// 
// 
// 
//
// 
//
// 提示： 
//
// 
// 0 <= n <= 2³¹ - 2 
// n 为偶数 
// 
//
// 
//
// 进阶: 如果多次调用这个函数，你将如何优化你的算法？ 
//
// Related Topics 位运算 分治 👍 750 👎 0

namespace ReverseBits;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int ReverseBits(int n)
    {
        uint result = 0;
        for (int i = 0; i < 32; i++)
        {
            result <<= 1;
            result |= (uint)(n & 1);
            n >>= 1;
        }
        return (int)result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
