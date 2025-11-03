//给出集合 [1,2,3,...,n]，其所有元素共有 n! 种排列。 
//
// 按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下： 
//
// 
// "123" 
// "132" 
// "213" 
// "231" 
// "312" 
// "321" 
// 
//
// 给定 n 和 k，返回第 k 个排列。 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 3, k = 3
//输出："213"
// 
//
// 示例 2： 
//
// 
//输入：n = 4, k = 9
//输出："2314"
// 
//
// 示例 3： 
//
// 
//输入：n = 3, k = 1
//输出："123"
// 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 9 
// 1 <= k <= n! 
// 
//
// Related Topics 递归 数学 👍 873 👎 0

namespace PermutationSequence;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string GetPermutation(int n, int k)
    {
        // k - 1 = a_n*(n-1)! + a_(n-1)* (n-2)! + ... + a_1*1!
        k--;
        var used = 0; // used & (1<< i) > 0 means i is used
        var factors = new int[n];
        var factor = 1;
        for (var i = 0; i < n; i++) {
            factors[i] = factor;
            factor *= i + 1;
        }

        var result = 0;
        for (var i = n - 1; i >= 0; i--) {
            var a = 0;
            if (k >= factors[i]) {
                a = k / factors[i];
                k -= a * factors[i];
            }

            a++;
            // find the a-th unused number
            var j = 1;
            while (a != 0) {
                if ((used & 1 << j) == 0) a--;

                j++;
            }

            j--;
            result = result * 10 + j;
            used |= 1 << j;
        }

        return result.ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
