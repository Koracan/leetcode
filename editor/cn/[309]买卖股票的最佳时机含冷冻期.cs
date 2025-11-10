//给定一个整数数组
// prices，其中第 prices[i] 表示第 i 天的股票价格 。 
//
// 设计一个算法计算出最大利润。在满足以下约束条件下，你可以尽可能地完成更多的交易（多次买卖一支股票）: 
//
// 
// 卖出股票后，你无法在第二天买入股票 (即冷冻期为 1 天)。 
// 
//
// 注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。 
//
// 
//
// 示例 1: 
//
// 
//输入: prices = [1,2,3,0,2]
//输出: 3 
//解释: 对应的交易状态为: [买入, 卖出, 冷冻期, 买入, 卖出] 
//
// 示例 2: 
//
// 
//输入: prices = [1]
//输出: 0
// 
//
// 
//
// 提示： 
//
// 
// 1 <= prices.length <= 5000 
// 0 <= prices[i] <= 1000 
// 
//
// Related Topics 数组 动态规划 👍 1881 👎 0

namespace BestTimeToBuyAndSellStockWithCooldown;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var n = prices.Length;
        var hold = new int[n]; // max profit on day i if we hold a stock
        var unhold = new int[n]; // max profit on day i if we don't hold a stock
        hold[0] = -prices[0];
        unhold[0] = 0;
        for (var i = 1; i < n; i++) {
            // Either we continue holding, or we buy today (after cooldown)
            var unholdPrev = i - 2 >= 0 ? unhold[i - 2] : 0;
            hold[i] = Math.Max(hold[i - 1], unholdPrev - prices[i]);
            unhold[i] = Math.Max(unhold[i - 1], hold[i - 1] + prices[i]);
        }

        return unhold[n - 1];
    }
}
//leetcode submit region end(Prohibit modification and deletion)
