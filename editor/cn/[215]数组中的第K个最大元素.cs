//给定整数数组 nums 和整数 k，请返回数组中第 k 个最大的元素。 
//
// 请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。 
//
// 你必须设计并实现时间复杂度为 O(n) 的算法解决此问题。 
//
// 
//
// 示例 1: 
//
// 
//输入: [3,2,1,5,6,4], k = 2
//输出: 5
// 
//
// 示例 2: 
//
// 
//输入: [3,2,3,1,2,4,5,5,6], k = 4
//输出: 4 
//
// 
//
// 提示： 
//
// 
// 1 <= k <= nums.length <= 10⁵ 
// -10⁴ <= nums[i] <= 10⁴ 
// 
//
// Related Topics 数组 分治 快速选择 排序 堆（优先队列） 👍 2831 👎 0

namespace KthLargestElementInAnArray;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    // Random _rand = new(DateTime.Now.Millisecond);
    // public int FindKthLargest(int[] nums, int k)
    // {
    //     return QuickSelect(nums, 0, nums.Length, nums.Length - k);
    // }
    //
    // private int QuickSelect(int[] nums, int lo, int hi, int k)
    // {
    //     var idx = _rand.Next(lo, hi - 1);
    //     (nums[idx], nums[hi - 1]) = (nums[hi - 1], nums[idx]);
    //     var pivot = nums[hi - 1];
    //     var pIndex = lo;
    //
    //     for (var i = lo; i < hi - 1; i++)
    //         if (nums[i] < pivot) {
    //             (nums[i], nums[pIndex]) = (nums[pIndex], nums[i]);
    //             pIndex++;
    //         }
    //
    //     (nums[pIndex], nums[hi - 1]) = (nums[hi - 1], nums[pIndex]);
    //
    //     return (pIndex - k) switch {
    //         0 => nums[pIndex],
    //         < 0 => QuickSelect(nums, pIndex + 1, hi, k),
    //         _ => QuickSelect(nums, lo, pIndex, k)
    //     };
    // }

    public int FindKthLargest(int[] nums, int k)
    {
        // var heap = new PriorityQueue<int, int>();
        // foreach (var num in nums) {
        //     heap.Enqueue(num, num);
        //     if (heap.Count > k)
        //         heap.Dequeue();
        // }
        // return heap.Dequeue();
        MaxHeapify(nums, 0, nums.Length);
        for (var i = 0; i < k - 1; i++) {
            RemoveRoot(nums, 0, nums.Length - i);
        }

        return nums[0];
    }

    private void MaxHeapify(int[] nums, int lo, int hi)
    {
        var len = hi - lo;
        for (var i = len / 2 - 1; i >= 0; i--) {
            var parent = i;
            while (true) {
                var left = parent * 2 + 1;
                var right = parent * 2 + 2;
                var largest = parent;

                if (left < len && nums[lo + left] > nums[lo + largest])
                    largest = left;
                if (right < len && nums[lo + right] > nums[lo + largest])
                    largest = right;
                if (largest == parent)
                    break;

                (nums[lo + parent], nums[lo + largest]) = (nums[lo + largest], nums[lo + parent]);
                parent = largest;
            }
        }
    }

    private void RemoveRoot(int[] nums, int lo, int hi)
    {
        (nums[lo], nums[hi - 1]) = (nums[hi - 1], nums[lo]);
        var len = hi - lo - 1;

        var parent = 0;
        while (true) {
            var left = parent * 2 + 1;
            var right = parent * 2 + 2;
            var largest = parent;

            if (left < len && nums[lo + left] > nums[lo + largest])
                largest = left;
            if (right < len && nums[lo + right] > nums[lo + largest])
                largest = right;
            if (largest == parent)
                break;

            (nums[lo + parent], nums[lo + largest]) = (nums[lo + largest], nums[lo + parent]);
            parent = largest;
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
