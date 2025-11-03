//给你一个字符串数组，请你将 字母异位词 组合在一起。可以按任意顺序返回结果列表。 
//
// 字母异位词 是由重新排列源单词的所有字母得到的一个新单词。 
//
// 
//
// 示例 1: 
//
// 
//输入: strs = ["eat", "tea", "tan", "ate", "nat", "bat"]
//输出: [["bat"],["nat","tan"],["ate","eat","tea"]] 
//
// 示例 2: 
//
// 
//输入: strs = [""]
//输出: [[""]]
// 
//
// 示例 3: 
//
// 
//输入: strs = ["a"]
//输出: [["a"]] 
//
// 
//
// 提示： 
//
// 
// 1 <= strs.length <= 10⁴ 
// 0 <= strs[i].length <= 100 
// strs[i] 仅包含小写字母 
// 
//
// Related Topics 数组 哈希表 字符串 排序 👍 2259 👎 0

namespace GroupAnagrams;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<long, List<string>>();
        
        foreach (var str in strs) {
            int[] count = new int[26];
            foreach (var c in str)
                count[c - 'a']++;
            long hash = 0;
            for (int i = 0; i < 26; i++)
                hash = hash * 31 + count[i];
            if (!dict.TryAdd(hash, [str]))
                dict[hash].Add(str);
        }
        var result = new List<IList<string>>();
        foreach (var group in dict.Values)
            result.Add(group);
        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
