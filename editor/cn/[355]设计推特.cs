//设计一个简化版的推特(Twitter)，可以让用户实现发送推文，关注/取消关注其他用户，能够看见关注人（包括自己）的最近 10 条推文。 
//
// 实现 Twitter 类： 
//
// 
// Twitter() 初始化简易版推特对象 
// void postTweet(int userId, int tweetId) 根据给定的 tweetId 和 userId 创建一条新推文。每次调用此函
//数都会使用一个不同的 tweetId 。 
// List<Integer> getNewsFeed(int userId) 检索当前用户新闻推送中最近 10 条推文的 ID 。新闻推送中的每一项都必须是
//由用户关注的人或者是用户自己发布的推文。推文必须 按照时间顺序由最近到最远排序 。 
// void follow(int followerId, int followeeId) ID 为 followerId 的用户开始关注 ID 为 
//followeeId 的用户。 
// void unfollow(int followerId, int followeeId) ID 为 followerId 的用户不再关注 ID 为 
//followeeId 的用户。 
// 
//
// 
//
// 示例： 
//
// 
//输入
//["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", 
//"unfollow", "getNewsFeed"]
//[[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]
//输出
//[null, null, [5], null, null, [6, 5], null, [5]]
//
//解释
//Twitter twitter = new Twitter();
//twitter.postTweet(1, 5); // 用户 1 发送了一条新推文 (用户 id = 1, 推文 id = 5)
//twitter.getNewsFeed(1);  // 用户 1 的获取推文应当返回一个列表，其中包含一个 id 为 5 的推文
//twitter.follow(1, 2);    // 用户 1 关注了用户 2
//twitter.postTweet(2, 6); // 用户 2 发送了一个新推文 (推文 id = 6)
//twitter.getNewsFeed(1);  // 用户 1 的获取推文应当返回一个列表，其中包含两个推文，id 分别为 -> [6, 5] 。推文 
//id 6 应当在推文 id 5 之前，因为它是在 5 之后发送的
//twitter.unfollow(1, 2);  // 用户 1 取消关注了用户 2
//twitter.getNewsFeed(1);  // 用户 1 获取推文应当返回一个列表，其中包含一个 id 为 5 的推文。因为用户 1 已经不再关注用
//户 2 
//
// 
//
// 提示： 
//
// 
// 1 <= userId, followerId, followeeId <= 500 
// 0 <= tweetId <= 10⁴ 
// 所有推特的 ID 都互不相同 
// postTweet、getNewsFeed、follow 和 unfollow 方法最多调用 3 * 10⁴ 次 
// 用户不能关注自己 
// 
//
// Related Topics 设计 哈希表 链表 堆（优先队列） 👍 419 👎 0

namespace DesignTwitter;

//leetcode submit region begin(Prohibit modification and deletion)
using Following = System.Collections.Generic.HashSet<int>;
using Tweets = System.Collections.Generic.LinkedList<(int tweetId, int time)>;

public record User(Following Following, Tweets Tweets);

public class Twitter
{
    private readonly Dictionary<int, User> _users = [];
    private int _time = 0;

    private User GetOrCreateUser(int userId)
    {
        if (!_users.TryGetValue(userId, out var user)) {
            user = new([], []);
            _users[userId] = user;
        }

        return user;
    }

    public void PostTweet(int userId, int tweetId)
    {
        var user = GetOrCreateUser(userId);
        user.Tweets.AddFirst((tweetId, _time));
        if (user.Tweets.Count > 10)
            user.Tweets.RemoveLast();

        _time++;
    }

    public IList<int> GetNewsFeed(int userId)
    {
        if (!_users.TryGetValue(userId, out var user))
            return [];

        var tweets = user.Tweets;

        foreach (var followee in user.Following) {
            var followeeTweets = _users[followee].Tweets;
            // Merge tweets with followeeTweets
            Tweets merged = [];
            var i = tweets.First;
            var j = followeeTweets.First;
            while (merged.Count < 10 && (i != null || j != null)) {
                if (i == null) {
                    merged.AddLast(j!.Value);
                    j = j.Next;
                } else if (j == null || i.Value.time > j.Value.time) {
                    merged.AddLast(i.Value);
                    i = i.Next;
                } else {
                    merged.AddLast(j.Value);
                    j = j.Next;
                }
            }
            tweets = merged;
        }

        return tweets.Select(a => a.tweetId).ToArray();
    }

    public void Follow(int followerId, int followeeId)
    {
        GetOrCreateUser(followeeId);
        GetOrCreateUser(followerId).Following.Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_users.TryGetValue(followerId, out var followerData))
            followerData.Following.Remove(followeeId);
    }
}

/**
 * Your Twitter object will be instantiated and called as such:
 * Twitter obj = new Twitter();
 * obj.PostTweet(userId,tweetId);
 * IList<int> param_2 = obj.GetNewsFeed(userId);
 * obj.Follow(followerId,followeeId);
 * obj.Unfollow(followerId,followeeId);
 */
//leetcode submit region end(Prohibit modification and deletion)
