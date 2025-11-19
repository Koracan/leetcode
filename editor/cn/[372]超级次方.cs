//你的任务是计算 aᵇ 对 1337 取模，a 是一个正整数，b 是一个非常大的正整数且会以数组形式给出。 
//
// 
//
// 示例 1： 
//
// 
//输入：a = 2, b = [3]
//输出：8
// 
//
// 示例 2： 
//
// 
//输入：a = 2, b = [1,0]
//输出：1024
// 
//
// 示例 3： 
//
// 
//输入：a = 1, b = [4,3,3,8,5,2]
//输出：1
// 
//
// 示例 4： 
//
// 
//输入：a = 2147483647, b = [2,0,0]
//输出：1198
// 
//
// 
//
// 提示： 
//
// 
// 1 <= a <= 2³¹ - 1 
// 1 <= b.length <= 2000 
// 0 <= b[i] <= 9 
// b 不含前导 0 
// 
//
// Related Topics 数学 分治 👍 351 👎 0

using System.Numerics;

namespace SuperPow;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private const int Mod = 1337;
    private const int Phi = 1140; // 1337 = 7 * 191, φ(1337) = 6 * 190 = 1140
    private const int Mod1 = 7;
    private const int Phi1 = 6;
    private const int Mod2 = 191;
    private const int Phi2 = 190;
    private const int M1 = 191 * 4;
    private const int M2 = 7 * 82;

    public int SuperPow(int a, int[] b)
    {
        var exp = 0;
        foreach (var digit in b)
            exp = (exp * 10 + digit) % Phi;

        var exp1 = exp % Phi1;
        var exp2 = exp % Phi2;
        var part1 = ModPow(a % Mod1, exp1, Mod1);
        var part2 = ModPow(a % Mod2, exp2, Mod2);

        // 191 * 4 % 7 == 1, 7 * 82 % 191 == 1
        return (part1 * M1 + part2 * M2) % Mod;
    }
    private static int ModPow(int a, int exp, int mod)
    {
        if (a == 0) return 0;
        // fast pow
        var result = 1;
        var baseNum = a % mod;
        while (exp > 0) {
            if ((exp & 1) == 1)
                result = result * baseNum % mod;

            baseNum = baseNum * baseNum % mod;
            exp >>= 1;
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
