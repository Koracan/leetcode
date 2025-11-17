//给你一个字符串 s ，仅反转字符串中的所有元音字母，并返回结果字符串。 
//
// 元音字母包括 'a'、'e'、'i'、'o'、'u'，且可能以大小写两种形式出现不止一次。 
//
// 
//
// 示例 1： 
//
// 
// 输入：s = "IceCreAm" 
// 
//
// 输出："AceCreIm" 
//
// 解释： 
//
// s 中的元音是 ['I', 'e', 'e', 'A']。反转这些元音，s 变为 "AceCreIm". 
//
// 示例 2： 
//
// 
// 输入：s = "leetcode" 
// 
//
// 输出："leotcede" 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 3 * 10⁵ 
// s 由 可打印的 ASCII 字符组成 
// 
//
// Related Topics 双指针 字符串 👍 384 👎 0

namespace ReverseVowelsOfAString;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public string ReverseVowels(string s)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        var chars = s.ToCharArray();
        for (int i = 0, j = chars.Length - 1; i < j; i++, j--) {
            while (i < j && !vowels.Contains(chars[i])) i++;
            while (i < j && !vowels.Contains(chars[j])) j--;
            (chars[i], chars[j]) = (chars[j], chars[i]);
        }

        return new(chars);
    }
}
//leetcode submit region end(Prohibit modification and deletion)
