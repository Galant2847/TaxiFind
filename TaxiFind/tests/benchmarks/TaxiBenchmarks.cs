using BenchmarkDotNet.Attributes;
using TaxiFind.models;
using TaxiFind.algorithms;

namespace TaxiFind.tests.benchmarks;

[MemoryDiagnoser]
public class TaxiBenchmarks
{
    private Driver?[,] _map = null!;
    private Order _order = null!;
    private RadarAlgorithm _radarAlgorithm = new();
    private BruteForceAlgorithm _bruteForceAlgorithm = new();
    private ExpandingSquareAlgorithm _expandingSquareAlgorithm = new();

    [GlobalSetup]
    public void Setup()
    {
        int size = 500;
        _map = new Driver?[size, size];
        _order = new Order(size / 2, size / 2);

        var random = new Random(42);

        for (int i = 0; i < size; i++)
        {
            int x = random.Next(size);
            int y = random.Next(size);

            _map[x, y] = new Driver(i, x, y);
        }
    }

    [Benchmark]
    public void Radar() => _radarAlgorithm.FindNearestDrivers(_order, _map, 5);

    [Benchmark]
    public void BruteForce() => _bruteForceAlgorithm.FindNearestDrivers(_order, _map, 5);
    
    [Benchmark]
    public void ExpandingSquare() => _expandingSquareAlgorithm.FindNearestDrivers(_order, _map, 5);
}