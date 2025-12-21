//给你一个整数 n ，返回一个字符串数组 answer（下标从 1 开始），其中： 
//
// 
// answer[i] == "FizzBuzz" 如果 i 同时是 3 和 5 的倍数。 
// answer[i] == "Fizz" 如果 i 是 3 的倍数。 
// answer[i] == "Buzz" 如果 i 是 5 的倍数。 
// answer[i] == i （以字符串形式）如果上述条件全不满足。 
// 
//
// 
//
// 示例 1： 
//
// 
//输入：n = 3
//输出：["1","2","Fizz"]
// 
//
// 示例 2： 
//
// 
//输入：n = 5
//输出：["1","2","Fizz","4","Buzz"]
// 
//
// 示例 3： 
//
// 
//输入：n = 15
//输出：["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","1
//4","FizzBuzz"] 
//
// 
//
// 提示： 
//
// 
// 1 <= n <= 10⁴ 
// 
//
// Related Topics 数学 字符串 模拟 👍 359 👎 0

namespace FizzBuzz;
//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    public IList<string> FizzBuzz(int n) {
        const string Fizz = "Fizz";
        const string Buzz = "Buzz";
        const string Fizzbuzz = "FizzBuzz";
        var result = new string[n];
        for (int i = 1; i <= n; i++)
            result[i - 1] = (i % 3, i % 5) switch {
                (0, 0) => Fizzbuzz,
                (0, _) => Fizz,
                (_, 0) => Buzz,
                _ => i.ToString()
            };

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
