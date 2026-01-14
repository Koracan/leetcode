//给你一个整数数组 nums ，返回 nums[i] XOR nums[j] 的最大运算结果，其中 0 ≤ i ≤ j < n 。 
//
// 
// 示例 1：
//
// 
//
//输入：nums = [3,10,5,25,2,8]
//输出：28
//解释：最大运算结果是 5 XOR 25 = 28. 
//
// 示例 2： 
//
// 
//输入：nums = [14,70,53,83,49,91,36,80,92,51,66,70]
//输出：127
// 
//
// 
// 提示：
//
// 
// 1 <= nums.length <= 2 * 10⁵ 
// 0 <= nums[i] <= 2³¹ - 1 
// 
//
// Related Topics 位运算 字典树 数组 哈希表 ���� 735 👎 0

namespace MaximumXorOfTwoNumbersInAnArray;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
// ReSharper disable once InconsistentNaming
    public int FindMaximumXOR(int[] nums)
    {
        var trie = new Trie();
        var maxXor = 0;
        foreach (var num in nums) {
            trie.Add(num);
            maxXor = Math.Max(maxXor, trie.MaxXor(num));
        }

        return maxXor;
    }

    private class Trie
    {
        private const int Null = -1;

        // Use two parallel lists for children to avoid allocating many small int[] objects.
        private readonly List<int> _left = []; // child for bit 0
        private readonly List<int> _right = []; // child for bit 1
        private readonly int _root;

        public Trie()
        {
            _root = NewNode();
        }

        private int NewNode()
        {
            _left.Add(Null);
            _right.Add(Null);
            return _left.Count - 1;
        }

        public void Add(int val)
        {
            var node = _root;
            for (var i = 31; i >= 0; i--) {
                var bit = val >> i & 1;
                var next = bit == 0 ? _left[node] : _right[node];
                if (next == Null) {
                    next = NewNode();
                    if (bit == 0) _left[node] = next;
                    else _right[node] = next;
                }
                node = next;
            }
        }

        public int MaxXor(int num)
        {
            var node = _root;
            var xor = 0;

            for (var i = 31; i >= 0; i--) {
                var bit = num >> i & 1;
                var desired = 1 - bit; // we prefer the opposite bit to maximize xor
                var next = desired == 0 ? _left[node] : _right[node];
                if (next != Null) {
                    xor |= 1 << i;
                    node = next;
                } else
                    // fallback to the other branch
                    node = desired == 0 ? _right[node] : _left[node];
            }

            return xor;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
