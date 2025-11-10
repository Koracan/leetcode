//给你一个数组 nums ，请你完成两类查询。 
//
// 
// 其中一类查询要求 更新 数组 nums 下标对应的值 
// 另一类查询要求返回数组 nums 中索引 left 和索引 right 之间（ 包含 ）的nums元素的 和 ，其中 left <= right 
// 
//
// 实现 NumArray 类： 
//
// 
// NumArray(int[] nums) 用整数数组 nums 初始化对象 
// void update(int index, int val) 将 nums[index] 的值 更新 为 val 
// int sumRange(int left, int right) 返回数组 nums 中索引 left 和索引 right 之间（ 包含 ）的nums元
//素的 和 （即，nums[left] + nums[left + 1], ..., nums[right]） 
// 
//
// 
//
// 示例 1： 
//
// 
//输入：
//["NumArray", "sumRange", "update", "sumRange"]
//[[[1, 3, 5]], [0, 2], [1, 2], [0, 2]]
//输出：
//[null, 9, null, 8]
//
//解释：
//NumArray numArray = new NumArray([1, 3, 5]);
//numArray.sumRange(0, 2); // 返回 1 + 3 + 5 = 9
//numArray.update(1, 2);   // nums = [1,2,5]
//numArray.sumRange(0, 2); // 返回 1 + 2 + 5 = 8
// 
//
// 
//
// 提示： 
//
// 
// 1 <= nums.length <= 3 * 10⁴ 
// -100 <= nums[i] <= 100 
// 0 <= index < nums.length 
// -100 <= val <= 100 
// 0 <= left <= right < nums.length 
// 调用 update 和 sumRange 方法次数不大于 3 * 10⁴ 
// 
//
// Related Topics 设计 树状数组 线段树 数组 分治 👍 781 👎 0

namespace RangeSumQueryMutable;

//leetcode submit region begin(Prohibit modification and deletion)
public class NumArray
{
    private readonly int[] _fenwickTree; // start from 1
    private readonly int[] _nums;

    public NumArray(int[] nums)
    {
        _nums = nums;
        _fenwickTree = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++) {
            int x = i + 1;
            _fenwickTree[x] += nums[i];
            int p = x + LowBit(x);
            if (p < _fenwickTree.Length)
                _fenwickTree[p] += _fenwickTree[x];
        }
    }

    public void Update(int index, int val)
    {
        var add = val - _nums[index];
        _nums[index] = val;
        int x = index + 1;
        while (x < _fenwickTree.Length) {
            _fenwickTree[x] += add;
            x += LowBit(x); // parent(x) = x + LowBit(x)
        }
    }

    public int SumRange(int left, int right) => GetSum(right + 1) - GetSum(left);

    private int GetSum(int x)
    {
        int sum = 0;
        while (x > 0) {
            sum += _fenwickTree[x];
            x -= LowBit(x);
        }
        return sum;
    }

    private static int LowBit(int x) => x & -x;
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */
//leetcode submit region end(Prohibit modification and deletion)
