//给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。 
//
// 设计一个算法来计算你所能获取的最大利润。你最多可以完成 两笔 交易。 
//
// 注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。 
//
// 
//
// 示例 1: 
//
// 
//输入：prices = [3,3,5,0,0,3,1,4]
//输出：6
//解释：在第 4 天（股票价格 = 0）的时候买入，在第 6 天（股票价格 = 3）的时候卖出，这笔交易所能获得利润 = 3-0 = 3 。
//     随后，在第 7 天（股票价格 = 1）的时候买入，在第 8 天 （股票价格 = 4）的时候卖出，这笔交易所能获得利润 = 4-1 = 3 。 
//
// 示例 2： 
//
// 
//输入：prices = [1,2,3,4,5]
//输出：4
//解释：在第 1 天（股票价格 = 1）的时候买入，在第 5 天 （股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。   
//     注意你不能在第 1 天和第 2 天接连购买股票，之后再将它们卖出。   
//     因为这样属于同时参与了多笔交易，你必须在再次购买前出售掉之前的股票。
// 
//
// 示例 3： 
//
// 
//输入：prices = [7,6,4,3,1] 
//输出：0 
//解释：在这个情况下, 没有交易完成, 所以最大利润为 0。 
//
// 示例 4： 
//
// 
//输入：prices = [1]
//输出：0
// 
//
// 
//
// 提示： 
//
// 
// 1 <= prices.length <= 10⁵ 
// 0 <= prices[i] <= 10⁵ 
// 
//
// Related Topics 数组 动态规划 👍 1834 👎 0

namespace BestTimeToBuyAndSellStockIii;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        // var n = prices.Length;
        // var maxProfitAfter = new int[n]; // 第 i 天及以后,一次交易的最大获利
        // var maxAfter = 0;
        // for (var i = n - 2; i >= 0; i--) {
        //     maxAfter = Math.Max(maxAfter, prices[i + 1]);
        //     maxProfitAfter[i] = Math.Max(maxProfitAfter[i + 1], maxAfter - prices[i]);
        // }
        //
        // var maxProfitBefore = new int[n]; // 第 i 天的严格之前,一次交易的最大获利
        // var minBefore = int.MaxValue;
        // for (var i = 2; i < n; i++) {
        //     minBefore = Math.Min(minBefore, prices[i - 2]);
        //     maxProfitBefore[i] = Math.Max(maxProfitBefore[i - 1], prices[i - 1] - minBefore);
        // }
        //
        // var maxProfit = 0;
        // for (var i = 0; i < n; i++) {
        //     var profit = maxProfitBefore[i] + maxProfitAfter[i];
        //     if (profit > maxProfit) maxProfit = profit;
        // }
        //
        // return maxProfit;

        var n = prices.Length;
        int buy1 = -prices[0], sell1 = 0;
        int buy2 = -prices[0], sell2 = 0;
        for (var i = 1; i < n; ++i) {
            // buy1 = Math.Max(buy1, -prices[i]);
            if (-prices[i] > buy1) buy1 = -prices[i];

            // sell1 = Math.Max(sell1, buy1 + prices[i]);
            var newS1 = buy1 + prices[i];
            if (newS1 > sell1) sell1 = newS1;

            // buy2 = Math.Max(buy2, sell1 - prices[i]);
            var newB2 = sell1 - prices[i];
            if (newB2 > buy2) buy2 = newB2;

            // sell2 = Math.Max(sell2, buy2 + prices[i]);
            var newS2 = buy2 + prices[i];
            if (newS2 > sell2) sell2 = newS2;
        }

        return sell2;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
