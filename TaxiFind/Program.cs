using BenchmarkDotNet.Running;
using TaxiFind.tests.benchmarks;

namespace TaxiFind;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<TaxiBenchmarks>();
    }
}