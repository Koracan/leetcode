//给定整数 n 和 k，返回 [1, n] 中字典序第 k 小的数字。 
//
// 
//
// 示例 1: 
//
// 
//输入: n = 13, k = 2
//输出: 10
//解释: 字典序的排列是 [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9]，所以第二小的数字是 10。
// 
//
// 示例 2: 
//
// 
//输入: n = 1, k = 1
//输出: 1
// 
//
// 
//
// 提示: 
//
// 
// 1 <= k <= n <= 10⁹ 
// 
//
// Related Topics 字典树 👍 656 👎 0

namespace KThSmallestInLexicographicalOrder;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int FindKthNumber(int n, int k)
    {
        int prefix = 1;
        k--;
        while (k > 0) {
            int count = GetCount(prefix, n);
            if (count <= k) {
                prefix++;
                k -= count;
            } else {
                prefix *= 10;
                k--;
            }
        }

        return prefix;
    }
    private static int GetCount(int prefix, long n)
    {
        int count = 0;
        long first = prefix, last = prefix;
        while (first <= n) {
            count += (int)(Math.Min(last, n) - first + 1);
            first *= 10;
            last = last * 10 + 9;
        }
        return count;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
