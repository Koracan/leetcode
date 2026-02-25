//请你设计一个用于存储字符串计数的数据结构，并能够返回计数最小和最大的字符串。 
//
// 实现 AllOne 类： 
//
// 
// AllOne() 初始化数据结构的对象。 
// inc(String key) 字符串 key 的计数增加 1 。如果数据结构中尚不存在 key ，那么插入计数为 1 的 key 。 
// dec(String key) 字符串 key 的计数减少 1 。如果 key 的计数在减少后为 0 ，那么需要将这个 key 从数据结构中删除。测试用例
//保证：在减少计数前，key 存在于数据结构中。 
// getMaxKey() 返回任意一个计数最大的字符串。如果没有元素存在，返回一个空字符串 "" 。 
// getMinKey() 返回任意一个计数最小的字符串。如果没有元素存在，返回一个空字符串 "" 。 
// 
//
// 注意：每个函数都应当满足 O(1) 平均时间复杂度。 
//
// 
//
// 示例： 
//
// 
//输入
//["AllOne", "inc", "inc", "getMaxKey", "getMinKey", "inc", "getMaxKey", 
//"getMinKey"]
//[[], ["hello"], ["hello"], [], [], ["leet"], [], []]
//输出
//[null, null, null, "hello", "hello", null, "hello", "leet"]
//
//解释
//AllOne allOne = new AllOne();
//allOne.inc("hello");
//allOne.inc("hello");
//allOne.getMaxKey(); // 返回 "hello"
//allOne.getMinKey(); // 返回 "hello"
//allOne.inc("leet");
//allOne.getMaxKey(); // 返回 "hello"
//allOne.getMinKey(); // 返回 "leet"
// 
//
// 
//
// 提示： 
//
// 
// 1 <= key.length <= 10 
// key 由小写英文字母组成 
// 测试用例保证：在每次调用 dec 时，数据结构中总存在 key 
// 最多调用 inc、dec、getMaxKey 和 getMinKey 方法 5 * 10⁴ 次 
// 
//
// Related Topics 设计 哈希表 链表 双向链表 👍 345 👎 0

namespace AllOoneDataStructure;

//leetcode submit region begin(Prohibit modification and deletion)

public class AllOne
{
    private class Node(int count = 0)
    {
        public int Count { get; } = count;
        public HashSet<string> Keys { get; } = [];
        public Node Prev { get; set; } = null!;
        public Node Next { get; set; } = null!;

        public Node InsertAfter(Node newNode)
        {
            newNode.Prev = this;
            newNode.Next = Next;
            Next.Prev = newNode;
            Next = newNode;
            return newNode;
        }

        public void Remove()
        {
            Prev.Next = Next;
            Next.Prev = Prev;
        }
    }

    private readonly Dictionary<string, Node> _keyToNode = new();
    private readonly Node _root = new(); // 环形链表的哨兵节点

    public AllOne()
    {
        _root.Next = _root;
        _root.Prev = _root;
    }

    public void Inc(string key)
    {
        if (_keyToNode.TryGetValue(key, out var node)) {
            var nextNode = node.Next;
            if (nextNode == _root || nextNode.Count > node.Count + 1) {
                nextNode = node.InsertAfter(new(node.Count + 1));
            }
            nextNode.Keys.Add(key);
            _keyToNode[key] = nextNode;
            node.Keys.Remove(key);
            if (node.Keys.Count == 0) node.Remove();
        } else {
            var firstNode = _root.Next;
            if (firstNode == _root || firstNode.Count > 1) {
                firstNode = _root.InsertAfter(new(1));
            }
            firstNode.Keys.Add(key);
            _keyToNode[key] = firstNode;
        }
    }

    public void Dec(string key)
    {
        var node = _keyToNode[key];
        if (node.Count == 1) {
            _keyToNode.Remove(key);
        } else {
            var prevNode = node.Prev;
            if (prevNode == _root || prevNode.Count < node.Count - 1) {
                prevNode = node.Prev.InsertAfter(new Node(node.Count - 1));
            }
            prevNode.Keys.Add(key);
            _keyToNode[key] = prevNode;
        }
        node.Keys.Remove(key);
        if (node.Keys.Count == 0) node.Remove();
    }

    public string GetMaxKey() => _root.Prev == _root ? "" : _root.Prev.Keys.First();

    public string GetMinKey() => _root.Next == _root ? "" : _root.Next.Keys.First();
}


/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */
//leetcode submit region end(Prohibit modification and deletion)
