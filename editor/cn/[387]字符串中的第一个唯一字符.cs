//给定一个字符串 s ，找到 它的第一个不重复的字符，并返回它的索引 。如果不存在，则返回 -1 。 
//
// 
//
// 示例 1： 
//
// 
//输入: s = "leetcode"
//输出: 0
// 
//
// 示例 2: 
//
// 
//输入: s = "loveleetcode"
//输出: 2
// 
//
// 示例 3: 
//
// 
//输入: s = "aabb"
//输出: -1
// 
//
// 
//
// 提示: 
//
// 
// 1 <= s.length <= 10⁵ 
// s 只包含小写字母 
// 
//
// Related Topics 队列 哈希表 字符串 计数 👍 784 👎 0

namespace FirstUniqueCharacterInAString;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public int FirstUniqChar(string s)
    {
        var charInOrder = new int[26]; // charInOrder[i] 表示第 i 个不同字符在 counts 中的下标
        var counts = new int[26];
        var firstIndexes = new int[26];

        var order = 0;
        for (int i = 0; i < s.Length; i++) {
            var c = s[i] - 'a';
            if (counts[c] == 0) {
                charInOrder[order] = c;
                order++;
                firstIndexes[c] = i;
            }
            counts[c]++;
        }
        for (var i = 0; i < order; i++) {
            var c = charInOrder[i];
            if (counts[c] == 1)
                return firstIndexes[c];
        }
        return -1;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
