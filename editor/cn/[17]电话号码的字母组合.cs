//给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。 
//
// 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。 
//
// 
//
// 
//
// 示例 1： 
//
// 
//输入：digits = "23"
//输出：["ad","ae","af","bd","be","bf","cd","ce","cf"]
// 
//
// 示例 2： 
//
// 
//输入：digits = ""
//输出：[]
// 
//
// 示例 3： 
//
// 
//输入：digits = "2"
//输出：["a","b","c"]
// 
//
// 
//
// 提示： 
//
// 
// 0 <= digits.length <= 4 
// digits[i] 是范围 ['2', '9'] 的一个数字。 
// 
//
// Related Topics 哈希表 字符串 回溯 👍 3060 👎 0

using System.Text;

namespace LetterCombinationsOfAPhoneNumber;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return [];

        var letters = new char[][] { ['a', 'b', 'c'], ['d', 'e', 'f'], ['g', 'h', 'i'], ['j', 'k', 'l'], ['m', 'n', 'o'], ['p', 'q', 'r', 's'], ['t', 'u', 'v'], ['w', 'x', 'y', 'z'] };

        var result = new List<string>();
        var sb = new StringBuilder(digits.Length);

        Dfs(0, sb);

        return result;

        void Dfs(int index, StringBuilder current)
        {
            if (index == digits.Length) {
                result.Add(current.ToString());
                return;
            }

            var digit = digits[index] - '2';
            foreach (var letter in letters[digit]) {
                current.Append(letter);
                Dfs(index + 1, current);
                current.Remove(index, 1);
            }
        }
    }
}
//leetcode submit region end(Prohibit modification and deletion)
