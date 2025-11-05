//将非负整数 num 转换为其对应的英文表示。 
//
// 
//
// 示例 1： 
//
// 
//输入：num = 123
//输出："One Hundred Twenty Three"
// 
//
// 示例 2： 
//
// 
//输入：num = 12345
//输出："Twelve Thousand Three Hundred Forty Five"
// 
//
// 示例 3： 
//
// 
//输入：num = 1234567
//输出："One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
// 
//
// 
//
// 提示： 
//
// 
// 0 <= num <= 2³¹ - 1 
// 
//
// Related Topics 递归 数学 字符串 👍 349 👎 0

using System.Text;

namespace IntegerToEnglishWords;
//leetcode submit region begin(Prohibit modification and deletion)
public class Solution {
    const string Billion = "Billion";
    const string Million = "Million";
    const string Thousand = "Thousand";
    const string Hundred = "Hundred";

    readonly string[] _below20 = [
        "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
        "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    ];

    readonly string[] _tens = [
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    ];
    public string NumberToWords(int num) {
        if (num == 0) return "Zero";
        var result = "";
        if (num >= 1_000_000_000) {
            result += $"{NumberToWords(num / 1_000_000_000)} {Billion} ";
            num %= 1_000_000_000;
        }
        if (num >= 1_000_000) {
            result += $"{NumberToWords(num / 1_000_000)} {Million} ";
            num %= 1_000_000;
        }
        if (num >= 1_000) {
            result += $"{NumberToWords(num / 1_000)} {Thousand} ";
            num %= 1_000;
        }
        if (num >= 100) {
            result += $"{NumberToWords(num / 100)} {Hundred} ";
            num %= 100;
        }
        if (num >= 20) {
            result += $"{_tens[num / 10]} ";
            num %= 10;
        }
        if (num > 0) {
            result += $"{_below20[num]} ";
        }
        return result.Trim();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
