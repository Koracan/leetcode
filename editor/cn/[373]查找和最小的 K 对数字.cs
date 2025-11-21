//给定两个以 非递减顺序排列 的整数数组 nums1 和 nums2 , 以及一个整数 k 。 
//
// 定义一对值 (u,v)，其中第一个元素来自 nums1，第二个元素来自 nums2 。 
//
// 请找到和最小的 k 个数对 (u1,v1), (u2,v2) ... (uk,vk) 。 
//
// 
//
// 示例 1: 
//
// 
//输入: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
//输出: [1,2],[1,4],[1,6]
//解释: 返回序列中的前 3 对数：
//     [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
// 
//
// 示例 2: 
//
// 
//输入: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
//输出: [1,1],[1,1]
//解释: 返回序列中的前 2 对数：
//     [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
// 
//
// 
//
// 提示: 
//
// 
// 1 <= nums1.length, nums2.length <= 10⁵ 
// -10⁹ <= nums1[i], nums2[i] <= 10⁹ 
// nums1 和 nums2 均为 升序排列 
// 
// 1 <= k <= 10⁴ 
// k <= nums1.length * nums2.length 
// 
//
// Related Topics 数组 堆（优先队列） 👍 693 👎 0

namespace FindKPairsWithSmallestSums;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var queue = new PriorityQueue<(int i, int j), int>();
        queue.Enqueue((0, 0), nums1[0] + nums2[0]);
        var result = new IList<int>[k];

        for (int i = 0; i < k; i++) {
            var (a, b) = queue.Dequeue();
            result[i] = [nums1[a], nums2[b]];
            if (b + 1 < nums2.Length)
                queue.Enqueue((a, b + 1), nums1[a] + nums2[b + 1]);

            // only enqueue the next row when we are at the first column to avoid duplicates
            if (b == 0 && a + 1 < nums1.Length)
                queue.Enqueue((a + 1, b), nums1[a + 1] + nums2[b]);
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
