//给你一个变量对数组 equations 和一个实数值数组 values 作为已知条件，其中 equations[i] = [Ai, Bi] 和 
//values[i] 共同表示等式 Ai / Bi = values[i] 。每个 Ai 或 Bi 是一个表示单个变量的字符串。 
//
// 另有一些以数组 queries 表示的问题，其中 queries[j] = [Cj, Dj] 表示第 j 个问题，请你根据已知条件找出 Cj / Dj =
// ? 的结果作为答案。 
//
// 返回 所有问题的答案 。如果存在某个无法确定的答案，则用 -1.0 替代这个答案。如果问题中出现了给定的已知条件中没有出现的字符串，也需要用 -1.0 替
//代这个答案。 
//
// 注意：输入总是有效的。你可以假设除法运算中不会出现除数为 0 的情况，且不存在任何矛盾的结果。 
//
// 注意：未在等式列表中出现的变量是未定义的，因此无法确定它们的答案。 
//
// 
//
// 示例 1： 
//
// 
//输入：equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries = [["a","c"]
//,["b","a"],["a","e"],["a","a"],["x","x"]]
//输出：[6.00000,0.50000,-1.00000,1.00000,-1.00000]
//解释：
//条件：a / b = 2.0, b / c = 3.0
//问题：a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ?
//结果：[6.0, 0.5, -1.0, 1.0, -1.0 ]
//注意：x 是未定义的 => -1.0 
//
// 示例 2： 
//
// 
//输入：equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0], 
//queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
//输出：[3.75000,0.40000,5.00000,0.20000]
// 
//
// 示例 3： 
//
// 
//输入：equations = [["a","b"]], values = [0.5], queries = [["a","b"],["b","a"],[
//"a","c"],["x","y"]]
//输出：[0.50000,2.00000,-1.00000,-1.00000]
// 
//
// 
//
// 提示： 
//
// 
// 1 <= equations.length <= 20 
// equations[i].length == 2 
// 1 <= Ai.length, Bi.length <= 5 
// values.length == equations.length 
// 0.0 < values[i] <= 20.0 
// 1 <= queries.length <= 20 
// queries[i].length == 2 
// 1 <= Cj.length, Dj.length <= 5 
// Ai, Bi, Cj, Dj 由小写英文字母与数字组成 
// 
//
// Related Topics 深度优先搜索 广度优先搜索 并查集 图 数组 字符串 最短路 👍 1224 👎 0

namespace EvaluateDivision;

//leetcode submit region begin(Prohibit modification and deletion)
public class Solution
{
    private class Variable(double value, int group)
    {
        public double Value = value;
        public int Group = group;
    }

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var dict = new Dictionary<string, Variable>();
        var group = 0;
        for (int i = 0; i < equations.Count; i++) {
            var a = equations[i][0];
            var b = equations[i][1];
            var value = values[i];
            Variable varA;
            Variable varB;

            switch (dict.ContainsKey(a), dict.ContainsKey(b)) {
                case (false, false):
                    dict[a] = new(value, group);
                    dict[b] = new(1.0, group);
                    group++;
                    break;
                case (true, false):
                    varA = dict[a];
                    dict[b] = new(varA.Value / value, varA.Group);
                    break;
                case (false, true):
                    varB = dict[b];
                    dict[a] = new(varB.Value * value, varB.Group);
                    break;
                case (true, true):
                    varA = dict[a];
                    varB = dict[b];
                    var groupA = varA.Group;
                    var groupB = varB.Group;

                    if (groupA != groupB) {
                        // merge groupB into groupA
                        var k = varA.Value / (value * varB.Value);
                        foreach (var variable in dict.Values)
                            if (variable.Group == groupB) {
                                variable.Value *= k;
                                variable.Group = groupA;
                            }
                    }
                    break;
            }
        }

        var result = new double[queries.Count];
        for (int i = 0; i < queries.Count; i++) {
            var a = queries[i][0];
            var b = queries[i][1];
            if (!dict.TryGetValue(a, out var varA)
             || !dict.TryGetValue(b, out var varB)
             || varA.Group != varB.Group)
                result[i] = -1.0;
            else
                result[i] = varA.Value / varB.Value;
        }

        return result;
    }
}
//leetcode submit region end(Prohibit modification and deletion)
