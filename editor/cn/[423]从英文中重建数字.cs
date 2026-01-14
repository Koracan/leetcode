//给你一个字符串 s ，其中包含字母顺序打乱的用英文单词表示的若干数字（0-9）。按 升序 返回原始的数字。 
//
// 
//
// 示例 1： 
//
// 
//输入：s = "owoztneoer"
//输出："012"
// 
//
// 示例 2： 
//
// 
//输入：s = "fviefuro"
//输出："45"
// 
//
// 
//
// 提示： 
//
// 
// 1 <= s.length <= 10⁵ 
// s[i] 为 ["e","g","f","i","h","o","n","s","r","u","t","w","v","x","z"] 这些字符之一 
// s 保证是一个符合题目要求的字符串 
// 
//
// Related Topics 哈希表 数学 字符串 👍 226 👎 0



namespace ReconstructOriginalDigitsFromEnglish;

//leetcode submit region begin(Prohibit modification and deletion)
using System.Text;

public class Solution
{
    public string OriginalDigits(string s)
    {
        var nums = new int[10];
        var counts = new int[26];
        foreach (var c in s) counts[c - 'a']++;

        nums[0] = counts['z' - 'a']; // zero
        nums[2] = counts['w' - 'a']; // two
        nums[4] = counts['u' - 'a']; // four
        nums[6] = counts['x' - 'a']; // six
        nums[8] = counts['g' - 'a']; // eight
        nums[3] = counts['h' - 'a'] - nums[8]; // three
        nums[5] = counts['f' - 'a'] - nums[4]; // five
        nums[7] = counts['s' - 'a'] - nums[6]; // seven
        nums[1] = counts['o' - 'a'] - nums[0] - nums[2] - nums[4]; // one
        nums[9] = counts['i' - 'a'] - nums[5] - nums[6] - nums[8]; // nine

        var result = new StringBuilder();
        for (var i = 0; i < 10; i++)
            result.Append((char)('0' + i), nums[i]);

        return result.ToString();
    }
}
//leetcode submit region end(Prohibit modification and deletion)
