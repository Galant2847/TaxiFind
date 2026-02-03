using NUnit.Framework;
using TaxiFind.algorithms;
using TaxiFind.models;

namespace TaxiFind.tests.NUnit;

[TestFixture]
public class TaxiTests
{
    private Driver?[,] _map = null!;
    private const int Size = 10;

    [SetUp]
    public void Setup()
    {
        _map = new Driver?[Size, Size];
    }

    [Test]
    public void AllAlgorithms_FindClosestDrivers()
    {
        var closest = new Driver(1, 1, 1);
        _map[1, 1] = closest;
        _map[8, 8] = new Driver(2, 8, 8);
        var order = new Order(0, 0);

        var radar = new RadarAlgorithm().FindNearestDrivers(order, _map, 1);
        var brute = new BruteForceAlgorithm().FindNearestDrivers(order, _map, 1);
        var square = new ExpandingSquareAlgorithm().FindNearestDrivers(order, _map, 1);
        
        Assert.Multiple(() =>
        {
            Assert.That(radar[0].ID, Is.EqualTo(1), "Radar ошибся");
            Assert.That(brute[0].ID, Is.EqualTo(1), "BruteForce ошибся");
            Assert.That(square[0].ID, Is.EqualTo(1), "ExpandingSquare ошибся");
        });
    }

    [Test]
    public void AllAlgorithms_IsFewerDriversThenExists()
    {
        _map[0, 0] = new Driver(1, 0, 0);
        _map[1, 1] = new Driver(2, 1, 1);
        var order = new Order(0, 0);
        
        var radar = new RadarAlgorithm().FindNearestDrivers(order, _map, 5);
        var brute = new BruteForceAlgorithm().FindNearestDrivers(order, _map, 5);
        var square = new ExpandingSquareAlgorithm().FindNearestDrivers(order, _map, 5);
        
        Assert.Multiple(() =>
        {
            Assert.That(radar.Count, Is.EqualTo(2));
            Assert.That(brute.Count, Is.EqualTo(2));
            Assert.That(square.Count, Is.EqualTo(2));
        });
    }

    [Test]
    public void AllAlgorithms_IsWorkAtMapEdges()
    {
        _map[9, 9] = new Driver(100, 9, 9);
        var order = new Order(9, 9);
        
        var radar = new RadarAlgorithm().FindNearestDrivers(order, _map, 1);
        var brute = new BruteForceAlgorithm().FindNearestDrivers(order, _map, 1);
        var square = new ExpandingSquareAlgorithm().FindNearestDrivers(order, _map, 1);
        
        Assert.That(radar[0].ID, Is.EqualTo(100));
        Assert.That(brute[0].ID, Is.EqualTo(100));
        Assert.That(square[0].ID, Is.EqualTo(100));
    }
    
}