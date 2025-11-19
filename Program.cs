using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using IntegerBreak;
using Dumpify;

var summary = BenchmarkRunner.Run<Benchmarks>();
Console.WriteLine(summary);

public class Benchmarks
{
    private const int Size = 1000;
    [Benchmark]
    public void ListTest()
    {
        List<int> list = [];
        for (int i = Size; i >= 0; i--) {
            list.Insert(0, i);
            var a = list.BinarySearch(i - 5);
        }
    }

    [Benchmark]
    public void SortedSetTest()
    {
        SortedSet<int> set = [];
        for (int i = Size; i >= 0; i--) {
            set.Add(i);
            var a = set.GetViewBetween(int.MinValue, i - 5).Max;
        }
    }
}
